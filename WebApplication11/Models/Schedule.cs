using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class Schedule
    {
        public int isvykimoLaikasValandomis { get; set; }
        public int idTvarkarastis { get; set; }

        public int darboRajonoId  { get; set; }

        public string darboRajonas { get; set; }

        public int id_Kurjeris { get; set; }
        public string kurjeris { get; set; }

        public List<Workaday> darboDienos { get; set; }
    }
}
