using AssessmentThinkBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentThinkBridge.Repositories.Interfaces
{
    public interface IItemsRepositories
    {
        List<ItemModel> GetAllItems();

        ItemModel GetItems(int ID);

        int Save(ItemModel itemModel);

        int DeleteItem(int ID);
    }
}
