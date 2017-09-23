using System.Collections.Generic;
using System.Linq;

namespace OriginStudio
{
    public class InputManager
    {
        public List<OR_Input> GetInputsByForm(OriginDataContext dataContext, string formOriginId)
        {
            List<OR_Input> inputs = dataContext.OR_Inputs
                .Where(i => i.RelatedOriginId.Equals(formOriginId))
                .ToList();

            return inputs;
        }
    }
}
