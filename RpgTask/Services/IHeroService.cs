using RpgTask.Creatures;
using RpgTask.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTask.Services
{
    public interface IHeroService
    {
        public Task AddNewHero(IHero hero);

        //public Task AddNewArcher(IHero archer);
        //public Task AddNewWarrior(IHero warrior);
        //public Task AddNewMage(IHero mage);
        //public Task AddNewMonster(Monster monster);
    }
}
