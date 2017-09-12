/* ================ VIEWMODELs =============== */
function ViewModel(baseUrl) {

    var self = this;

    self.IsInfo = ko.observable(false);
    self.IsError = ko.observable(false);
    self.IsLoading = ko.observable(false);

    self.IsLoadMoreVisible = ko.observable(true);
    self.ErrorDetails = ko.observable("");
    self.InfoDetails = ko.observable("");
    self.Resources = ko.observable(null);

    self.ItemsList = new ItemsListViewModel();
    self.ItemDetails = new ItemViewModel();
    self.Visibilities = new VisibilitiesViewModel();
    self.Configurations = new ConfigurationsViewModel();
    self.Form = new FormViewModel();
    self.localizedText = function (toLocalize) {

        return ko.computed(function () {
            if (self.Resources() !== null) {
                if (self.Resources()[toLocalize] === undefined) {
                    return "RES NOT FOUND: " + toLocalize;
                }
                return self.Resources()[toLocalize];
            }
        }, this);

    };

    self.IsMassiveSelection = ko.observable(false);
    self.MassiveSelectionCss = ko.computed(function () {
        if (self.IsMassiveSelection() === false) {
            return 'ion-ios-checkmark-outline';
        }
        return 'ion-ios-circle-outline';
    });
    self.MassiveSelectionText = ko.computed(function () {
        if (self.IsMassiveSelection() === false) {
            return self.localizedText('Section.ItemsList.Button.SelectAll');
        }
        return self.localizedText('Section.ItemsList.Button.DeselectAll');
    });

    /* =============== PROPERTIESs ============= */
    self.BackButtonVisible = ko.observable(false);
    self.Urls = {
        General: {
            GetConfiguration: baseUrl + "Configuration/GetConfiguration",
            GetLocalizations: baseUrl + "Configuration/GetLocalizations"
        },
        Item: {
            AddItem: baseUrl + "Item/AddItem",
            GetItems: baseUrl + "Item/GetItems",
            DeleteItem: baseUrl + "Item/DeleteItem",
        },
        Form: {
            GetForm: baseUrl + "Form/GetForm"
        }
    };
    /* ======================================== */

    /* =============== FUNCTIONs ============== */
    self.getConfiguration = function () {

        var ajaxUrl = self.Urls.General.GetConfiguration;

        $.ajax({
            type: "POST",
            url: ajaxUrl,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {

                ko.utils.arrayForEach(viewModel.PageDimensions, function (pageDimension) {
                    var pageDimensionToAdd = new PageDimensionViewModel({ Value: pageDimension });
                    self.Configurations.PageDimensions.push(pageDimensionToAdd);
                });

            },
            error: function (error) {
                self.IsError(true);
                self.ErrorDetails(error.statusText);
            }
        });

    };
    self.getLocalizations = function () {

        var ajaxUrl = self.Urls.General.GetLocalizations;

        $.ajax({
            type: "POST",
            url: ajaxUrl,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                self.Resources(viewModel.Resources);
            },
            error: function (error) {
                self.IsError(true);
                self.ErrorDetails(error.statusText);
            }
        });

    };
    self.getItems = function () {

        self.IsLoading(true);

        var ajaxUrl = self.Urls.Item.GetItems,
            ajaxData = {
                // TODO: Leggere il valore da un observable
                currentPage: self.ItemsList.Page(),
                itemsPerPage: self.ItemsList.PageDimension(),
                itemsType: "Dog",
            };
        $.ajax({
            type: "POST",
            url: ajaxUrl,
            data: JSON.stringify(ajaxData),
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                if (viewModel.ResultInfo.Result === 0) {
                    self.addItemsToItemsList(viewModel);
                } else {
                    self.IsError(true);
                    self.ErrorDetails(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.IsLoading(false);
            }
        });

    };
    self.getForm = function () {

        self.IsLoading(true);

        var ajaxUrl = self.Urls.Form.GetForm,
            ajaxData = {
                // TODO: lette da un'observable
                actionName: "Add",
                // TODO: lette da un'observable
                itemType: "Dog"
            };
        $.ajax({
            type: "POST",
            url: ajaxUrl,
            data: JSON.stringify(ajaxData),
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                if (viewModel.ResultInfo.Result === 0) {

                    // pulisco gli imput pregressi
                    self.Form.Inputs.removeAll();

                    self.Form.Name(viewModel.Name);

                    ko.utils.arrayForEach(viewModel.Inputs, function (input) {
                        var inputToAdd = new InputViewModel(input);
                        self.Form.Inputs.push(inputToAdd);
                    });

                } else {
                    self.IsError(true);
                    self.ErrorDetails(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.IsLoading(false);
            }
        });

    };

    self.addItem = function () {

        self.IsLoading(true);

        var ajaxUrl = self.Urls.Item.AddItem,
            ajaxData = {
                // TODO: lette da un'observable
                itemType: "Dog",
                inputs: ko.toJS(self.Form.Inputs)
            };
        $.ajax({
            type: "POST",
            url: ajaxUrl,
            data: JSON.stringify(ajaxData),
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                if (viewModel.ResultInfo.Result === 0) {

                    // show info message
                    var localizedText = self.localizedText('Messages.Information.Operation.Complete');
                    self.InfoDetails(localizedText);
                    self.IsInfo(true);

                    // refresh the items list
                    self.ItemsList.Items.removeAll();
                    self.getItems();

                } else {
                    self.IsError(true);
                    self.ErrorDetails(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.IsLoading(false);
            }
        });

    };

    self.deleteItems = function (itemsOriginId) {

        self.IsLoading(true);

        var ajaxUrl = self.Urls.Item.DeleteItem,
            ajaxData = {
                originIds: itemsOriginId
            };
        $.ajax({
            type: "POST",
            url: ajaxUrl,
            data: JSON.stringify(ajaxData),
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                if (viewModel.ResultInfo.Result === 0) {

                    // show info message
                    var localizedText = self.localizedText('Messages.Information.Operation.Complete');
                    self.InfoDetails(localizedText);
                    self.IsInfo(true);

                    // refresh the items list
                    self.ItemsList.Items.removeAll();
                    self.getItems();

                } else {
                    self.IsError(true);
                    self.ErrorDetails(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.IsLoading(false);
            }
        });

    };

    self.toggleVisibilities = function (sectionToShow) {
        self.Visibilities.DashboardVisible(false);
        self.Visibilities.ItemsListVisible(false);
        self.Visibilities.ItemDetailsVisible(false);
        self.Visibilities.FormVisible(false);

        switch (sectionToShow) {
            case "dashboard":
                self.Visibilities.DashboardVisible(true);
                break;
            case "itemsList":
                self.Visibilities.ItemsListVisible(true);
                break;
            case "itemDetails":
                self.Visibilities.ItemDetailsVisible(true);
                break;
            case "form":
                self.Visibilities.FormVisible(true);
                break;
        }
    };
    self.addItemsToItemsList = function (viewModel) {

        var items = new Array(self.ItemsList.Items());
        ko.utils.arrayForEach(viewModel.Items, function (item) {
            var itemToAdd = new ItemViewModel();
            itemToAdd.setProperties(item);
            self.ItemsList.Items.push(itemToAdd);
        });

        //Set the total item counts 
        //self.ItemsList.ItemsCount(listData.ItemsCount);

        //Hide the load more if the items count is the same as the document loaded
        //self.IsLoadMoreVisible(true);
        //if (listData.ItemsCount === self.DocumentsList.Documents().length) {
        //    self.IsLoadMoreVisible(false);
        //}

        //self.DocumentsList.CurrentPageIndex(self.DocumentsList.CurrentPageIndex() + 1);
        //self.DocumentsList.CurrentDocuments(self.DocumentsList.Documents().length);

    };
    self.resetItemList = function () {

        // Remove the items
        self.ItemsList.Items.removeAll();

        // Set the first value of the page dimension as default
        var pageDimension = 0;
        if (self.Configurations.PageDimensions().length > 0) {
            pageDimension = self.Configurations.PageDimensions()[0].Value;
        }
        self.ItemsList.PageDimension(pageDimension);
    }
    self.Init = function () {

        self.getConfiguration();
        self.getLocalizations();

        self.toggleVisibilities("dashboard");
    };
    /* ======================================== */

    /* ================ EVENTs =============== */
    self.onClickDashboard = function () {
        self.toggleVisibilities("dashboard");
    };
    self.onClickItemsList = function () {
        self.resetItemList();
        self.getItems();
        self.toggleVisibilities("itemsList");
    };

    self.onClickAddItem = function () {
        // TODO: leggere la tipologia di oggetto selezionato ed utilizzarlo per filtrare le form
        self.getForm();
        self.toggleVisibilities("form");
    };
    self.OnClickItem = function (itemData) {
        var itemDataJS = ko.toJS(itemData)
        self.ItemDetails.setProperties(itemDataJS);
        self.toggleVisibilities("itemDetails");
    };
    self.onClickEditItem = function () {
        //self.ItemDetails.OriginId;
        self.getForm();
        self.toggleVisibilities("form");
    };
    self.onClickDeleteItem = function () {
        var itemOriginId = self.ItemDetails.OriginId();
        self.deleteItems(itemOriginId);
        self.toggleVisibilities("itemsList");
    };
    self.onClickDeleteItems = function () {

        // get the selected items
        var selectedItemsOriginId = new Array();
        ko.utils.arrayForEach(self.ItemsList.Items(), function (item) {
            if (true == item.IsSelected()) {
                var itemOriginId = item.OriginId();
                selectedItemsOriginId.push(itemOriginId)
            }
        });

        self.deleteItems(selectedItemsOriginId);
        self.toggleVisibilities("itemsList");
    };
    self.onClickExecuteForm = function () {
        self.addItem();
        self.toggleVisibilities("itemsList");
    };

    self.onClickBackButton = function () {
        self.toggleVisibilities("itemslist");
    };
    self.onClickLoadMore = function () {
        self.getSharepointDocuments();
    };
    self.onClickToggleMassiveSelection = function () {
        ko.utils.arrayForEach(self.DocumentsList.Documents(), function (document) {
            if (self.IsMassiveSelection() === true) {
                document.IsSelected(false);
            } else {
                document.IsSelected(true);
            }
        });
        self.IsMassiveSelection(!self.IsMassiveSelection());
    };
    self.clickItemChangeSelection = function (itemClicked) {
        itemClicked.IsSelected(!itemClicked.IsSelected());   
    };
    self.onClickChangePageDimension = function (itemClicked) {
        self.ItemsList.Items.removeAll();
        self.ItemsList.PageDimension(itemClicked.Value);
        self.getItems();
    }
    /* ======================================= */

    self.Init();
}
/* ======================================= */

/* ================ BINDINGs =============== */
ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = { format: "dd/mm/yyyy" };
        $(element).datepicker(options).on("changeDate", function (ev) {
            var observable = valueAccessor();
            observable(ev.date);
        });
    },
    update: function (element, valueAccessor) {
        var date = ko.utils.unwrapObservable(valueAccessor());
        if (moment(date)._isValid) {
            var value = moment(date).format('DD/MM/YYYY');
            valueAccessor(value);
            $(element).datepicker("setValue", value);
            return;
        }
        valueAccessor("");
        $(element).val("");
    }
}; 
ko.bindingHandlers.showModal = {
    init: function (element, valueAccessor) { },
    update: function (element, valueAccessor) {
        var value = valueAccessor();
        if (ko.utils.unwrapObservable(value)) {
            $(element).modal('show');
        }
        else {
            $(element).modal('hide');
        }
    }
};
ko.bindingHandlers.truncatedText = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor()),
            length = ko.utils.unwrapObservable(allBindingsAccessor().length) || ko.bindingHandlers.truncatedText.defaultLength,
            truncatedValue = value.length > length ? value.substring(0, Math.min(value.length, length)) + " ..." : value;

        ko.bindingHandlers.text.update(element, function () { return truncatedValue; });
    },
    defaultLength: 100
};
ko.bindingHandlers.fadeVisible = {
    init: function (element, valueAccessor) {
        var value = valueAccessor();
        if (ko.isObservable(value)) {
            $(element).toggle(value); 
        }
    },
    update: function (element, valueAccessor) {
        var value = valueAccessor();
        if (ko.isObservable(value)) {
            value ? $(element).fadeIn() : $(element).fadeOut();
        }
    }
};
/* ======================================= */

/* ================ MODELSs =============== */
function VisibilitiesViewModel() {
    var self = this;
    self.DashboardVisible = ko.observable(false);
    self.ItemsListVisible = ko.observable(false);
    self.ItemDetailsVisible = ko.observable(false);
    self.FormVisible = ko.observable(false);
}

function FormViewModel() {
    var self = this;
    self.Name = ko.observable();
    self.Inputs = ko.observableArray();
}

function InputViewModel(itemData) {
    var self = this;
    self.Name = ko.observable(itemData.Name);
    self.Type = ko.observable(itemData.Type);
    self.DisplayName = ko.observable(itemData.DisplayName);
    self.Values = ko.observableArray(itemData.Values);
    self.Value = ko.observable("")
}

function ItemsListViewModel() {
    var self = this;
    self.Headers = ko.observableArray([]);
    self.Items = ko.observableArray([]);
    self.PageDimension = ko.observable();
    self.ItemType = ko.observable();
    self.Page = ko.observable(0);
}

function ItemViewModel() {
    var self = this;
    self.OriginId = ko.observable(null);
    self.ItemTypeOriginId = ko.observable(null);
    self.CreationDate = ko.observable(null);
    self.LastEditDate = ko.observable(null);
    self.Properties = ko.observableArray([]);
    self.IsSelected = ko.observable(false);
    self.IsSelectedCssClass = ko.pureComputed(function () {
        return self.IsSelected() ? "ion-ios-checkmark-outline" : "ion-ios-circle-outline" ;
    }, self);

    self.setProperties = function (itemData) {
        self.OriginId(itemData.OriginId);
        self.ItemTypeOriginId(itemData.ItemTypeOriginId);
        self.CreationDate(itemData.CreationDate);
        self.LastEditDate(itemData.LastEditDate);

        var properties = new Array();
        ko.utils.arrayForEach(itemData.Properties, function (property) {
            var propertyToAdd = new PropertyViewModel(property);
            properties.push(propertyToAdd);
        });
        self.Properties(properties);
    }
}

function HeaderViewModel() {
    var self = this;
    self.DisplayName = ko.observable();
}

function PropertyViewModel(itemData) {
    var self = this;
    self.OriginId = itemData.OriginId;
    self.DisplayName = itemData.DisplayName;
    self.Name = itemData.Name;
    self.Value = itemData.Value;
}

function PageDimensionViewModel(itemData) {
    var self = this;
    self.Value = itemData.Value;
    self.IsSelected = ko.observable(false);
}

function ConfigurationsViewModel() {
    var self = this;
    self.PageDimensions = ko.observableArray([]);
}

/* ======================================= */

/* ================ EVENTs =============== */
$(document).ready(function (e) {

    $('.date-picker').datepicker();
    var baseUrl = $("body").data("baseUrl");

    var viewModel = new ViewModel(baseUrl);
    ko.applyBindings(viewModel);

});

$(document).on('click', 'li.dropdown.mega-dropdown a', function (event) {
    $(this).parent().toggleClass('open');
});

$(document).on("click", ".sidebar-toggle", function () {
    $(".wrapper").toggleClass("toggled");
});
/* ======================================= */