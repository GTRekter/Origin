using System;
using System.Linq;
using Origin.Service.Models;
using Origin.Service.Implementation;
using Origin.Service.Models.Requests;
using Origin.Service.Models.Responses;
using System.Collections.Generic;

namespace Origin.Service
{
    public class FormService : IFormService
    {
        #region Private

        CacheService cacheService = new CacheService();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(FormService));

        #endregion

        #region Constructor

        public FormService()
        {
        }

        #endregion

        #region Public Methods

        public GetFormResponse GetForm(GetFormRequest request)
        {
            GetFormResponse viewModel = new GetFormResponse();

            try
            {
                OriginDataContext context = new OriginDataContext();

                // TODO: per adesso cerca solo in base al tipo, bisogna aggiungere le azioni all'item
                // ed utilizzare questa relazione per filtrare ulteriormente le form
                // N.B Questa query cambierà molto

                // Ho il tipo di item, il nome dell'azione

                var form = context.OR_ItemActions
                                .Where(ia => ia.Name.Equals(request.ActionName))
                                .Join(context.OR_ItemTypes,
                                    ia => ia.ItemTypeOriginId,
                                    it => it.OriginId,
                                    (ia, it) => new
                                    {
                                        ItemTypeName = it.Name,
                                        ItemActionFormOriginId = ia.FormOriginId
                                    })
                                .Where(f => f.ItemTypeName.Equals(request.ItemType))
                                .Join(context.OR_Forms,
                                    j => j.ItemActionFormOriginId,
                                    f => f.OriginId,
                                    (j, f) => new
                                    {
                                        Name = f.Name,
                                        OriginId = f.OriginId
                                    })
                                .FirstOrDefault();

                if (form == null)
                {
                    // TODO: l'errore dovrebbe essere letto dalle risorse
                    throw new Exception("Form non presente in configurazione. Controlla il database");
                }

                viewModel.Name = form.Name;

                viewModel.Inputs = context.OR_Inputs
                    .Where(i => i.RelatedOriginId.Equals(form.OriginId))
                    .Select(i => new GetFormResponse.Input()
                    {
                        Id = i.Id,
                        OriginId = i.OriginId,
                        Name = i.Name,
                        Type = i.Type,
                        // TODO: pensare come gestire il campo required
                        Required = "",
                        Values = i.Type.Equals("Lookup") ? GetLookupValuesByLookupName(i.Name) : null
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

        public GetLookupResponse GetLookup(string name)
        {
            GetLookupResponse viewModel = new GetLookupResponse();

            OriginDataContext context = new OriginDataContext();

            OR_Lookup lookup = context.OR_Lookups
                .Where(l => l.Name.Equals(name))
                .FirstOrDefault();

            viewModel.Name = name;

            viewModel.Values = context.OR_LookupValues
                .Where(v => v.RelatedOriginId.Equals(lookup.OriginId))
                .Select(v => v.Value);

            return viewModel;
        }

        #endregion

        #region Private Methods

        private List<string> GetLookupValuesByLookupName(string name)
        {
            List<string> values = new List<string>();

            OriginDataContext context = new OriginDataContext();

            OR_Lookup lookup = context.OR_Lookups
                .Where(l => l.Name.Equals(name))
                .FirstOrDefault();

            values = context.OR_LookupValues
                .Where(v => v.RelatedOriginId.Equals(lookup.OriginId))
                .Select(v => v.Value).ToList();

            return values;
        }

        #endregion
    }
}
