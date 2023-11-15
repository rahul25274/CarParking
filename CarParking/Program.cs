using CarParking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();
            Console.WriteLine("Welcome to the Parking Lot!");

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Park a Car");
                Console.WriteLine("2. Release a Car");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        if(parkingLot.totalAvailableSlots <= 0)
                        {
                            Console.WriteLine("No parking slots are available.");
                            break;
                        }
                        Console.Write("Enter the type of car (1 for Hatchback, 2 for Sedan/Compact SUV, 3 for SUV/Large): ");
                        CarType carType = (CarType)(int.Parse(Console.ReadLine()) - 1);

                        int assignedSlot = parkingLot.AssignParkingSlot(carType);

                        if (assignedSlot != -1)
                        {
                            Console.WriteLine($"Car parked successfully. Assigned slot: {assignedSlot}");
                        }
                        break;

                    case 2:
                        Console.Write("Enter the slot number to release: ");
                        int slotToRelease = int.Parse(Console.ReadLine());
                        parkingLot.ReleaseParkingSlot(slotToRelease);
                        break;

                    case 3:
                        Console.WriteLine("Thank you for using the Parking Lot system. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
