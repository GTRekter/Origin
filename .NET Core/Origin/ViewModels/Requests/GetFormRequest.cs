﻿using Origin.ViewModels;

namespace Origin.ViewModels.Requests
{
    public class GetFormRequest : Base
    {
        public string ActionName { get; set; }

        public string ItemTypeOriginId { get; set; }
    }
}
