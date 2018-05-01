using System;
using System.Linq;
using System.Collections.Generic;
using Origin.ViewModel.Elements;
using Origin.ViewModels.Requests;
using Origin.ViewModels.Responses;
using Origin.Models;
using Origin.ViewModels;

namespace Origin.Service.Implementation
{
    class ItemTypeService
    {
        #region Private

        private OriginDbContext _dataContext;

        //private Configuration _configuration;

        //private string _localizationErrorKey;

        #endregion

        #region Constructor

        public ItemTypeService(OriginDbContext context)
        {
            _dataContext = context;
            //_configuration = configurationService.GetConfiguration();
            // TODO: mettere in configurazione
            //_localizationErrorKey = "General.Configuration.Error.";
        }

        #endregion

        #region Public Methods

        // TODO: consider to create a different method to use for both GetItems and GetItemTypes
        // Maybe GetItemTypesForList
        public GetItemsResponse GetItemTypesToList(GetItemTypesRequest request)
        {
            GetItemsResponse viewModel = new GetItemsResponse();

            try
            {
                var viewedItems = request.CurrentPage * request.ItemsPerPage;

                // If the list isn't configurated in the settings, the application will not show it
                //if (!_configuration.ItemLists.ItemLists.Any(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId)))
                //{
                //    throw new Exception(string.Format("{0}{1}", _localizationErrorKey, "ListNotConfigurated"));
                //}

                //viewModel.Headers = _configuration.ItemLists.ItemLists
                //                        .Single(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                //                        .VisibleFields.Select(vf => new GetItemsResponse.Header()
                //                        {
                //                            Name = vf.Name
                //                        })
                //                        .OrderBy(vf => vf.Name)
                //                        .ToList();

                viewModel.Items = _dataContext.OR_ItemTypes
                                    .Skip(viewedItems).Take(request.ItemsPerPage)
                                    //.Where(i => i.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                                    .Select(i => new GetItemsResponse.Item()
                                    {
                                        Id = i.Id,
                                        OriginId = i.OriginId.ToString(),
                                        // TODO: This motherfucker don't have any properties. Just a name
                                        Properties = new List<GetItemsResponse.Property>()
                                                    {
                                                        new GetItemsResponse.Property()
                                                        {
                                                            // TODO: avoit to set id to zero, find a better way to do it
                                                            Id = 0,
                                                            // TODO: avoit to set OriginId to string.Empty, find a better way to do it
                                                            OriginId = string.Empty,
                                                            // TODO: avoid to set the name to name, find a better way to do it
                                                            Name = "Name",
                                                            Value = i.Name
                                                        }
                                                    }
                                    })
                                    .ToList();

            }
            catch (Exception exc)
            {
                viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
                viewModel.ResultInfo.ErrorMessage = exc.Message;
            }

            return viewModel;
        }

        #endregion

    }
}
