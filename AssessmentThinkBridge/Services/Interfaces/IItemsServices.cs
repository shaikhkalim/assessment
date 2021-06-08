using AssessmentThinkBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentThinkBridge.Services.Interfaces
{
    public interface IItemsServices
    {
        List<ItemModel> GetAllItems();

        ItemModel GetItems(int ID);

        int Save(ItemModel itemModel);

        int DeleteItem(int ID);
    }
}
