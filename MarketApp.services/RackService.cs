using MarketAppClasses.Contract;
using MarketAppClasses.Entities;
using MarketAppClasses.interfaces;

namespace MarketApp.services
{
    public class RackService
    {
        public IRackRepository IRackRepository { get; set; }
        public void CreateOrUpdate(RackContract rackContract)
        {


            var rack = IRackRepository.Get(rackContract.Id);
            if (rack != null)
            {

       
                rack.Code = rackContract.Code;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;
                rack.Name = rackContract.Name;
                rack.rack.Id = rackContract.rackId;

                IRackRepository.Update(rack);
            }
            else
            {

                rack = new Rack();
                rack.Code = rackContract.Code;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;
                rack.Name = rackContract.Name;
                rack.rack= IRackRepository.Get(rackContract.rackId);

                IRackRepository.Insert(rack);
            }

        }

        public void Delete(RackContract rackContract)
        {
            var rack = IRackRepository.Get(rackContract.Id);
            IRackRepository.Delete(rack);
        }
    }
}