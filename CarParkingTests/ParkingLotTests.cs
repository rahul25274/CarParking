using CarParking;
using CarParking.Enums;
using CarParking.Models;
using NUnit.Framework;

[TestFixture]
public class ParkingLotTests
{
    private ParkingLot parkingLot;

    [SetUp]
    public void Setup()
    {
        parkingLot = new ParkingLot();
    }


    [Test]
    public void AssignParkingSlot_ValidHatchback_ReturnsSlotNumber()
    {
        int slotNumber = parkingLot.AssignParkingSlot(CarType.Hatchback);

        Assert.Greater(slotNumber, 0);
    }

    [Test]
    public void AssignParkingSlot_ValidSedanCompactSUV_ReturnsSlotNumber()
    {
        int slotNumber = parkingLot.AssignParkingSlot(CarType.SedanCompactSUV);

        Assert.Greater(slotNumber, 0);
    }

    [Test]
    public void AssignParkingSlot_ValidSUVLarge_ReturnsSlotNumber()
    {
        int slotNumber = parkingLot.AssignParkingSlot(CarType.SUVLarge);

        Assert.Greater(slotNumber, 0);
    }

    [Test]
    public void AssignParkingSlot_InvalidCarType_ReturnsNegativeOne()
    {
        int slotNumber = parkingLot.AssignParkingSlot((CarType)10); // Invalid car type

        Assert.AreEqual(slotNumber, -1);
    }

    [Test]
    public void ReleaseParkingSlot_ValidSlotNumber_ReleasesSlot()
    {
        int slotNumber = parkingLot.AssignParkingSlot(CarType.Hatchback);

        parkingLot.ReleaseParkingSlot(slotNumber);

        ParkingSlot slot = parkingLot.GetSlotByNumber(slotNumber);

        Assert.AreEqual(slot.IsOccupied, false);
    }

    [Test]
    public void ReleaseParkingSlot_InvalidSlotNumber_DoesNothing()
    {
        int invalidSlotNumber = 200;

        parkingLot.ReleaseParkingSlot(invalidSlotNumber);
    }
}