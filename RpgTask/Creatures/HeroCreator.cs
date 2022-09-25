using RpgTask.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTask.Creatures
{
    public class HeroCreator
    {
        public static IHero getHero(String Type)
        {
            IHero ObjectType = null;
            if (Type.ToLower().Equals("warrior"))
            {
                ObjectType = new Warrior();
            }
            else if (Type.ToLower().Equals("archer"))
            {
                ObjectType = new Archer();
            }
            else if (Type.ToLower().Equals("mage"))
            {
                ObjectType = new Mage();
            }
            else if (Type.ToLower().Equals("monster"))
            {
                ObjectType = new Monster();
            }
            ObjectType.Setup();
            return ObjectType;
        }
    }
}
