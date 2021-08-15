using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int ProfRacerDrivingExp = 30;
        private const string ProfRacerRacingBehav = "strict";
        public ProfessionalRacer(string username, ICar car) 
            : base(username, ProfRacerRacingBehav, ProfRacerDrivingExp, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
