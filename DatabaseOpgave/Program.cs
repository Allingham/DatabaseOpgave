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
            //test facility
            Facility facility = new Facility(10, "testfacility", "mad");
            //Create
            new ManageFacility().Create(facility);
            //Getfromid
            Console.WriteLine(new ManageFacility().GetFromId(10));
            //ændrer en attribut i lokalt objekt
            facility.Name = "DET NYE FACILITY";
            //Update
            new ManageFacility().Update(facility, 10);
            //getfromid
            Console.WriteLine(new ManageFacility().GetFromId(10));
            //delete
            new ManageFacility().Delete(10);

            //getall
            List<Facility> list = new ManageFacility().GetAll();

            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.ReadKey();
        }
    }
}
