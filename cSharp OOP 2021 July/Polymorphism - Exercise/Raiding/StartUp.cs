using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var heroes = new List<BaseHero>();
            while (heroes.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();


                if (heroType == "Druid")
                {
                    Druid hero = new Druid(heroName);
                    heroes.Add(hero);
                }
                else if (heroType == "Paladin")
                {
                    Paladin hero = new Paladin(heroName);
                    heroes.Add(hero);
                }
                else if (heroType == "Rogue")
                {
                    Rogue hero = new Rogue(heroName);
                    heroes.Add(hero);
                }
                else if (heroType == "Warrior")
                {
                    Warrior hero = new Warrior(heroName);
                    heroes.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower = hero.Power + heroesPower;
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
