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

function ViewModel(baseUrl) {

    var self = this;

    self.IsInfo = ko.observable(false);
    self.IsError = ko.observable(false);
    self.IsLoading = ko.observable(false);

    self.IsLoadMoreVisible = ko.observable(true);
    self.ErrorDetails = ko.observable("");
    self.Resources = ko.observable(null);

    self.ItemsList = new ItemsListViewModel();
    self.Visibilities = new VisibilitiesViewModel();
    self.Form = new FormPropertyViewModel();
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
            return self.localizedText('Document.List.Header.Button.Select.All');
        }
        return self.localizedText('Document.List.Header.Button.Deselect.All');
    });

    /* =============== PROPERTIESs ============= */

    self.BackButtonVisible = ko.observable(false);
    self.Urls = {
        General: {
            GetConfiguration: baseUrl + "Configuration/GetConfiguration",
            GetLocalizations: baseUrl + "Configuration/GetLocalizations"
        },
        Item: {
            GetItems: baseUrl + "Item/GetItems"
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

                // Aggiungo le configurazioni relative alle possibili dimensioni della pagina
                if (viewModel.ItemsList.PageDimensions.length > 0) {
                    self.ItemsList.PageDimensions(viewModel.ItemsList.PageDimensions[0]);
                }

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

        var ajaxUrl = self.Urls.Sharepoint.GetDocuments,
            ajaxData = {
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
                actionType: "",
                Type: ""
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
                    // TODO: aggiunto i campi della form
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
        self.Visibilities.FormVisible(false);

        switch (sectionToShow) {
            case "dashboard":
                self.Visibilities.DashboardVisible(true);
                break;
            case "itemsList":
                self.Visibilities.ItemsListVisible(true);
                break;
            case "form":
                self.Visibilities.FormVisible(true);
                break;
        }
    };
    self.addItemsToItemsList = function (listData) {

        var documents = new Array(self.DocumentsList.Documents());
        ko.utils.arrayForEach(listData.Documents, function (document) {
            var documentToAdd = new DocumentDetailsViewModel(document);

            // Set the selection value depending on the value of IsMassiveSelection
            if (self.IsMassiveSelection() === true) {
                documentToAdd.IsSelected(true);
            }
            self.DocumentsList.Documents.push(documentToAdd);
        });

        //Set the total item counts 
        self.DocumentsList.DocumentsCount(listData.ItemsCount);

        //Hide the load more if the items count is the same as the document loaded
        self.IsLoadMoreVisible(true);
        if (listData.ItemsCount === self.DocumentsList.Documents().length) {
            self.IsLoadMoreVisible(false);
        }


        self.DocumentsList.CurrentPageIndex(self.DocumentsList.CurrentPageIndex() + 1);
        self.DocumentsList.CurrentDocuments(self.DocumentsList.Documents().length);

    };
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
    self.onClickDogs = function () {
        self.toggleVisibilities("itemsList");
    };
    self.onClickRaces = function () {
        self.toggleVisibilities("itemsList");
    };

    self.onClickAddItem = function () {
        self.toggleVisibilities("form");
    };
    self.onClickDeleteItem = function () {
    };

    self.onClickBackButton = function () {
        if (self.FiltersVisible() === true) {
            self.toggleVisibilities("companies");
            self.clearDocuments();
            self.clearFilters();
            self.clearCompanies();
            return false;
        }
        if (self.DocumentsVisible() === true) {
            self.toggleVisibilities("filters");
            self.clearDocuments();
            self.clearFilters();
            return false;
        }
        if (self.ExportVisible() === true) {
            self.toggleVisibilities("documents");
            return false;
        }
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
    self.onClickChangePageDimension = function (itemData) {
    };
    self.clickItemChangeSelection = function (itemClicked) {
        itemClicked.IsSelected(!itemClicked.IsSelected());   
    };
    self.onChangeFilterFile = function (itemData, inputName) {
        if (itemData.value !== "") {
            self.uploadFilterFile(itemData, inputName);
        }
        itemData.value = "";
    };
    /* ======================================= */

    self.Init();
}


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
    self.FormVisible = ko.observable(false);
}

function FormViewModel() {
    var self = this;
    self.Name = ko.observable();
    self.Properties = ko.observableArray([]);
}

function FormPropertyViewModel() {
    var self = this;
    self.Name = ko.observable();
    self.Type = ko.observable();
    self.DisplayName = ko.observable();
}

function ItemsListViewModel() {
    var self = this;
    self.Headers = ko.observableArray([]);
    self.Items = ko.observableArray([]);
    self.PageDimensions = ko.observableArray([]);
}

function ItemViewModel() {
    var self = this;
    self.Properties = ko.observableArray([]);
}

function HeaderViewModel() {
    var self = this;
    self.DisplayName = ko.observable();
}

function PropertyViewModel() {
    var self = this;
    self.DisplayName = ko.observable();
}
/* ======================================= */