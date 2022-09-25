using RpgTask.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTask.Races
{
    public class Archer : IHero
    {
        public int Strenght { get; set; } = 2;
        public int Agility { get; set; } = 4;
        public int Intelligence { get; set; } = 0;
        public int Range { get; set; } = 2;
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public string Symbol { get; set; } = "#";
        public int Row { get; set; } = 1;
        public int Col { get; set; } = 1;

        public void AddPoints()
        {
            static void PrintAddPointsSb(int points)
            {
                var responseY = new StringBuilder();
                responseY.AppendLine($"Remaining Points:{points}");
                responseY.AppendLine("Add to Strenght: ");
                responseY.AppendLine("Add to Agility: ");
                responseY.AppendLine("Add to Intelligence: ");
                Console.WriteLine(responseY.ToString());
            }
            var remainingPoints = 3;
            for (int i = 0; i <= remainingPoints; i++)
            {
                PrintAddPointsSb(remainingPoints);

                var pointRequest = Console.ReadLine().ToLower().Split(":").ToArray();
                Console.Clear();
                var pointsToAdd = int.Parse(pointRequest[1]);
                if (pointsToAdd <= remainingPoints)
                {
                    if (pointRequest[0] == "add to strenght")
                    {
                        this.Strenght += pointsToAdd;
                        remainingPoints -= pointsToAdd;
                    }
                    else if (pointRequest[0] == "add to agility")
                    {
                        this.Agility += pointsToAdd;
                        remainingPoints -= pointsToAdd;
                    }
                    else if (pointRequest[0] == "add to intelligence")
                    {
                        this.Intelligence += pointsToAdd;
                        remainingPoints -= pointsToAdd;
                    }
                }
                else
                {
                    i--;
                    continue;
                }
            }
        }

        public void Setup()
        {
            this.Health = this.Strenght * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }

    }
}
