using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        List<Ski> skis;

        public SkiRental(string name, int capacity )
        {
            Name = name;
            Capacity = capacity;
            skis = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get;}
        public int Count => skis.Count;


        public void Add(Ski ski)
        {
            if (Capacity > Count)
            {
                skis.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isExisting = skis.Exists(x => x.Manufacturer == manufacturer && x.Model == model);
            if (isExisting)
            {
                skis.Remove(skis.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));
            }
            return isExisting;
        }

        public Ski GetNewestSki() => skis.OrderByDescending(x => x.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model) => skis.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in skis)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
