using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using RpgTask.Data.Models;
using RpgTask.Data.RpgDbContext;
using RpgTask.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using RpgTask.Creatures;
using RpgTask.Data.Models;

namespace RpgTask.Services
{
    public class HeroService : IHeroService
    {
        private readonly RpgTaskDbContext _context;

        public HeroService(RpgTaskDbContext context)
        {
            _context = context;            
        }

        public async Task AddNewHero(IHero hero)
        {
            var newHero = new DbHero()
            {
                Race = hero.GetType().ToString(),
                Strenght = hero.Strenght,
                Agility = hero.Agility,
                Intelligence = hero.Intelligence,
                Range = hero.Range,
                CreatedOn = DateTime.Now

            };

            await _context.Heroes.AddAsync(newHero);
            await _context.SaveChangesAsync();
        }

        //public async Task AddNewArcher(IHero archer)
        //{
        //    var newArcher = new DbArcher()
        //    {
        //        Strenght = archer.Strenght,
        //        Agility = archer.Agility,
        //        Intelligence = archer.Intelligence,
        //        Range = archer.Range,
        //        CreatedOn = DateTime.Now

        //    };

        //    await _context.Archers.AddAsync(newArcher);
        //    await _context.SaveChangesAsync();

        //}

        //public async Task AddNewMage(IHero mage)
        //{
        //    var newMage = new DbMage()
        //    {
        //        Strenght = mage.Strenght,
        //        Agility = mage.Agility,
        //        Intelligence = mage.Intelligence,
        //        Range = mage.Range,
        //        CreatedOn = DateTime.Now

        //    };

        //    await _context.Mages.AddAsync(newMage);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task AddNewWarrior(IHero warrior)
        //{
        //    var newWarrior = new DbWarrior()
        //    {
        //        Strenght = warrior.Strenght,
        //        Agility = warrior.Agility,
        //        Intelligence = warrior.Intelligence,
        //        Range = warrior.Range,
        //        CreatedOn = DateTime.Now

        //    };

        //    await _context.Warriors.AddAsync(newWarrior);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task AddNewMonster(Monster monster)
        //{
        //    var newMonster = new DbMonster()
        //    {
        //        Strenght = monster.Strenght,
        //        Agility = monster.Agility,
        //        Intelligence = monster.Intelligence,
        //        Range = monster.Range,
        //        CreatedOn = DateTime.Now

        //    };

        //    await _context.Monsters.AddAsync(newMonster);
        //    await _context.SaveChangesAsync();
        //}
    }
}
