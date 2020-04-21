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

            Hotel hotel = new Hotel(10, "testhotel", "testadresse");
            new ManageHotel().Create(hotel);
            Console.WriteLine(new ManageHotel().GetFromId(10));
            hotel.Name = "DET NYE TEST HOTEL";
            new ManageHotel().Update(hotel, 10);
            Console.WriteLine(new ManageHotel().GetFromId(10));
            new ManageHotel().Delete(10);

            List<Hotel> list = new ManageHotel().GetAll();

            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE);
            }



            Console.ReadKey();
        }
    }
}
