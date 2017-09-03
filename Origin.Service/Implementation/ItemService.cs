using System;
using System.Linq;
using Origin.Service.Models;
using Origin.Service.Implementation;
using Origin.Service.Models.Elements;
using Origin.Service.Models.Requests;
using Origin.Service.Models.Responses;
using System.Collections.Generic;

namespace Origin.Service
{
    public class ItemService : IItemService
    {
        #region Private

        CacheService cacheService = new CacheService();

        private OriginDataContext _dataContext;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ItemService));

        #endregion

        #region Constructor

        public ItemService()
        {
            _dataContext = new OriginDataContext();
        }

        #endregion

        #region Public Methods

        public Base AddItem(AddItemRequest request)
        {
            Base viewModel = new Base();

            try
            {
                // Prendo l'originId del tipo di item
                OR_ItemType itemType = GetItemType(request.ItemType);

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

        public Base DeleteItem(Item request)
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

        public GetItemsResponse GetItems(GetItemsRequest request)
        {
            GetItemsResponse viewModel = new GetItemsResponse();

            try
            {
                // Prendo l'originId del tipo di item
                OR_ItemType itemType = GetItemType(request.ItemsType);

                var viewedItems = request.CurrentPage * request.ItemsPerPage;

                viewModel.Items = _dataContext.OR_Items
                                    .OrderByDescending(i => i.CreationDate)
                                    .Skip(viewedItems).Take(request.ItemsPerPage)
                                    .Where(i => i.ItemTypeOriginId.Equals(itemType.OriginId))
                                    .Select(i => new GetItemsResponse.Item() {
                                        Id = i.Id,
                                        OriginId = i.OriginId,
                                        ItemTypeOriginId = i.ItemTypeOriginId,
                                        // TODO: Aggiungere formato della data in configurazione
                                        CreationDate = "",
                                        //CreationDate = i.CreationDate.ToString("YYYY"),
                                        LastEditDate = "",
                                        //LastEditDate = i.LastEditDate.ToString("YYYY"),
                                        Properties = _dataContext.OR_Properties
                                            .Where(p => p.RelatedOriginId == i.OriginId)
                                            .Select(p => new GetItemsResponse.Property() {
                                                Id = p.Id,
                                                OriginId = p.OriginId,
                                                Name = p.Name,
                                                // TODO: inserire localizzazione nel file delle risorse,
                                                // in poche parole andra a cercare una chiave che corrisponde al nome della proprietà
                                                DisplayName = "",
                                                Value = p.Value
                                            })
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

        public GetFormResponse GetForm(GetFormRequest request)
        {
            GetFormResponse viewModel = new GetFormResponse();

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

        private GetLookupResponse GetLookup(string name)
        {
            GetLookupResponse viewModel = new GetLookupResponse();

            return viewModel;
        }

        private OR_ItemType GetItemType(string name)
        {
            OR_ItemType itemType = _dataContext.OR_ItemTypes
                                    .Where(it => it.Name.Equals(name))
                                    .FirstOrDefault();
            return itemType;
        }

        #endregion
    }
}
