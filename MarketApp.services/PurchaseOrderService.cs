using System;
using System.Linq;
using MarketAppClasses.Contract;
using MarketAppClasses.Entities;
using MarketAppClasses.interfaces;

namespace MarketApp.services
{
    public class PurchaseOrderServices
    {
        private IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }
        private IItemRepository IItemRepository { get; set; }
        private IRackRepository IRackRepository { get; set; }



        public void CreateOrUpdate(PurchaseOrderContract purchaseOrderContract)
        {
            var PurchaseOrder = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);

            if (PurchaseOrder != null)
            {
                PurchaseOrder.CreationDate = DateTime.Now;
                PurchaseOrder.Title = purchaseOrderContract.Title;
                PurchaseOrder.Code = purchaseOrderContract.Code;

                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItems[i];
                    if (PurchaseOrder.PurchaseOrderItems.Any(p => p.Id == temp.Id))
                    {
                        var Porderitem = PurchaseOrder.PurchaseOrderItems.FirstOrDefault(p => p.Id == temp.Id);

                        Porderitem.Quantity = temp.Quantity;
                       
                        Porderitem.NetPrice = temp.NetPrice;
                        Porderitem.TotalPrice = temp.TotalPrice;
                        Porderitem.UnitPrice = temp.UnitPrice;
                        Porderitem.Item = IItemRepository.Get(temp.ItemId);
                        Porderitem.Rack= IRackRepository.Get(temp.RackId);

                    }


                    else
                    {

                        var Porderitem = new PurchaseOrderItem();
                        Porderitem.Quantity = temp.Quantity;

                        Porderitem.NetPrice = temp.NetPrice;
                        Porderitem.TotalPrice = temp.TotalPrice;
                        Porderitem.UnitPrice = temp.UnitPrice;
                        Porderitem.Item = IItemRepository.Get(temp.ItemId);
                        Porderitem.Rack = IRackRepository.Get(temp.RackId);
                        PurchaseOrder.PurchaseOrderItems.Add(Porderitem);
                    }


                }

                foreach (var item in PurchaseOrder.PurchaseOrderItems)
                {
                   
                    if (!purchaseOrderContract.PurchaseOrderItems.Any(p => p.Id == item.Id))
                    {

                         PurchaseOrder.PurchaseOrderItems.Remove(item);
                    }
                 }

                      IPurchaseOrderRepository.Update(PurchaseOrder);
            }

     

            else
            {
                PurchaseOrder=new PurchaseOrder();
                PurchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                PurchaseOrder.Title = purchaseOrderContract.Title;
                PurchaseOrder.Code = purchaseOrderContract.Code;

                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItems[i];
                    var Porderitem=new PurchaseOrderItem();
                        Porderitem.NetPrice = temp.NetPrice;
                        Porderitem.TotalPrice = temp.TotalPrice;
                        Porderitem.UnitPrice = temp.UnitPrice;
                        Porderitem.Item = IItemRepository.Get(temp.ItemId);
                        Porderitem.Rack = IRackRepository.Get(temp.RackId);
                        PurchaseOrder.PurchaseOrderItems.Add(Porderitem);
                    
                }

                IPurchaseOrderRepository.Insert(PurchaseOrder);
            }
        }

        public void Delete(PurchaseOrderContract purchaseOrderContract)
        {
            var PurchaseOrderContract = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);

            IPurchaseOrderRepository.Delete(PurchaseOrderContract);
        }

    }
}