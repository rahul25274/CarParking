using CarParking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Models
{
    public class ParkingSlot
    {
        public int Number { get; set; }
        public ParkingSlotType Type { get; set; }
        public bool IsOccupied { get; set; }
    }
}
