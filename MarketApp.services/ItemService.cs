using MarketAppClasses.Contract;
using MarketAppClasses.Entities;
using MarketAppClasses.interfaces;

namespace MarketApp.services
{
    public class ItemService
    {
        public IItemRepository IItemRepository { get; set; }


        public void CreateOrUpdate(ItemContract itemContract)
        {


            var item = IItemRepository.Get(itemContract.Id);
            if (item != null)
            {
                
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                IItemRepository.Update(item);
            }
            else
            {
                
                item = new Item();
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                IItemRepository.Insert(item);
            }

        } 
        
    }
    
    


}