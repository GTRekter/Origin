using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using Origin.Service.Models;
using Origin.Service.Implementation;
using Origin.Service.Models.Elements;
using Origin.Service.Models.Requests;
using Origin.Service.Models.Responses;

namespace Origin.Service
{
    public class ItemService : IItemService
    {

        #region Private

        private CacheService cacheService = new CacheService();

        private ConfigurationService configurationService = new ConfigurationService();

        private OriginDataContext _dataContext;

        private Configuration _configuration;

        private string _localizationErrorKey;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ItemService));

        #endregion

        #region Constructor

        public ItemService()
        {
            _dataContext = new OriginDataContext();
            _configuration = configurationService.GetConfiguration();
            _localizationErrorKey = ConfigurationManager.AppSettings["LocalizzazionErrorKey"];
        }

        #endregion

        #region Public Methods

        public Base AddItem(AddItemRequest request)
        {
            Base viewModel = new Base();

            try
            {
                // Prendo l'originId del tipo di item
                OR_ItemType itemType = getItemType(request.ItemType);

                // Creo l'item
                string itemOriginId = Guid.NewGuid().ToString();
                OR_Item item = new OR_Item()
                {
                    OriginId = itemOriginId,
                    ItemTypeOriginId = itemType.OriginId,
                    LastEditDate = DateTime.Now,
                    CreationDate = DateTime.Now
                };
                _dataContext.OR_Items.InsertOnSubmit(item);
                _dataContext.SubmitChanges();

                // Per ogni input creo la relativa property
                foreach (AddItemRequest.Input input in request.Inputs)
                {
                    string propertyOriginId = Guid.NewGuid().ToString();
                    OR_Property property = new OR_Property()
                    {
                        OriginId = propertyOriginId,
                        RelatedOriginId = item.OriginId,
                        Name = input.Name,
                        Value = input.Value
                    };
                    _dataContext.OR_Properties.InsertOnSubmit(property);
                }

                // NB. Gli input vengono aggiornati automaticamente al submit
                _dataContext.SubmitChanges();
            }
            catch (Exception exc)
            {
                viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
                viewModel.ResultInfo.ErrorMessage = exc.Message;
            }

            return viewModel;
        }

        public GetItemsResponse GetItems(GetItemsRequest request)
        {
            GetItemsResponse viewModel = new GetItemsResponse();

            try
            {
                var viewedItems = request.CurrentPage * request.ItemsPerPage;

                // If the list isn't configurated in the settings, the application will not show it
                if (!_configuration.ItemLists.ItemLists.Any(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId))) {
                    throw new Exception(string.Format("{1}{2}", _localizationErrorKey, "ListNotConfigurated"));
                }

                viewModel.Headers = _configuration.ItemLists.ItemLists
                                        .Single(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                                        .VisibleFields.Select(vf => new GetItemsResponse.Header() {
                                            Name = vf.Name
                                        })
                                        .OrderBy(vf => vf.Name)
                                        .ToList();

                viewModel.Items = _dataContext.OR_Items
                                    .OrderByDescending(i => i.CreationDate)
                                    .Skip(viewedItems).Take(request.ItemsPerPage)
                                    .Where(i => i.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                                    .Select(i => new GetItemsResponse.Item() {
                                        Id = i.Id,
                                        OriginId = i.OriginId,
                                        ItemTypeOriginId = i.ItemTypeOriginId,
                                        //CreationDate = i.CreationDate.ToString(_configuration.Date.Format),
                                        //LastEditDate = i.LastEditDate.ToString(_configuration.Date.Format),
                                        Properties = _dataContext.OR_Properties
                                                        .Where(p => p.RelatedOriginId == i.OriginId)
                                                        .Where(p => _configuration.ItemLists.ItemLists
                                                                        .Single(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                                                                        .VisibleFields.Select(vf => vf.Name).ToList()
                                                                        .Contains(p.Name))
                                                        .Select(p => new GetItemsResponse.Property()
                                                        {
                                                            Id = p.Id,
                                                            OriginId = p.OriginId,
                                                            Name = p.Name,
                                                            Value = p.Value
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

        public GetItemResponse GetItem(GetItemRequest request)
        {
            GetItemResponse viewModel = new GetItemResponse();

            try
            {
                // If the list isn't configurated in the settings, the application will not show it
                if (!_configuration.ItemDetails.Any(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId)))
                {
                    throw new Exception(string.Format("{1}{2}", _localizationErrorKey, "DetailNotConfigurated"));
                }

                viewModel.Item = _dataContext.OR_Items
                                    .Where(i => i.OriginId.Equals(request.OriginId))
                                    .Where(i => i.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                                    .Select(i => new GetItemResponse.ItemDetails()
                                    {
                                        Id = i.Id,
                                        OriginId = i.OriginId,
                                        ItemTypeOriginId = i.ItemTypeOriginId,
                                        //CreationDate = i.CreationDate.ToString(_configuration.Date.Format),
                                        //LastEditDate = i.LastEditDate.ToString(_configuration.Date.Format),
                                        Properties = _dataContext.OR_Properties
                                                        .Where(p => p.RelatedOriginId == i.OriginId)
                                                        .Where(p => _configuration.ItemDetails
                                                                        .Single(il => il.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
                                                                        .VisibleFields.Select(vf => vf.Name)
                                                                        .ToList()
                                                                        .Contains(p.Name))
                                                        .Select(p => new GetItemResponse.Property()
                                                        {
                                                            Id = p.Id,
                                                            OriginId = p.OriginId,
                                                            Name = p.Name,
                                                            Value = p.Value
                                                        })
                                                        .OrderBy(p => p.Name)
                                                        .ToList()
                                    })
                                    .FirstOrDefault();
            }
            catch (Exception exc)
            {
                viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
                viewModel.ResultInfo.ErrorMessage = exc.Message;
            }

            return viewModel;
        }

        public Base DeleteItems(DeleteItemRequest request)
        {
            Base viewModel = new Base();

            try
            {
                // Check if there are all originIds
                bool isMissing = false;
                List<string> originIdsMissing = new List<string>();
                foreach (string originId in request.OriginIds)
                {
                    isMissing = false;
                    isMissing = !_dataContext.OR_Items
                                    .Any(i => i.OriginId.Equals(originId));
                    if(isMissing)
                    {
                        originIdsMissing.Add(originId);
                    }
                }

                if(originIdsMissing.Count > 0)
                {
                    string exceptionMessage = string.Format("The following originIds are missing in the database. Check the data: {0}", string.Join(", ", originIdsMissing.ToArray()));
                    throw new Exception(exceptionMessage);
                }
                
                foreach (string originId in request.OriginIds)
                {
                    // before delete the item, i have to delete all the item properties
                    List<OR_Property> itemProperties = _dataContext.OR_Properties
                                                            .Where(p => p.RelatedOriginId.Equals(originId))
                                                            .ToList();
                    foreach (OR_Property propertyToDelete in itemProperties) {
                        _dataContext.OR_Properties.DeleteOnSubmit(propertyToDelete);
                    }

                    // delete the item
                    OR_Item itemToDelete = _dataContext.OR_Items.Single(i => i.OriginId.Equals(originId));
                    _dataContext.OR_Items.DeleteOnSubmit(itemToDelete);
                }
                _dataContext.SubmitChanges();
                
            }
            catch (Exception exc)
            {
                viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
                viewModel.ResultInfo.ErrorMessage = exc.Message;
            }

            return viewModel;
        }

        //private Base AddLookupValue(AddLookupValueRequest lookupValue)
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

        private Base DeleteLookupValue(LookupValue lookupValue)
        {
            Base viewModel = new Base();

            try
            {

            }
            catch (Exception exc)
            {
                viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
                viewModel.ResultInfo.ErrorMessage = exc.Message;
            }

            return viewModel;
        }

        #endregion

        #region Private Methods

        private GetLookupResponse getLookup(string name)
        {
            GetLookupResponse viewModel = new GetLookupResponse();

            return viewModel;
        }

        private OR_ItemType getItemType(string name)
        {
            OR_ItemType itemType = _dataContext.OR_ItemTypes
                                    .Where(it => it.Name.Equals(name))
                                    .FirstOrDefault();
            return itemType;
        }

        #endregion
    }
}
