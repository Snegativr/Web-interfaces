using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

class Program
{
    public class CivilAviation {
        private string aircraftName;
        public string flightNumber;
        public DateTime departureTime;
        protected string destination;
        internal double ticketPrice;
        protected internal int passangerCapacity;
        private float maxWeight;

        public CivilAviation(string aircraftName, string flightNumber, DateTime departureTime, string destination, double ticketPrice, int passengerCapacity,float maxWeight)
        {
            this.aircraftName = aircraftName;
            this.flightNumber = flightNumber;
            this.departureTime = departureTime;
            this.destination = destination;
            this.ticketPrice = ticketPrice;
            this.passangerCapacity = passengerCapacity;
            this.maxWeight = maxWeight;
        }

        public bool IsMaxWeightExceeded(float avgPassangerWeight, int numOfPassangers, float avgLuggageWeight,int numOfLuggage) {
            float total = (avgPassangerWeight * numOfPassangers) + (avgLuggageWeight * numOfLuggage);
            bool isMaxWeightExceeded = maxWeight > total;
            return isMaxWeightExceeded;
        }
        public int GetAvailableSeats(int numOfPassengers)
        {
            return passangerCapacity - numOfPassengers;
        }
        public double GetTotalCost(int numOfPassengers)
        {
            return ticketPrice * numOfPassengers;
        }
    }


    static async Task Main()
    {
        CivilAviation air1 = new CivilAviation("Boeing 737", "BA123", new DateTime(2024, 2, 28, 8, 0, 0), "London", 250.50, 200, 15000.0f);
        Type type1 = typeof(CivilAviation);
        TypeInfo typeInfo1 = type1.GetTypeInfo();
        Console.WriteLine(type1);
        Console.WriteLine(typeInfo1 + "\n");

        MemberInfo[] members = type1.GetMembers();
        foreach (MemberInfo member in members)
        {
            Console.WriteLine($"Member name: {member.Name}, Member type: {member.MemberType}");
        }

        Console.WriteLine("\n");

        FieldInfo[] fields = type1.GetFields();
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine($"Field name: {field.Name}, Field type: {field.FieldType}");
        }

        Console.WriteLine("\n");

        MethodInfo methodInfo = type1.GetMethod("IsMaxWeightExceeded");
        Console.WriteLine(methodInfo);

        object[] args = new object[] {60.3f,100,20.1f,100};
        Console.WriteLine(methodInfo.Invoke(air1, args));
    }
}
