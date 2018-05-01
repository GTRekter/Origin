/* ================ VIEWMODELs =============== */
function ViewModel(baseUrl) {

    var self = this;

    /* =============== VARIABLEs ============= */
    self.baseUrl = baseUrl;
    self.urls = {
        general: {
            getConfiguration: "Configuration/GetConfiguration",
            getLocalizations: "Configuration/GetLocalizations",
            getTables: "Configuration/GetTables",
            getTable: "Configuration/GetTable",
        },
        item: {
            addItem: self.baseUrl + "Item/AddItem",
            getItems: self.baseUrl + "Item/GetItems",
            getItem: self.baseUrl + "Item/GetItem",
            deleteItem: self.baseUrl + "Item/DeleteItem",
        },
        itemTypes: {
            getItemTypes: self.baseUrl + "ItemType/GetItemTypes"
        },
        form: {
            getForm: self.baseUrl + "Form/GetForm"
        }
    };

    /* =============== OBSERVABLEs ============= */
    /* =============== 1. GENERAL ============= */
    self.form = new FormViewModel();
    self.tablesList = new TablesListViewModel();
    self.tableDetails = new TableViewModel();
    self.itemsList = new ItemsListViewModel();
    self.itemDetails = new ItemViewModel();
    self.visibilities = new VisibilitiesViewModel();
    self.configurations = new ConfigurationsViewModel();

    /* =============== 2. MESSAGEs ============= */
    self.isInfo = ko.observable(false);
    self.isError = ko.observable(false);
    self.isLoading = ko.observable(false);
    self.errorDetails = ko.observable("");
    self.infoDetails = ko.observable("");

    /* =============== 3. LOCALIZATIONs ============= */
    self.resources = ko.observable(null);
    self.localizedText = function (toLocalize) {

        return ko.computed(function () {
            if (self.resources() !== null) {
                if (self.resources()[toLocalize] === undefined) {
                    return "RES NOT FOUND: " + toLocalize;
                }
                return self.resources()[toLocalize];
            }
        }, this);

    };

    /* =============== 4. SELECTION ============= */
    self.isMassiveSelection = ko.observable(false);
    self.massiveSelectionCss = ko.computed(function () {
        if (self.isMassiveSelection() === false) {
            return 'ion-ios-checkmark-outline';
        }
        return 'ion-ios-circle-outline';
    });
    self.massiveSelectionText = ko.computed(function () {
        if (self.isMassiveSelection() === false) {
            return self.localizedText('Section.ItemsList.Button.SelectAll');
        }
        return self.localizedText('Section.ItemsList.Button.DeselectAll');
    });

    /* =============== FUNCTIONs ============== */
    /* =============== 1. GET ============= */
    self.getConfiguration = function () {

        var ajaxUrl = self.urls.general.getConfiguration;

        $.ajax({
            type: "GET",
            url: ajaxUrl,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {

                // page dimension has to be observable because the UI will change
                ko.utils.arrayForEach(viewModel.ItemLists.PageDimensions, function (pageDimension) {
                    var pageDimensionToAdd = new PageDimensionViewModel({ Value: pageDimension });
                    self.Configurations.PageDimensions.push(pageDimensionToAdd);
                });

                // set the DefaultItemTypeOriginId
                self.Configurations.DefaultItemTypeOriginId = viewModel.ItemLists.DefaultItemTypeOriginId;

                // item types has to be observable because the UI will change
                ko.utils.arrayForEach(viewModel.ItemLists.ItemLists, function (itemList) {
                    var itemTypesOriginIdToAdd = new ItemTypeOriginIdViewModel({ Value: itemList.ItemTypeOriginId });
                    self.Configurations.ItemTypesOriginId.push(itemTypesOriginIdToAdd);
                });
            },
            error: function (error) {
                self.isError(true);
                self.errorDetails(error.statusText);
            }
        });

    };
    self.getLocalizations = function () {

        var ajaxUrl = self.urls.general.getLocalizations;

        $.ajax({
            type: "GET",
            url: ajaxUrl,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                self.resources(viewModel.resources);
            },
            error: function (error) {
                self.isError(true);
                self.errorDetails(error.statusText);
            }
        });

    };
    self.getItems = function () {

        self.isLoading(true);

        var ajaxUrl = self.urls.item.getItems,
            ajaxData = {
                // TODO: Leggere il valore da un observable
                currentPage: self.itemsList.page(),
                itemsPerPage: self.itemsList.pageDimension(),
                ItemTypeOriginId: self.itemsList.itemTypeOriginId(),
            };
        $.ajax({
            type: "POST",
            url: ajaxUrl,
            data: JSON.stringify(ajaxData),
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                if (viewModel.resultInfo.result === 0) {

                    // set itemsList headers
                    self.itemsList.Headers.removeAll();
                    ko.utils.arrayForEach(viewModel.headers, function (header) {
                        var headerToAdd = new HeaderViewModel();
                        header.localizedName = self.localizedText("Section.ItemsList.Property." + header.name);
                        headerToAdd.setProperties(header);
                        self.itemsList.headers.push(headerToAdd);
                    });

                    //// set itemsList actions
                    //self.ItemsList.Actions.removeAll();
                    //ko.utils.arrayForEach(viewModel.Actions, function (action) {
                    //    var actionToAdd = new ActionViewModel();
                    //    actionToAdd.setProperties(action);
                    //    self.ItemsList.Actions.push(actionToAdd);
                    //});

                    self.addItemsToItemsList(viewModel);
                } else {
                    self.isError(true);
                    //self.errorDetails = self.localizedText(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.isLoading(false);
            }
        });

    };
    self.getItem = function () {

        self.isLoading(true);

        var ajaxUrl = self.urls.item.getItem,
            ajaxData = {
                OriginId: self.itemDetails.originId(),
                ItemTypeOriginId: self.itemDetails.itemTypeOriginId()
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
                    self.itemDetails.setProperties(viewModel.Item, self.resources());
                } else {
                    self.isError(true);
                    self.errorDetails = self.localizedText(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.isLoading(false);
            }
        });

    };
    self.getForm = function () {

        self.isLoading(true);

        var ajaxUrl = self.urls.form.getForm,
            ajaxData = {
                // TODO: lette da un'observable
                actionName: "Add",
                ItemTypeOriginId: self.itemsList.itemTypeOriginId()
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

                    // clean old inputs
                    self.form.inputs.removeAll();
                    self.form.name(viewModel.name);

                    ko.utils.arrayForEach(viewModel.Inputs, function (input) {
                        var inputToAdd = new InputViewModel();
                        inputToAdd.setProperties(input);
                        inputToAdd.setLocalization(self.resources());

                        self.form.inputs.push(inputToAdd);
                    });

                } else {
                    self.isError(true);
                    self.errorDetails(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.isLoading(false);
            }
        });

    }; // TODO adjust 
    self.getItemTypes = function ()
    {
        self.isLoading(true);

        var ajaxUrl = self.urls.itemType.getItemTypes,
            ajaxData = {
                currentPage: self.itemsList.page(),
                itemsPerPage: self.itemsList.pageDimension()
            };
        $.ajax({
            type: "POST",
            url: ajaxUrl,
            data: JSON.stringify(ajaxData),
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (viewModel) {
                if (viewModel.resultInfo.result === 0) {

                    // set itemsList headers
                    // TODO: Move in another call, it's useless that i get this data foreach call
                    self.itemsList.Headers.removeAll();
                    ko.utils.arrayForEach(viewModel.headers, function (header) {
                        var headerToAdd = new HeaderViewModel();
                        header.localizedName = self.localizedText("Section.ItemsList.Property." + header.name);
                        headerToAdd.setProperties(header);
                        self.itemsList.headers.push(headerToAdd);
                    });

                    self.addItemsToItemsList(viewModel);
                } else {
                    self.isError(true);
                    //self.errorDetails = self.localizedText(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.isLoading(false);
            }
        });
    };

    /* =============== 2. ADD ============= */
    self.addItem = function () {

        self.isLoading(true);

        var ajaxUrl = self.urls.item.addItem,
            ajaxData = {
                // TODO: lette da un'observable
                itemType: "Dog",
                inputs: ko.toJS(self.form.inputs)
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
                    self.infoDetails(localizedText);
                    self.isInfo(true);

                    // refresh the items list
                    self.ItemsList.Items.removeAll();
                    self.getItems();

                } else {
                    self.isError(true);
                    self.errorDetails(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.isLoading(false);
            }
        });

    };
    self.addItemsToItemsList = function (viewModel) {

        var items = new Array(self.ItemsList.Items());
        ko.utils.arrayForEach(viewModel.Items, function (item) {
            var itemToAdd = new ItemViewModel();
            itemToAdd.setProperties(item, self.resources());
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

    }; // TODO adjust

    /* =============== 3. DELETE ============= */
    self.deleteItems = function (itemsOriginId) {

        self.isLoading(true);

        var ajaxUrl = self.urls.item.deleteItem,
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
                    self.infoDetails(localizedText);
                    self.isInfo(true);

                    // refresh the items list
                    self.ItemsList.Items.removeAll();
                    self.getItems();

                } else {
                    self.isError(true);
                    self.errorDetails(viewModel.ResultInfo.ErrorMessage);
                }
            },
            complete: function () {
                self.isLoading(false);
            }
        });

    };

    /* =============== 4. GENERAL ============= */
    self.toggleVisibilities = function (sectionToShow) {
        self.visibilities.dashboardVisible(false);
        self.visibilities.itemsListVisible(false);
        self.visibilities.itemDetailsVisible(false);
        self.visibilities.formVisible(false);
        self.visibilities.tablesListVisible(false);
        self.visibilities.tableDetailsVisible(false);

        switch (sectionToShow) {
            case "dashboard":
                self.visibilities.dashboardVisible(true);
                break;
            case "itemsList":
                self.visibilities.itemsListVisible(true);
                break;
            case "tablesList":
                self.visibilities.tablesListVisible(true);
                break;
            case "itemDetails":
                self.visibilities.itemDetailsVisible(true);
                break;
            case "tableDetails":
                self.visibilities.tableDetailsVisible(true);
                break;
            case "form":
                self.visibilities.formVisible(true);
                break;
        }
    };
    self.resetItemList = function () {

        // Remove the items
        self.itemsList.items.removeAll();

        // Set the first value of the page dimension as default
        var pageDimension = 0;
        if (self.configurations.pageDimensions().length > 0) {
            pageDimension = self.configurations.pageDimensions()[0].value;
        }
        self.itemsList.pageDimension(pageDimension);

        // Set the filter of the listType as the configuration
        self.itemsList.itemTypeOriginId(self.configurations.defaultItemTypeOriginId);
    }
    self.Init = function () {

        self.getConfiguration();
        self.getLocalizations();

        self.toggleVisibilities("dashboard");
    };

    /* ================ EVENTs =============== */
    /* =============== 1. NAVBAR ============= */
    self.onClickDashboard = function () {
        self.toggleVisibilities("dashboard");
    };
    self.onClickItemsList = function () {
        self.resetItemList();
        self.getItems();
        self.toggleVisibilities("itemsList");
    };
    self.onClickItemTypesList = function () {
        self.resetItemList();
        self.getItemTypes();
        self.toggleVisibilities("itemsList");
    };
    self.onClickConfiguration = function () {
        self.getTables();
        self.toggleVisibilities("tablesList");
    };

    /* =============== 2. ITEMsLIST ============= */
    self.onClickAddItem = function () {
        self.toggleVisibilities("form");
        // TODO: leggere la tipologia di oggetto selezionato ed utilizzarlo per filtrare le form
        self.getForm();
    };
    self.onClickItem = function (itemData) {
        self.toggleVisibilities("itemDetails");

        var itemDataJS = ko.toJS(itemData);
        self.itemDetails.setProperties(itemDataJS, self.resources());
        self.getItem();
    };
    self.onClickDeleteItems = function () {
        self.toggleVisibilities("itemsList");

        // get the selected items
        var selectedItemsOriginId = new Array();
        ko.utils.arrayForEach(self.ItemsList.Items(), function (item) {
            if (true == item.IsSelected()) {
                var itemOriginId = item.OriginId();
                selectedItemsOriginId.push(itemOriginId)
            }
        });

        self.deleteItems(selectedItemsOriginId);
    };
    self.onClickLoadMore = function () {
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
    };
    self.onClickChangeItemTypeOriginId = function (itemClicked) {
        self.ItemsList.Items.removeAll();
        self.ItemsList.ItemTypeOriginId(itemClicked.Value);
        self.getItems();
    };

    /* =============== 2. TABLEsLIST ============= */
    self.onClickTable = function (itemData) {
        self.toggleVisibilities("tableDetails");

        var itemDataJS = ko.toJS(itemData);
        self.tableDetails.setProperties(itemDataJS, self.resources());
        self.getTable();
    };

    /* =============== 3. ITEMDETAILs ============= */
    self.onClickEditItem = function () {
        self.toggleVisibilities("form");
        // TODO: Handle the type of action programmatically
        self.getForm();
    };
    self.onClickDeleteItem = function () {
        self.toggleVisibilities("itemsList");

        var itemOriginId = self.itemDetails.originId();
        self.deleteItems(itemOriginId);
    };
    self.onClickBackButton = function () {
        self.toggleVisibilities("itemsList");
    };

    /* =============== 4. FORM ============= */
    self.onClickExecuteForm = function () {
        self.toggleVisibilities("itemsList");

        self.addItem();
    };

    self.Init();
}

/* ================ MODELSs =============== */
function VisibilitiesViewModel() {
    var self = this;
    self.dashboardVisible = ko.observable(false);
    self.itemsListVisible = ko.observable(false);
    self.itemDetailsVisible = ko.observable(false);
    self.formVisible = ko.observable(false);
    self.tablesListVisible = ko.observable(false);
    self.tableDetailsVisible = ko.observable(false);
}

function ConfigurationsViewModel() {
    var self = this;
    self.pageDimensions = ko.observableArray([]);
    self.itemTypesOriginId = ko.observableArray([]);
    self.defaultItemTypeOriginId = null;
}

function FormViewModel() {
    var self = this;
    self.name = ko.observable();
    self.inputs = ko.observableArray();
}

function InputViewModel(itemData) {
    var self = this;
    self.name = ko.observable(null);
    self.type = ko.observable(null);
    self.values = ko.observableArray(null);
    self.value = ko.observable(null);
    self.localizedName = ko.observable(null);

    self.setProperties = function (itemData) {
        self.name(itemData.name);
        self.type(itemData.type);
        self.values(itemData.values);
        self.value(itemData.value);
    };
    self.setLocalization = function (localizations) {
        if (localizations !== null && localizations["Section.Form.Input." + self.name()] === undefined) {
            self.localizedName("RES NOT FOUND: Section.Form.Input." + self.name());
        } else {
            self.localizedName(localizations["Section.Form.Input." + self.name()]);
        }
    };
}

function PageDimensionViewModel(itemData) {
    var self = this;
    self.value = itemData.Value;
    self.isSelected = ko.observable(false);
}

function ItemTypeOriginIdViewModel(itemData) {
    var self = this;
    self.value = itemData.Value;
    self.isSelected = ko.observable(false);
}

function ActionViewModel(itemData) {
    var self = this;
    self.originId = ko.observable(null);
    self.name = ko.observable(null);
    self.localizedName = ko.observable(null);

    self.setProperties = function (itemData) {
        self.OriginId(itemData.OriginId);
        self.name(itemData.name);
    }
    self.setLocalization = function (localizations) {
        if (localizations !== null && localizations["Section.ItemDetails.Action." + self.name()] === undefined) {
            self.localizedName("RES NOT FOUND: Section.ItemDetails.Action." + self.name());
        } else {
            self.localizedName(localizations["Section.ItemDetails.Action." + self.name()]);
        }
    };
}

/* ================ ITEMs =============== */
function ItemsListViewModel() {
    var self = this;
    self.headers = ko.observableArray([]);
    self.items = ko.observableArray([]);
    //self.Actions = ko.observableArray([]);
    self.pageDimension = ko.observable();
    self.itemTypeOriginId = ko.observable();
    self.page = ko.observable(0);
}
function HeaderViewModel() {
    var self = this;
    self.name = ko.observable(null);
    self.localizedName = null;

    self.setProperties = function (itemData) {
        self.name(itemData.name);
        self.localizedName = itemData.localizedName;
    }
}
function ItemViewModel() {
    var self = this;
    self.originId = ko.observable(null);
    self.itemTypeOriginId = ko.observable(null);
    self.creationDate = ko.observable(null);
    self.lastEditDate = ko.observable(null);
    self.properties = ko.observableArray([]);
    self.isSelected = ko.observable(false);
    self.isSelectedCssClass = ko.pureComputed(function () {
        return self.IsSelected() ? "ion-ios-checkmark-outline" : "ion-ios-circle-outline";
    }, self);

    self.setProperties = function (itemData, localizations) {
        self.OriginId(itemData.OriginId);
        self.ItemTypeOriginId(itemData.ItemTypeOriginId);
        self.CreationDate(itemData.CreationDate);
        self.LastEditDate(itemData.LastEditDate);

        var properties = new Array();
        ko.utils.arrayForEach(itemData.Properties, function (property) {
            var propertyToAdd = new PropertyViewModel();
            propertyToAdd.setProperties(property);
            propertyToAdd.setLocalization(localizations);
            properties.push(propertyToAdd);
        });
        self.Properties(properties);
    };
}
function PropertyViewModel(itemData) {
    var self = this;
    self.originId = ko.observable(null);
    self.name = ko.observable(null);
    self.value = ko.observable(null);
    self.localizedName = ko.observable(null);

    self.setProperties = function (itemData) {
        self.originId(itemData.originId);
        self.name(itemData.name);
        self.value(itemData.value);
    }

    self.setLocalization = function (localizations) {
        if (localizations !== null && localizations["Section.ItemDetails.Property." + self.name()] === undefined) {
            self.localizedName("RES NOT FOUND: Section.ItemDetails.Property." + self.name());
        } else {
            self.localizedName(localizations["Section.ItemDetails.Property." + self.name()]);
        }
    };
}

/* ================ TABLEs =============== */
function TablesListViewModel() {
    var self = this;
    self.tables = ko.observableArray([]);
}
function TableViewModel() {
    var self = this;
    self.name = ko.observable(null);
    self.localizedName = ko.observable(null);
    self.columns = ko.observableArray([]);
    self.rows = ko.observableArray([]);

    //self.pageDimension = ko.observable();
    //self.ItemTypeOriginId = ko.observable();
    //self.Page = ko.observable(0);

    self.setProperties = function (itemData, localizations) {

        self.name(itemData.name);

        var columns = new Array();
        ko.utils.arrayForEach(itemData.columns, function (column) {
            var columnToAdd = new TableColumnViewModel();
            columnToAdd.setProperties(column);
            columnToAdd.setLocalization(localizations);
            columns.push(columnToAdd);
        });
        self.columns(columns);
    };

    self.setLocalization = function (localizations) {
        if (localizations !== null && localizations["Section.Configuration.ColumnName." + self.name()] === undefined) {
            self.localizedName("RES NOT FOUND: Section.Configuration.ColumnName." + self.name());
        } else {
            self.localizedName(localizations["Section.Configuration.ColumnName." + self.name()]);
        }
    };
}
function TableColumnViewModel(itemData) {
    var self = this;
    self.name = ko.observable(null);
    self.value = ko.observable(null);
    self.localizedName = ko.observable(null);

    self.setProperties = function (itemData) {
        self.name(itemData.name);
        self.value(itemData.value);
    }

    self.setLocalization = function (localizations) {
        if (localizations !== null && localizations["Section.ItemDetails.Property." + self.name()] === undefined) {
            self.localizedName("RES NOT FOUND: Section.ItemDetails.Property." + self.name());
        } else {
            self.localizedName(localizations["Section.ItemDetails.Property." + self.name()]);
        }
    };
}
//function TablePropertyViewModel(itemData) {
//    var self = this;
//    self.OriginId = ko.observable(null);
//    self.name = ko.observable(null);
//    self.value = ko.observable(null);
//    self.localizedName = ko.observable(null);

//    self.setProperties = function (itemData) {
//        self.OriginId(itemData.OriginId);
//        self.name(itemData.name);
//        self.Value(itemData.Value);
//    }

//    self.setLocalization = function (localizations) {
//        if (localizations !== null && localizations["Section.ItemDetails.Property." + self.name()] === undefined) {
//            self.localizedName("RES NOT FOUND: Section.ItemDetails.Property." + self.name());
//        } else {
//            self.localizedName(localizations["Section.ItemDetails.Property." + self.name()]);
//        }
//    };
//}





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