using MarketAppClasses.Contract;
using MarketAppClasses.Entities;
using MarketAppClasses.interfaces;

namespace MarketApp.services
{

    public class RackItemLevelService
    {
        public IRackItemLevelRepository IRackItemLevelRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }
        public IItemRepository IItemRepository { get; set; }




        public void CreateAndUpdateRackItemLevel(RackItemLevelContract rackItemLevelContract)
        {
            var rackeitemlevel = IRackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackeitemlevel != null)
            {

                rackeitemlevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackeitemlevel.InQuantity = rackItemLevelContract.InQuantity;
                rackeitemlevel.OutQuantity = rackItemLevelContract.OutQuantity;
                rackeitemlevel.Item = IItemRepository.Get(rackItemLevelContract.ItemId);
                rackeitemlevel.Rack = IRackRepository.Get(rackItemLevelContract.RackId);
                IRackItemLevelRepository.Update(rackeitemlevel);

            }
            else
            {
                rackeitemlevel = new RackItemLevel();
                rackeitemlevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackeitemlevel.InQuantity = rackItemLevelContract.InQuantity;
                rackeitemlevel.OutQuantity = rackItemLevelContract.OutQuantity;
                rackeitemlevel.Item = IItemRepository.Get(rackItemLevelContract.ItemId);
                rackeitemlevel.Rack = IRackRepository.Get(rackItemLevelContract.RackId);
                IRackItemLevelRepository.Insert(rackeitemlevel);

            }
        }

        public void Delete(RackItemLevelContract rackItemLevelContract)
        {
            var rackitemlevel = IRackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackitemlevel != null)
            {
                IRackItemLevelRepository.Delete(rackitemlevel);
            }

        }


    }
}