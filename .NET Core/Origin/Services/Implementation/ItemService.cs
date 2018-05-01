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
    class ItemService
    {
        #region Private

        private OriginDbContext _dataContext;

        //private Configuration _configuration;

        //private string _localizationErrorKey;

        #endregion

        #region Constructor
      
        public ItemService(OriginDbContext context)
        {
            _dataContext = context;
           // _configuration = configurationService.GetConfiguration();
           // TODO: mettere in configurazione
           //_localizationErrorKey = "General.Configuration.Error.";
        }

        #endregion

        //#region Public Methods

        //public Base AddItem(AddItemRequest request)
        //{
        //    Base viewModel = new Base();

        //    try
        //    {
        //        // Prendo l'originId del tipo di item
        //        OR_ItemType itemType = GetItemType(request.ItemType);

        //        // Creo l'item
        //        Guid itemOriginId = Guid.NewGuid();
        //        OR_Item item = new OR_Item()
        //        {
        //            OriginId = itemOriginId,
        //            ItemTypeOriginId = itemType.OriginId,
        //            LastEditDate = DateTime.Now,
        //            CreationDate = DateTime.Now
        //        };
        //        _dataContext.OR_Items.Add(item);
        //        _dataContext.SaveChanges();

        //        // Per ogni input creo la relativa property
        //        foreach (AddItemRequest.Input input in request.Inputs)
        //        {
        //            Guid propertyOriginId = Guid.NewGuid();
        //            OR_Property property = new OR_Property()
        //            {
        //                OriginId = propertyOriginId,
        //                RelatedOriginId = item.OriginId,
        //                Name = input.Name,
        //                Value = input.Value
        //            };
        //            _dataContext.OR_Properties.Add(property);
        //        }

        //        // NB. Gli input vengono aggiornati automaticamente al submit
        //        _dataContext.SaveChanges();
        //    }
        //    catch (Exception exc)
        //    {
        //        viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
        //        viewModel.ResultInfo.ErrorMessage = exc.Message;
        //    }

        //    return viewModel;
        //}

        public GetItemsResponse GetItemsToList(GetItemsRequest request)
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

                viewModel.Items = _dataContext.OR_Items
                                    .OrderByDescending(i => i.CreationDate)
                                    .Skip(viewedItems).Take(request.ItemsPerPage)
                                    .Where(i => i.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                                    .Select(i => new GetItemsResponse.Item()
                                    {
                                        Id = i.Id,
                                        OriginId = i.OriginId.ToString(),
                                        ItemTypeOriginId = i.ItemTypeOriginId.ToString(),
                                        CreationDate = FormatDate(i.CreationDate),
                                        LastEditDate = FormatDate(i.LastEditDate),
                                        Properties = _dataContext.OR_PropertyValues
                                                                .Where(pv => pv.ItemOriginId == i.OriginId)
                                                                .Join(_dataContext.OR_Properties,
                                                                        value => value.PropertyOriginId,
                                                                        property => property.OriginId,
                                                                        (value, property) => new GetItemsResponse.Property()
                                                                        {
                                                                            Id = property.Id,
                                                                            OriginId = property.OriginId.ToString(),
                                                                            Name = property.Name,
                                                                            Value = value.Value
                                                                        })
                                                                .OrderBy(p => p.Name)
                                                                .ToList()
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

        //public GetItemResponse GetItem(GetItemRequest request)
        //{
        //    GetItemResponse viewModel = new GetItemResponse();

        //    try
        //    {
        //        // If the list isn't configurated in the settings, the application will not show it
        //        if (!_configuration.ItemDetails.Any(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId)))
        //        {
        //            throw new Exception(string.Format("{0}{1}", _localizationErrorKey, "DetailNotConfigurated"));
        //        }

        //        viewModel.Item = _dataContext.OR_Items
        //                            .Where(i => i.OriginId.Equals(request.OriginId))
        //                            .Where(i => i.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
        //                            .Select(i => new GetItemResponse.ItemDetails()
        //                            {
        //                                Id = i.Id,
        //                                OriginId = i.OriginId.ToString(),
        //                                ItemTypeOriginId = i.ItemTypeOriginId.ToString(),
        //                                CreationDate = FormatDate(i.CreationDate),
        //                                LastEditDate = FormatDate(i.LastEditDate),
        //                                Properties = _dataContext.OR_Properties
        //                                                .Where(p => p.RelatedOriginId == i.OriginId)
        //                                                .Where(p => _configuration.ItemDetails
        //                                                                .Single(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
        //                                                                .VisibleFields.Select(vf => vf.Name)
        //                                                                .ToList()
        //                                                                .Contains(p.Name))
        //                                                .Select(p => new GetItemResponse.Property()
        //                                                {
        //                                                    Id = p.Id,
        //                                                    OriginId = p.OriginId.ToString(),
        //                                                    Name = p.Name,
        //                                                    Value = p.Value
        //                                                })
        //                                                .OrderBy(p => p.Name)
        //                                                .ToList()
        //                            })
        //                            .FirstOrDefault();
        //    }
        //    catch (Exception exc)
        //    {
        //        viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
        //        viewModel.ResultInfo.ErrorMessage = exc.Message;
        //    }

        //    return viewModel;
        //}

        //public Base DeleteItems(DeleteItemRequest request)
        //{
        //    Base viewModel = new Base();

        //    try
        //    {
        //        // Check if there are all originIds
        //        bool isMissing = false;
        //        List<string> originIdsMissing = new List<string>();
        //        foreach (string originId in request.OriginIds)
        //        {
        //            isMissing = false;
        //            isMissing = !_dataContext.OR_Items
        //                            .Any(i => i.OriginId.Equals(originId));
        //            if (isMissing)
        //            {
        //                originIdsMissing.Add(originId);
        //            }
        //        }

        //        if (originIdsMissing.Count > 0)
        //        {
        //            string exceptionMessage = string.Format("The following originIds are missing in the database. Check the data: {0}", string.Join(", ", originIdsMissing.ToArray()));
        //            throw new Exception(exceptionMessage);
        //        }

        //        foreach (string originId in request.OriginIds)
        //        {
        //            // before delete the item, i have to delete all the item properties
        //            List<OR_Property> itemProperties = _dataContext.OR_Properties
        //                                                    .Where(p => p.RelatedOriginId.Equals(originId))
        //                                                    .ToList();
        //            foreach (OR_Property propertyToDelete in itemProperties)
        //            {
        //                _dataContext.OR_Properties.Remove(propertyToDelete);
        //            }

        //            // delete the item
        //            OR_Item itemToDelete = _dataContext.OR_Items.Single(i => i.OriginId.Equals(originId));
        //            _dataContext.OR_Items.Remove(itemToDelete);
        //        }
        //        _dataContext.SaveChanges();

        //    }
        //    catch (Exception exc)
        //    {
        //        viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
        //        viewModel.ResultInfo.ErrorMessage = exc.Message;
        //    }

        //    return viewModel;
        //}

        ////private Base AddLookupValue(AddLookupValueRequest lookupValue)
        ////{
        ////    Base viewModel = new Base();

        ////    try
        ////    {

        ////    }
        ////    catch (Exception exc)
        ////    {
        ////        viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
        ////        viewModel.ResultInfo.ErrorMessage = exc.Message;
        ////    }

        ////    return viewModel;
        ////}

        //private Base DeleteLookupValue(OR_LookupValue lookupValue)
        //{
        //    Base viewModel = new Base();

        //    try
        //    {

        //    }
        //    catch (Exception exc)
        //    {
        //        viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
        //        viewModel.ResultInfo.ErrorMessage = exc.Message;
        //    }

        //    return viewModel;
        //}

        //#endregion

        #region Private Methods

        private GetLookupResponse GetLookup(string name)
        {
            GetLookupResponse viewModel = new GetLookupResponse();

            return viewModel;
        }

        //private OR_ItemType GetItemType(string name)
        //{
        //    OR_ItemType itemType = _dataContext.OR_ItemTypes
        //                            .Where(it => it.Name.Equals(name))
        //                            .FirstOrDefault();
        //    return itemType;
        //}

        private string FormatDate(DateTime date)
        {
            // TODO: put in a UI configuration file
            //return date.ToString(_configuration.Date.Format);
            return date.ToString();
        }

        #endregion
    }
}
