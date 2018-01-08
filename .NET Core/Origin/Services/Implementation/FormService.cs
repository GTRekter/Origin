using System;
using System.Linq;
using System.Collections.Generic;
using Origin.ViewModel.Elements;
using Origin.ViewModels.Requests;
using Origin.ViewModels.Responses;

namespace Origin.Service.Implementation
{
    class FormService
    {
        //#region Private

        //private OriginDbContext _dataContext;

        //#endregion

        //#region Constructor

        //public FormService()
        //{
        //    _dataContext = new OriginDbContext();
        //}

        //#endregion

        //#region Public Methods

        //public GetFormResponse GetForm(GetFormRequest request)
        //{
        //    GetFormResponse viewModel = new GetFormResponse();

        //    try
        //    {
        //        // TODO: per adesso cerca solo in base al tipo, bisogna aggiungere le azioni all'item
        //        // ed utilizzare questa relazione per filtrare ulteriormente le form
        //        // N.B Questa query cambierà molto

        //        // Ho il tipo di item, il nome dell'azione

        //        var form = _dataContext.OR_ItemActions
        //                        .Where(ia => ia.Name.Equals(request.ActionName))
        //                        //.Join(context.OR_ItemTypes,
        //                        //    ia => ia.ItemTypeOriginId,
        //                        //    it => it.OriginId,
        //                        //    (ia, it) => new
        //                        //    {
        //                        //        ItemTypeName = it.Name,
        //                        //        ItemActionFormOriginId = ia.FormOriginId
        //                        //    })
        //                        //.Where(f => f.ItemTypeName.Equals(request.ItemType))
        //                        .Where(ia => ia.ItemTypeOriginId.Equals(request.ItemTypeOriginId))
        //                        .Join(_dataContext.OR_Forms,
        //                            j => j.FormOriginId,
        //                            f => f.OriginId,
        //                            (j, f) => new
        //                            {
        //                                Name = f.Name,
        //                                OriginId = f.OriginId
        //                            })
        //                        .FirstOrDefault();

        //        if (form == null)
        //        {
        //            // TODO: l'errore dovrebbe essere letto dalle risorse
        //            throw new Exception("Form non presente in configurazione. Controlla il database");
        //        }

        //        viewModel.Name = form.Name;

        //        viewModel.Inputs = _dataContext.OR_Inputs
        //            .Where(i => i.RelatedOriginId.Equals(form.OriginId))
        //            .Select(i => new GetFormResponse.Input()
        //            {
        //                Id = i.Id,
        //                OriginId = i.OriginId.ToString(),
        //                Name = i.Name,
        //                Type = i.Type,
        //                // TODO: pensare come gestire il campo required
        //                Required = "",
        //                Values = i.Type.Equals("Lookup") ? GetLookupValuesByLookupName(i.Name) : null
        //            })
        //            .ToList();
        //    }
        //    catch (Exception exc)
        //    {
        //        viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
        //        viewModel.ResultInfo.ErrorMessage = exc.Message;
        //    }

        //    return viewModel;
        //}

        //public GetLookupResponse GetLookup(string name)
        //{
        //    GetLookupResponse viewModel = new GetLookupResponse();

        //    OriginDbContext context = new OriginDbContext();

        //    OR_Lookup lookup = context.OR_Lookups
        //        .Where(l => l.Name.Equals(name))
        //        .FirstOrDefault();

        //    viewModel.Name = name;

        //    viewModel.Values = context.OR_LookupValues
        //        .Where(v => v.RelatedOriginId.Equals(lookup.OriginId))
        //        .Select(v => v.Value);

        //    return viewModel;
        //}

        //#endregion

        //#region Private Methods

        //private List<string> GetLookupValuesByLookupName(string name)
        //{
        //    List<string> values = new List<string>();

        //    OR_Lookup lookup = _dataContext.OR_Lookups
        //        .Where(l => l.Name.Equals(name))
        //        .FirstOrDefault();

        //    values = _dataContext.OR_LookupValues
        //        .Where(v => v.RelatedOriginId.Equals(lookup.OriginId))
        //        .Select(v => v.Value).ToList();

        //    return values;
        //}

        //#endregion
    }
}
