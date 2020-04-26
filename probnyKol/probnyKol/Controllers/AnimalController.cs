using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using probnyKol.DAL;
using probnyKol.Models;

namespace probnyKol.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IDbService _dbService;

        public AnimalController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetAnimal(string orderBy)
        {
            using(var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19562;Integrated Security=True"))
                using(var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Animal";

                con.Open();
                var dr = com.ExecuteReader();
                var animale = new List<Animal>();

                while (dr.Read())
                {
                    var an = new Animal();
                    an.IdAnimal = (int)dr["IdAnimal"];
                    an.Name = dr["Name"].ToString();
                    an.Type = dr["Type"].ToString();
                    an.AdmissionDate = (DateTime)dr["AdmissionDate"];
                    an.IdOwner = (int)dr["IdOwner"];
                    animale.Add(an);
                }
                return Ok(animale);

            }
        }

      

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            /*if (id == 1)
            {

                return Ok("Bolek");
            }else if (id == 2)
            {
                return Ok("Pysiu");
            }

            return NotFound("Nie znaleziono zwierzoka");
            */

            using(SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19562;Integrated Security=True"))
                using(SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = $"select * from Animal where Animal.IdAnimal={id}";

                con.Open();
                var dr = com.ExecuteReader();

                dr.Read();
                string typ = (string)dr["Type"];

                return Ok(typ);
            }
        }


        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            // ... add to database 
            // ... generating index number 
            animal.IdAnimal = new Random().Next(1, 1000);
            return Ok(animal);
        }

        [HttpPut("{id}")]
        public IActionResult PutAnimal([FromRoute]int id)
        {
            return Ok("Aktualizacja zwierzoka zakonczona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal([FromRoute]int id)
        {
            return Ok("Usuwanie zakonczone");
        }

    }
}