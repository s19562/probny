using probnyKol.DTOs.Requests;
using probnyKol.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace probnyKol.Services
{
    public class SqlServerAnimalDbService : IAnimalDbService
    {
        public void BadankoAnimal(BadankoAnimalReguest request)
        {
            //throw new NotImplementedException();
            var an = new Animal();
            an.IdAnimal = request.IdAnimal;
            //...
            //...

            using (var con = new SqlConnection(""))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    //1. Czy studia istnieja ? 
                    com.CommandText = "select IdStudies from studies where name=@name";
                    com.Parameters.AddWithValue("name", request.Name);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        tran.Rollback();
                        //return BadRequest("Studia nie istnieja");
                        //...
                    }

                    int idstudies = (int)dr["idAnimal"];

                    //x. Dodanie studenta 
                    com.CommandText = "INSERT INTO Student(IndexNumber, FirstName) VALUES(@Index , @Fname)";
                    com.Parameters.AddWithValue("Index", request.IdAnimal);
                    com.Parameters.AddWithValue("Fname", request.Name);
                    //...

                    com.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }
        }

        public void PromoteStudents(int semester, string studies)
        {
            throw new NotImplementedException(); //tutaj tez kopiujesz kod do gadania z sql
        }









    }
}
