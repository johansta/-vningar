using Microsoft.VisualStudio.TestTools.UnitTesting;
using Övning_5_Data_Access_Layer;
using Övning_5_Data_Access_Layer.Vehicles;
using System.Collections.Generic;
using System.Linq;

namespace Övning_5_UnitTest
{
    [TestClass]
    public class GarageUnitTest
    {
        IGarageRepository<Vehicle> garageRepository;
        static List<Vehicle> list; 

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            list = new List<Vehicle>();
           
        }

        [ClassCleanup]
        public static void ClassClean()
        {

        }

        [TestInitialize]
        public void TestInit(){
          
            list.Add(new Car("ABC123", FuelType.GASOLINE));
            list.Add(new Car("EFG123", FuelType.DIESEL));
            list.Add(new Boat("HIJ123", 3));
            list.Add(new Boat("KLM123", 2));
            list.Add(new Airplane("NOP123", 100));
            list.Add(new Airplane("NOP456", 42));
            list.Add(new Motorcycle("NOP789", true));
            list.Add(new Motorcycle("QRS123", false));
            list.Add(new Bus("QRS456", 66));
            list.Add(new Bus("QRS789", 90));

            garageRepository = new Gararge<Vehicle>(list.Count);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            list.Clear();
        }

        [TestMethod]
        public void TestCapacityWhenGarageIsCreated()
        {
            //Arrange 

            int expectedCapacity = 7;

            //Act
            garageRepository = new Gararge<Vehicle>(expectedCapacity);

            //Assert    

            Assert.AreEqual(expectedCapacity, garageRepository.Capacity);
        }

        [TestMethod]
        public void TestNumVehiclesIsCorrectWhenClearing()
        {
            //Arrange 

            foreach (var vehicle in list)
            {
                garageRepository.Add(vehicle);
            }
             
            //Act

            garageRepository.Clear();

            //Assert    

            Assert.AreEqual(0, garageRepository.NumVehicles);
        }

        [TestMethod]
        public void TestNumVehiclesIsCorrectWhenAdding()
        {
            //Arrange   

            //Act

            foreach (var vehicle in list)
            {
                garageRepository.Add(vehicle);
            }

            //Assert

            Assert.AreEqual(list.Count, garageRepository.NumVehicles);

        }

        [TestMethod]
        public void TestNumVehiclesIsCorrectWhenRemoving()
        {
            //Arrange   

            //Act

            foreach (var vehicle in list)
            {
                garageRepository.Add(vehicle);
            }

            garageRepository.Remove(list[0]);
            garageRepository.Remove(list[1]);
            garageRepository.Remove(list[2]);
            garageRepository.Remove(list[3]);

            int numVehiclesRemoved = 4;

            //Assert

            Assert.AreEqual(list.Count - numVehiclesRemoved, garageRepository.NumVehicles);

        }

        [TestMethod]
        public void TestIfCorrectVeichleSubInstancesPopulateTheGarageWhenAdding()
        {
            //Arrange   

            //Act

            foreach (var vehicle in list)
            {
                garageRepository.Add(vehicle);
            }

            //Assert

            int i = 0;
            foreach (var vehicle in garageRepository)
            {             
                Assert.IsInstanceOfType(vehicle, list[i].GetType());
                i++;
            }         
        }

        [TestMethod]
        public void TestIfFindByLicenseReturnsCorrectVeichle()
        {
            //Arrange

            foreach (var vehicle in list)
            {
                garageRepository.Add(vehicle);
            }

            string expectedLicense = "NOP456";

            //Act

            Vehicle veichle = garageRepository.Find(expectedLicense);

            //Assert
            Assert.IsNotNull(veichle);
            Assert.AreEqual(expectedLicense, veichle.LicensePlate);
        }

        [TestMethod]
        public void TestIfFindByAttributeReturnsCorrectVeichle()
        {
            //Arrange

            foreach (var vehicle in list)
            {
                garageRepository.Add(vehicle);
            }

            Dictionary<string, string> expectedAttributes = new Dictionary<string, string>();

            expectedAttributes.Add("LicensePlate", "QRS456");
            expectedAttributes.Add("NumberOfSeats", "66");

            //Act
            List<Vehicle> result = garageRepository.Find(expectedAttributes).ToList();
         
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            Bus bus = (Bus)result[0];

            Assert.AreEqual(expectedAttributes["LicensePlate"], bus.LicensePlate);
            Assert.AreEqual(expectedAttributes["NumberOfSeats"], bus.NumberOfSeats.ToString());
        }
    }
}
