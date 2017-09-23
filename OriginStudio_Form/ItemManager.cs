using System.Collections.Generic;
using System.Linq;

namespace OriginStudio
{
    public class ItemManager
    {
        public List<OR_ItemType> GetItemTypes(OriginDataContext dataContext)
        {
            List<OR_ItemType> itemTypes = dataContext.OR_ItemTypes
                .ToList();

            return itemTypes;
        }

        public OR_ItemType GetItemType(OriginDataContext dataContext, string itemTypeOriginId)
        {
            OR_ItemType itemType = dataContext.OR_ItemTypes
                .Where(f => f.OriginId.Equals(itemTypeOriginId))
                .FirstOrDefault();

            return itemType;
        }

        public List<OR_ItemAction> GetItemActionsByItemType(OriginDataContext dataContext, string itemTypeOriginId)
        {
            List<OR_ItemAction> itemActions = dataContext.OR_ItemActions
                .Where(f => f.ItemTypeOriginId.Equals(itemTypeOriginId))
                .ToList();

            return itemActions;
        }


    }
}
