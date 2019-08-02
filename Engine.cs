using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks
{
    class Engine
    {

        //enum SegmentedFunction : byte
        //{
        //    MomentOfForce,
        //    RotationalSpeed
        //}

        //readonly short environmentTemp;
        //public double engineTemp;
        double rotationalInertia;
        int[,] segmentedFunction;
        public int this[int index1, int index2]
        {
            get { return segmentedFunction[index1,index2]; }
        }
        public double overheatTemperature;
        double heatingRateMomentOfForceRatio;
        double heatingRateRotationalSpeedRatio;
        public double coolingRateTemperatureRatio;
        //double acceleration;

        public double CoolingRateTemperatureRatio { get { return coolingRateTemperatureRatio; } }
        

        //double heatingRate;
        //double coolingRate;

        public Engine(double rotationalInertia, int[,] segmentedFunction, double overheatTemperature, double heatingRateMomentOfForceRatio, double heatingRateRotationalSpeedRatio, double coolingRateTemperatureRatio)
        {
            //this.environmentTemp = environmentTemp;
            //engineTemp = environmentTemp;
            this.rotationalInertia = rotationalInertia;
            this.segmentedFunction = segmentedFunction;
            this.overheatTemperature = overheatTemperature;
            this.heatingRateMomentOfForceRatio = heatingRateMomentOfForceRatio;
            this.heatingRateRotationalSpeedRatio = heatingRateRotationalSpeedRatio;
            this.coolingRateTemperatureRatio = coolingRateTemperatureRatio;
            //acceleration = GetAccel(0);
        }

        public double GetAccel(double MomentOfForce)
        {
           return MomentOfForce / rotationalInertia;
        }

        public int GetSegmentedFunctionSize()
        {
            return segmentedFunction.GetLength(0);
        }

        public double CalcHeatingRate(int i)
        {
            return segmentedFunction[0, i] * heatingRateMomentOfForceRatio + Math.Pow(segmentedFunction[1, i], 2) * heatingRateRotationalSpeedRatio;
        }
        //public double CalcCoolingRate(int i)
        //{
        //    return coolingRateTemperatureRatio * (environmentTemp - engineTemp);
        //}

    }
}
