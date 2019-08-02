using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks
{
    class TestingStand
    {
        public Engine engine;
        public short environmentTemp;
        double engineTemp;
        int SegmentIndex;
        double MomentOfForce;
        double RotationalSpeed;

        public TestingStand(Engine engine, short envTemp)
        {
            environmentTemp = envTemp;
            engineTemp = environmentTemp;
            this.engine = engine;
            SegmentIndex = 0;
            MomentOfForce = engine[0, SegmentIndex];
            RotationalSpeed = engine[1, SegmentIndex];
        }

        public double CalcCoolingRate(double engineTemp)
        {
            return engine.CoolingRateTemperatureRatio * (environmentTemp - engineTemp);
        }

        public uint StartEngine()
        {
            uint counter = 0;
            double accel = engine.GetAccel(MomentOfForce);

            while (engineTemp < engine.overheatTemperature)
            {
                counter++;
                RotationalSpeed += accel;
                if (SegmentIndex < engine.GetSegmentedFunctionSize() - 1)
                {
                    if (RotationalSpeed >= engine[1, SegmentIndex + 1])
                    {
                        SegmentIndex++;
                    }
                }

                //if (RotationalSpeed >= engine[1, engine.GetSegmentedFunctionSize() - 1])
                if (counter==2500)
                {
                    Console.WriteLine("Test aborted at [0] second, engine not overheated", counter);
                    return counter;
                }

                MomentOfForce = (engine[1, SegmentIndex] * (engine[0, SegmentIndex + 1] - RotationalSpeed) + engine[1, SegmentIndex + 1] * (RotationalSpeed - engine[0, SegmentIndex])) / (engine[0, SegmentIndex + 1] - engine[0, SegmentIndex]);
                engineTemp += engine.CalcHeatingRate(SegmentIndex) + CalcCoolingRate(SegmentIndex);

                accel = engine.GetAccel(MomentOfForce);

            }
            return counter;
        }
    }
}
