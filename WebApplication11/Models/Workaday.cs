using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class Workaday
    {
        public DateTime Data { get; set; }

        public int id_Darbo_diena { get; set; }

        public int fk_Tvarkarastis { get; set; }

        public List<ParcelTerminal> dienosPastomatai { get; set; }



    }
}
