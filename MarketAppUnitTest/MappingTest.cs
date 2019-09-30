using System;
using MarketAppClasses;
using MarketAppClasses.Entities;

using MArketApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Criterion;

namespace MarketAppUnitTest
{
    [TestClass]
    public class MappingTest
    {
        [TestMethod]
        public void SaveItem()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
           
                    var itemid = GetItemId();
                  
                    transaction.Commit();


                    Assert.IsNotNull(session.Get<Item>(itemid));

                }
            }
        }

        [TestMethod]
        public void SaveRack()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    Rack rack1 = new Rack
                    {
                        Code = 1,
                        Name = "jataidi",
                       Limit = 100,
                       Location = "A5",
                       

                    };
                    rack1.rack = rack1;
                    Rack rack2 = new Rack
                    {
                        Code = 2,
                        Name = "japofaki",
                        Limit = 100,
                        Location = "A6",
                        rack = rack1


                    };


                    session.Save(rack1);
                    session.Save(rack2);


                    transaction.Commit();


                    Assert.IsNotNull(session.Get<Rack>(rack1.Id));
              

                }
            }
        }




        [TestMethod]
        public void SaveRackItemLevel()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    var rackid = GetRackId();
                    Rack rack2 = session.Get<Rack>(rackid);
                    var itemid = GetItemId();
                    Item item2 = session.Get<Item>(itemid);

                    RackItemLevel ril1=new RackItemLevel
                    {
                        Item = item2,
                        Rack = rack2,
                        CurrentQuantity = 50,
                        InQuantity = 10,
                        OutQuantity = 3
                    };
                   
                    session.Save(ril1);


                    transaction.Commit();


                    Assert.IsNotNull(session.Get<RackItemLevel>(ril1.Id));

                }
            }
        }





     
        public Guid GetItemId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                   
                    Item item = new Item
                    {
                        Code = 50,
                        Name = "Pashmak",
                        Unit = Unit.Number

                    };

                    session.Save(item);


                    transaction.Commit();

                    var itemId = session.Get<Item>(item.Id);
                    return itemId.Id;



                }
            }
        }

        public Guid GetRackId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {

                    Rack rack = new Rack
                    {
                        Code = 30,
                        Limit = 30,
                        Location = "g5",
                        Name = "ja sabuni"

                    };
                    rack.rack = rack;


                    session.Save(rack);


                    transaction.Commit();

                    var rackId = session.Get<Rack>(rack.Id);
                    return rackId.Id;



                }
            }
        }
        public Guid SaleOrderItemId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {

                    var rackid = GetRackId();
                    Rack rack2 = session.Get<Rack>(rackid);
                    var itemid = GetItemId();
                    Item item2 = session.Get<Item>(itemid);
                    Rack rack = new Rack
                    {
                        Code = 30,
                        Limit = 30,
                        Location = "g5",
                        Name = "ja sabuni"

                    };
                    rack.rack = rack;

                    session.Save(rack);


                    transaction.Commit();

                    var rackId = session.Get<Rack>(rack.Id);
                    return rackId.Id;



                }
            }
        }











        [TestMethod]
        public void SaveSaleOrder()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    var rackid = GetRackId();
                    Rack rack2 = session.Get<Rack>(rackid);
                    var itemid = GetItemId();
                    Item item2 = session.Get<Item>(itemid);

                   
                 
                    
                   
             
              

                    SaleOrder so1=new SaleOrder
                    {
                        Code = 1,
                        CreationDate = DateTime.Now,
                        Title = "furush"
                    };
                    SaleOrderItem soi1=new SaleOrderItem
                    {
                        Item =item2,
                        Rack = rack2,
                        NetPrice = 50,
                        Quantity = 25,
                        TotalPrice = 150,
                        UnitPrice = 30
                    };

                   so1.SaleOrderItems.Add(soi1);
              
                   session.Save(so1);


                    transaction.Commit();


                    Assert.IsNotNull(session.Get<SaleOrderItem>(soi1.Id));

                }
            }
        }





        [TestMethod]
        public void SavePurchaseOrder()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {

                    var rackid = GetRackId();
                    Rack rack2 = session.Get<Rack>(rackid);
                    var itemid = GetItemId();
                    Item item2 = session.Get<Item>(itemid);


                   
                    PurchaseOrder po1 = new PurchaseOrder
                    {
                        Code = 1,
                        CreationDate = DateTime.Now,
                        Title = "kharid"
                    };
                    PurchaseOrderItem poi1 = new PurchaseOrderItem
                    {
                        Item = item2,
                        Rack = rack2,
                        NetPrice = 50,
                        Quantity = 25,
                        TotalPrice = 150,
                        UnitPrice = 30
                    };

                    po1.PurchaseOrderItems.Add(poi1);
                    session.Save(po1);


                    transaction.Commit();


                    Assert.IsNotNull(session.Get<PurchaseOrderItem>(poi1.Id));

                }
            }
        }




      


      

        



























    }
    

    }

