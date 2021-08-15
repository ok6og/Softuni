using System;
using System.Collections.Generic;
using System.Text;


namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double TunedCarFuelAvailable = 65;
        private const double TunedCarConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, TunedCarFuelAvailable, TunedCarConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            //MAYBE A BUG
            HorsePower = (int)Math.Round(HorsePower * 0.97);
        }
    }
}
