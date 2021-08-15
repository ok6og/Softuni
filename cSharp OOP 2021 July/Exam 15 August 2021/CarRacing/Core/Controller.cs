using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using CarRacing.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRacing.Models.Racers.Contracts;


namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != nameof(SuperCar) && type!= nameof(TunedCar))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            ICar car = default;
            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make,model,VIN,horsePower);
            }//TUNEDCAR
            else
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            this.cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);

        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar wantedVIN = this.cars.FindBy(carVIN);
            if (wantedVIN == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type != nameof(StreetRacer) && type != nameof(ProfessionalRacer))
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            IRacer racer = default;
            if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, wantedVIN);
            }//ProffesionalRacer
            else
            {
                racer = new ProfessionalRacer(username, wantedVIN);
            }
            this.racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            string raceResult = map.StartRace(racerOne, racerTwo);
            return raceResult;
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            var sortedRacers = racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username);
            foreach (IRacer racer in sortedRacers)
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})".TrimEnd());
                
            }

            return sb.ToString();

                //"{racer type}: {racer username}"
                //"--Driving behavior: {racingBehavior}"
                //"--Driving experience: {drivingExperience}"
                //"--Car: {carMake} {carModel} ({carVIN})"
        }
    }
}
