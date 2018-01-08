using System.Linq;

namespace Origin.Models
{
    public static class OriginContextExtensions
    {
        /// <summary>
        /// Extension used to insert default data sinto the database
        /// </summary>
        /// <param name="context"></param>
        public static void EnsureSeedData(this OriginContext context)
        {
            if (context.AllMigrationsApplied())
            {
                // Code to insert datas
            }
        }
    }
}