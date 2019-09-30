using System;
using System.Linq;
using MarketAppClasses.Contract;
using MarketAppClasses.Entities;
using MarketAppClasses.interfaces;
namespace MarketApp.services
{
    public class SaleOrederService
    {
        private ISaleOrderRepository ISaleOrderRepository { get; set; }
        private IItemRepository IItemRepository { get; set; }
        private IRackRepository IRackRepository { get; set; }



        public void CreateOrUpdate(SaleOrderContract saleOrderContract)
        {
            var SaleOrder = ISaleOrderRepository.Get(saleOrderContract.Id);

            if (SaleOrder != null)
            {
                SaleOrder.CreationDate = DateTime.Now;
                SaleOrder.Title = saleOrderContract.Title;
                SaleOrder.Code = saleOrderContract.Code;

                for (int i = 0; i < saleOrderContract.SaleOrderItems.Count; i++)
                {
                    var temp = saleOrderContract.SaleOrderItems[i];
                    if (SaleOrder.SaleOrderItems.Any(p => p.Id == temp.Id))
                    {
                        var Sorderitem = SaleOrder.SaleOrderItems.FirstOrDefault(p => p.Id == temp.Id);

                        Sorderitem.Quantity = temp.Quantity;

                        Sorderitem.NetPrice = temp.NetPrice;
                        Sorderitem.TotalPrice = temp.TotalPrice;
                        Sorderitem.UnitPrice = temp.UnitPrice;
                        Sorderitem.Item = IItemRepository.Get(temp.ItemId);
                        Sorderitem.Rack = IRackRepository.Get(temp.RackId);

                    }


                    else
                    {

                        var Sorderitem = new SaleOrderItem();
                        Sorderitem.Quantity = temp.Quantity;

                        Sorderitem.NetPrice = temp.NetPrice;
                        Sorderitem.TotalPrice = temp.TotalPrice;
                        Sorderitem.UnitPrice = temp.UnitPrice;
                        Sorderitem.Item = IItemRepository.Get(temp.ItemId);
                        Sorderitem.Rack =IRackRepository.Get(temp.RackId);
                        SaleOrder.SaleOrderItems.Add(Sorderitem);
                    }


                }

                foreach (var item in SaleOrder.SaleOrderItems)
                {
                  
                    if (!saleOrderContract.SaleOrderItems.Any(p => p.Id == item.Id))
                    {

                        SaleOrder.SaleOrderItems.Remove(item);
                    }
                }

                ISaleOrderRepository.Update(SaleOrder);
            }
            else
            {
                 SaleOrder=new SaleOrder();
                SaleOrder.CreationDate = saleOrderContract.CreationDate;
                SaleOrder.Title = saleOrderContract.Title;
                SaleOrder.Code = saleOrderContract.Code;

                for (int i = 0; i < saleOrderContract.SaleOrderItems.Count; i++)
                {
                    var temp = saleOrderContract.SaleOrderItems[i];
                    var Sorderitem = new SaleOrderItem();

                        Sorderitem.NetPrice = temp.NetPrice;
                        Sorderitem.TotalPrice = temp.TotalPrice;
                        Sorderitem.UnitPrice = temp.UnitPrice;
                        Sorderitem.Item = IItemRepository.Get(temp.ItemId);
                        Sorderitem.Rack = IRackRepository.Get(temp.RackId);
                        SaleOrder.SaleOrderItems.Add(Sorderitem);
                }

                ISaleOrderRepository.Insert(SaleOrder);
            }
        }



    }
}