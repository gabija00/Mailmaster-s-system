using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Models;
using MySqlConnector;

namespace WebApplication11.Controllers
{
    /*Kai sukuriam tvarkarastyje diena, automatiskai turi buti sukurtas ir kelias kuris susideda is bent vienos atkarpos
         * atkarpa randama suradus atsuma db atitinkanti ieskoma atstuma tarp dvieju pastomatu
         * 
         * atstumai i db suvesti rankiniu budu
         * 
         *tvarkarasciui priklauso darbo diena
         * darbo dienai priklauso kelias
         * o keliui priklauso atkarpa
         * 
         * edite bus galima prideti pastomata prie dienos
         * sukuriant diena reikes prideti bent viena pastomata
                
         */
    public class ScheduleController : Controller
    {
        List<DeliveryMan> deliveryMen = new List<DeliveryMan>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WorkerPage()
        {
            
            List<int> ids = new List<int>();

            using (MySqlConnection con = new MySqlConnection("server=remotemysql.com;user=tbqJGERM9k;password=sE8OhWskeG;database=tbqJGERM9k;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Kurjeris", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = 0;
                    id = Convert.ToInt32(reader["id_Klientas"]);
                    ids.Add(id);
                }
                reader.Close();
                for (int i = 0; i < ids.Count; i++)
                {
                    MySqlCommand cmdd = new MySqlCommand("SELECT * FROM Klientas  WHERE id_Klientas='" + ids[i] + "'", con);
                    MySqlDataReader readerr = cmdd.ExecuteReader();

                    while (readerr.Read())
                    {
                        DeliveryMan terminalas = new DeliveryMan();
                        terminalas.id = i + 1;
                        terminalas.prisijungimoVardas = readerr["prisijungimoVardas"].ToString();
                        terminalas.slaptazodis = readerr["slaptazodis"].ToString();
                        terminalas.telNr = readerr["telNr"].ToString();
                        terminalas.ePastas = readerr["ePastas"].ToString();

                        deliveryMen.Add(terminalas);
                    }
                    readerr.Close();

                }
            }
            return View(deliveryMen);
        }
        public ActionResult ScheduleEditPage(int id)
        {

            Schedule sched = new Schedule();

            using (MySqlConnection con = new MySqlConnection("server = remotemysql.com; user = tbqJGERM9k; password = sE8OhWskeG; database = tbqJGERM9k; "))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tvarkarastis WHERE fk_Kurjerisid_Klientas='" + id + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sched.darboRajonoId = Convert.ToInt32(reader["darboRajonas"]);
                    sched.isvykimoLaikasValandomis = Convert.ToInt32(reader["isvykimoLaikasValandomis"]);
                    sched.idTvarkarastis = Convert.ToInt32(reader["id_Tvarkarastis"]);
                    sched.id_Kurjeris = Convert.ToInt32(reader["fk_Kurjerisid_Klientas"]);
                }
                reader.Close();

                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM Rajonai WHERE id_Rajonai='" + sched.darboRajonoId + "'", con);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                //truksta darbo rajono reiksmes ir kurjerio vardo reikmsmes

                while (reader2.Read())
                {
                    sched.darboRajonas = reader2["name"].ToString();
                }
                reader2.Close();

                MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM Klientas WHERE id_Klientas='" + sched.id_Kurjeris + "'", con);
                MySqlDataReader reader3 = cmd3.ExecuteReader();
                //truksta darbo rajono reiksmes ir kurjerio vardo reikmsmes

                while (reader3.Read())
                {
                    sched.kurjeris = reader3["prisijungimoVardas"].ToString();
                }
                reader3.Close();
            }

            return View(sched);
        }
        [HttpPost]
        public ActionResult ScheduleEditPage(string id, Schedule tterminal)
        {
            

            return RedirectToAction("Index");



        }

        public void FindOptimalCourse()
        {
            //reiks listo visu priskirtu kurjeriui pastomatu saraso
            //pasirinkti pirma sarase esanti pastomata
            //*teks perrasyti optimalaus kelio paieskos diagrama

        }

        /*Kai sukuriam tvarkarastyje diena, automatiskai turi buti sukurtas ir kelias kuris susideda is bent vienos atkarpos
         * atkarpa randama suradus atsuma db atitinkanti ieskoma atstuma tarp dvieju pastomatu
         * 
         * atstumai i db suvesti rankiniu budu
         * 
         *tvarkarasciui priklauso darbo diena
         * darbo dienai priklauso kelias
         * o keliui priklauso atkarpa
         * 
         * edite bus galima prideti pastomata prie dienos
         * sukuriant diena reikes prideti bent viena pastomata
                
         */
    }
}
