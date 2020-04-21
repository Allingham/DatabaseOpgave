using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hotel
    {
        public int Hotel_No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Hotel(int hotelNo, string name, string address)
        {
            Hotel_No = hotelNo;
            Name = name;
            Address = address;
        }

        public Hotel()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(Hotel_No)}: {Hotel_No}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
