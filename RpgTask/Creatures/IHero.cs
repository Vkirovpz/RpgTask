using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTask.Creatures
{
    public interface IHero
    {
        public int Strenght { get; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Range { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public string Symbol { get; set; }

        public void Setup();
        public void AddPoints();


    }
}
