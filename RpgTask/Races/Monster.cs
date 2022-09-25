using RpgTask.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTask.Races
{
    public class Monster : IHero
    {
        public int Strenght { get; set; } = new Random().Next(1, 3);
        public int Agility { get; set; } = new Random().Next(1, 3);
        public int Intelligence { get; set; } = new Random().Next(1, 3);
        public int Range { get; set; } = 1;
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public string Symbol { get; set; } = "◙";

        public void AddPoints()
        {
            throw new NotImplementedException();
        }

        public void Setup()
        {
            this.Health = this.Strenght * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }
    }
}
