using System.Collections.Generic;
using System.Linq;

namespace OriginStudio
{
    class FormManager
    {
        public IEnumerable<OR_Form> GetForms(OriginDataContext dataContext)
        {
            IEnumerable<OR_Form> forms = dataContext.OR_Forms;

            return forms;
        }

        public OR_Form GetForm(OriginDataContext dataContext, string formOriginId)
        {
            OR_Form form = dataContext.OR_Forms
                .Where(f => f.OriginId.Equals(formOriginId))
                .FirstOrDefault();

            return form;
        }
    }
}
