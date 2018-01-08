using Origin.ViewModels;
using System.Collections.Generic;

namespace Origin.ViewModels.Responses
{
    public class GetTablesResponse : Base
    {
        #region Constructor

        public GetTablesResponse()
        {
            Tables = new List<Table>();
        }

        #endregion

        public List<Table> Tables { get; set; }

        public class Table
        {
            public string Name { get; set; }

            public List<Column> Columns { get; set; }           
        }

        public class Column
        {
            public string Name { get; set; }
        }

    }
}
