using CarParking.Enums;
using CarParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingLot
    {
        private List<ParkingSlot> slots;
        public int totalAvailableSlots = 1;
        public ParkingLot()
        {
            InitializeParkingSlots();
        }

        private void InitializeParkingSlots()
        {
            slots = new List<ParkingSlot>();

            for (int i = 1; i <= 50; i++)
            {
                slots.Add(new ParkingSlot { Number = i, Type = ParkingSlotType.Small });
            }

            for (int i = 51; i <= 80; i++)
            {
                slots.Add(new ParkingSlot { Number = i, Type = ParkingSlotType.Medium });
            }

            for (int i = 81; i <= 100; i++)
            {
                slots.Add(new ParkingSlot { Number = i, Type = ParkingSlotType.Large });
            }
        }

        public ParkingSlot GetSlotByNumber(int slotNumber)
        {
            return slots.Find(s => s.Number == slotNumber);
        }

        public int AssignParkingSlot(CarType carType)
        {
            ParkingSlot availableSlot = FindAvailableSlot(carType);

            if (availableSlot != null)
            {
                availableSlot.IsOccupied = true;
                totalAvailableSlots--;
                return availableSlot.Number;
            }
            else
            {
                Console.WriteLine("No available slot for the specified car type.");
                return -1;
            }
        }

        public void ReleaseParkingSlot(int slotNumber)
        {
            ParkingSlot slot = GetSlotByNumber(slotNumber);

            if (slot != null)
            {
                if (!slot.IsOccupied)
                    Console.WriteLine($"No car parked on slot {slotNumber}");
                else
                {
                    slot.IsOccupied = false;
                    totalAvailableSlots++;
                    Console.WriteLine($"Slot {slot.Number} has been released.");
                }
            }
            else
            {
                Console.WriteLine($"Invalid slot number {slotNumber}.");
            }
        }

        private ParkingSlot FindAvailableSlot(CarType carType)
        {
            var matchingSlots = slots.FirstOrDefault(s => !s.IsOccupied && s.Type == GetparkingType(carType));
            if (matchingSlots == null)
            {
                var slot = slots.FirstOrDefault(s => !s.IsOccupied && CanFitInSlot(carType, s.Type));
                return slot;
            }
            return matchingSlots;
        }

        ParkingSlotType? GetparkingType(CarType carType)
        {
            switch (carType)
            {
                case CarType.Hatchback:
                    return ParkingSlotType.Small;
                case CarType.SedanCompactSUV:
                    return ParkingSlotType.Medium;
                case CarType.SUVLarge:
                    return ParkingSlotType.Large;
            }
            return null;
        }

        private bool CanFitInSlot(CarType carType, ParkingSlotType slotType)
        {
            switch (carType)
            {
                case CarType.Hatchback:
                    return true;
                case CarType.SedanCompactSUV:
                    return slotType != ParkingSlotType.Small;
                case CarType.SUVLarge:
                    return slotType == ParkingSlotType.Large;
                default:
                    return false;
            }
        }
    }
}
