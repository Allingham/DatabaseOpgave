using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Facility
    {
        public int Facility_Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Facility(int facilityId, string name, string type)
        {
            Facility_Id = facilityId;
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"{nameof(Facility_Id)}: {Facility_Id}, {nameof(Name)}: {Name}, {nameof(Type)}: {Type}";
        }
    }
}
