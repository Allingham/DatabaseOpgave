using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage;
using Models;


namespace DatabaseOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            //new dbclient().Start("insert into DemoHotel values (8,'TestHotel','Testgade 21, 4000 Roskilde')");

            Facility facility = new Facility(10, "testfacility", "mad");
            new ManageFacility().Create(facility);
            Console.WriteLine(new ManageFacility().GetFromId(10));
            facility.Name = "DET NYE FACILITY";
            new ManageFacility().Update(facility, 10);
            Console.WriteLine(new ManageFacility().GetFromId(10));
            new ManageFacility().Delete(10);

            List<Facility> list = new ManageFacility().GetAll();

            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE);
            }



            Console.ReadKey();
        }
    }
}
