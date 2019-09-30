using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketAppClasses;
using MarketAppClasses.Entities;


namespace MArketApp
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    


                    Console.WriteLine("done");
                }

                Console.ReadKey();
            }
        }
    }
}
