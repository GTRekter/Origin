using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Origin.Models;
using Origin.Service.Implementation;
using Origin.ViewModels;
using Origin.ViewModels.Responses;

namespace Origin.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly CacheService _cacheService;

        private readonly OriginContext _context;

        #region Constructor

        public ConfigurationController(OriginContext context, IMemoryCache cache)
        {  
            _cacheService = new CacheService(cache, ConfigurationManager.GetConfigurationByPath("Paths:Localization"));
            _context = context;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public JsonResult GetLocalizations()
        {
            var viewModel = _cacheService.GetLocalizations();
            return Json(viewModel);
        }

        [HttpGet]
        public JsonResult GetConfiguration()
        {
            var viewModel = _cacheService.GetConfiguration();
            return Json(viewModel);
        }

        [HttpGet]
        // TODO: Implement server side
        public JsonResult GetTables()
        {
            GetTablesResponse viewModel = new GetTablesResponse();

            try
            {
                if (User.IsInRole("Administrator"))
                {
                    viewModel.Tables = new List<GetTablesResponse.Table>()
                    {
                        new GetTablesResponse.Table() { Name = "OR_Forms",
                            Columns = new List<GetTablesResponse.Column> {
                                new GetTablesResponse.Column() { Name = "Name" },
                                new GetTablesResponse.Column() { Name = "Type" } } },
                        new GetTablesResponse.Table() { Name = "OR_Inputs",
                            Columns = new List<GetTablesResponse.Column> {
                                new GetTablesResponse.Column() { Name = "Name" },
                                new GetTablesResponse.Column() { Name = "Type" },
                                new GetTablesResponse.Column() { Name = "RelatedOriginId" } } },
                        new GetTablesResponse.Table() { Name = "OR_ItemTypes",
                            Columns = new List<GetTablesResponse.Column> {
                                new GetTablesResponse.Column() { Name = "Name" } } },
                        new GetTablesResponse.Table() { Name = "OR_Lookups",
                            Columns = new List<GetTablesResponse.Column> {
                                new GetTablesResponse.Column() { Name = "Name" },
                                new GetTablesResponse.Column() { Name = "Type" } } },
                        new GetTablesResponse.Table() { Name = "OR_LookupValues",
                            Columns = new List<GetTablesResponse.Column> {
                                new GetTablesResponse.Column() { Name = "Name" },
                                new GetTablesResponse.Column() { Name = "RelatedOriginId" } } },
                        new GetTablesResponse.Table() { Name = "OR_Roles",
                            Columns = new List<GetTablesResponse.Column> {
                                new GetTablesResponse.Column() { Name = "Name" } } },
                        new GetTablesResponse.Table() { Name = "OR_Users",
                            Columns = new List<GetTablesResponse.Column> {
                                new GetTablesResponse.Column() { Name = "Name" },
                                new GetTablesResponse.Column() { Name = "Surname" },
                                new GetTablesResponse.Column() { Name = "Email" },
                                new GetTablesResponse.Column() { Name = "PhoneNumber" } } },
                    };
                }
            }
            catch (Exception exc)
            {
                viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
                viewModel.ResultInfo.ErrorMessage = exc.Message;
            }

            return Json(viewModel);
        }

        [HttpPost]
        // TODO: Implement server side
        public JsonResult GetTable(string name)
        {
            //TODO: find a different way from a switch
            //GetTableResponse viewModel = new GetTableResponse();

            try
            {
                if (User.IsInRole("Administrator"))
                {
                    switch(name)
                    {
                        case "OR_Forms":
                            var forms = _context.OR_Forms.Select(f => f).ToList();
                            return Json(forms);
                            //break;
                        case "OR_Inputs":
                            break;
                        case "OR_ItemTypes":
                            break;
                        case "OR_Lookups":
                            break;
                        case "OR_LookupValues":
                            break;
                        case "OR_Roles":
                            break;
                        case "OR_Users":
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                //viewModel.ResultInfo.Result = Base.ResultInfoDto.ResultEnum.Error;
                //viewModel.ResultInfo.ErrorMessage = exc.Message;
            }

            return Json(null);
            //return Json(viewModel);
        }
        #endregion
    }
}