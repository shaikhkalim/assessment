using AssessmentThinkBridge.Models;
using AssessmentThinkBridge.Repositories.Interfaces;
using AssessmentThinkBridge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentThinkBridge.Services
{
    public class IteamsServices : IItemsServices
    {
        private readonly IItemsRepositories _iItemsRepositories;

        public IteamsServices(IItemsRepositories iItemsRepositories)
        {
            _iItemsRepositories = iItemsRepositories;
        }

        
        public List<ItemModel> GetAllItems() => _iItemsRepositories.GetAllItems();

        public ItemModel GetItems(int ID) => _iItemsRepositories.GetItems(ID);

         public int Save(ItemModel item) => _iItemsRepositories.Save(item);

        public int DeleteItem(int ID) => _iItemsRepositories.DeleteItem(ID);
    }
}
