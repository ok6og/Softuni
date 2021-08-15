using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            double chanceOfWinningOne = 0;
            double chanceOfWinningTwo = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
            } 
            else //aggresive
            {
                chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
            }
            else //aggresive
            {
                chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
            }
            bool isReadyOne = racerOne.IsAvailable();            
            bool isReadyTwo = racerTwo.IsAvailable();

            if (isReadyOne == false && isReadyTwo == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (isReadyOne == true && isReadyTwo == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (isReadyOne == false && isReadyTwo == true)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else//both available
            {
                racerOne.Race();
                racerTwo.Race();
                if (chanceOfWinningOne > chanceOfWinningTwo)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
                }
                
            }

            //MAYBE A BUG SOMEWHERE
        }
    }
}
