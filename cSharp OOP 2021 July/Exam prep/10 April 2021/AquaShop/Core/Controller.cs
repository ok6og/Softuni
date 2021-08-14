using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums;
        private DecorationRepository decorations;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            IAquarium aquarium = default;

            if (aquariumType== "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded,aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidCastException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = default;
            if (decorationType=="Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }
            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration desiredDecoration = this.decorations.FindByType(decorationType);
            if (desiredDecoration is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            this.decorations.Remove(desiredDecoration);
            IAquarium desiredAquarium =this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            desiredAquarium.AddDecoration(desiredDecoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(SaltwaterFish) && fishType!= nameof(FreshwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish;
            IAquarium desiredAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            
            if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (desiredAquarium.GetType().Name != nameof(SaltwaterAquarium))
                {
                    return  (OutputMessages.UnsuitableWater);
                }
            }
            else
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (desiredAquarium.GetType().Name != nameof(FreshwaterAquarium))
                {
                    return (OutputMessages.UnsuitableWater);
                }
            }
            desiredAquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

            

        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sumOfDecorations = aquarium.Decorations.Sum(x => x.Price);
            decimal sumOfFishes = aquarium.Fish.Sum(x => x.Price);
            decimal totalPrice = sumOfDecorations + sumOfFishes;

            return string.Format(OutputMessages.AquariumValue,aquariumName, totalPrice);
        }

             
        public string Report()
        {
            StringBuilder bobTheBuilder = new StringBuilder();

            foreach (IAquarium aq in aquariums)
            {
                bobTheBuilder.Append(aq.GetInfo());
            }

            return bobTheBuilder.ToString().TrimEnd();
        }
    }
}
