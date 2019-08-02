using System;

namespace TestTasks
{
    class Program
    {
        static void Main()
        {
            double rotationalInertia = 10;
            int[,] segmentedFunction = new int[2, 6] { { 20, 75, 100, 105, 75, 0 }, { 0, 75, 150, 200, 250, 300 } };
            double overheatTemperature = 110;
            double heatingRateMomentOfForceRatio = 0.01;
            double heatingRateRotationalSpeedRatio = 0.0001;
            double coolingRateTemperatureRatio = 0.1;
            short environmentTemp;
            Console.WriteLine("Enter environment temperature (C)");
            environmentTemp = Convert.ToInt16(Console.ReadLine());
            Engine engine1 = new Engine(rotationalInertia, segmentedFunction, overheatTemperature, heatingRateMomentOfForceRatio, heatingRateRotationalSpeedRatio, coolingRateTemperatureRatio);
            TestingStand testingStand = new TestingStand(engine1, environmentTemp);
            Console.WriteLine(testingStand.StartEngine());

            Console.ReadKey();
        }
    }
}
