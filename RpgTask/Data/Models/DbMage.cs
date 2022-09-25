using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTask.Data.Models
{
    public class DbMage
    {
        public int Id { get; set; }
        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Range { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
