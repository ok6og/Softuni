using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int StreetRacerDrivingExp = 10;
        private const string StreetRacerRacingBehav = "aggressive";
       
        public StreetRacer(string username, ICar car) 
            : base(username, StreetRacerRacingBehav, StreetRacerDrivingExp, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
