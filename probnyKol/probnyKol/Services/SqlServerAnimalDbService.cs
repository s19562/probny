using Microsoft.AspNetCore.Mvc;
using probnyKol.DTOs.Requests;
using probnyKol.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
            an.Name = request.Name;
            an.IdOwner = request.IdOwner;
            an.NazwaBadanko = request.NazwaBadanko;
           

            //...

            String connectionS = "Data Source=db-mssql;Initial Catalog=s19562;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionS))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                

                try
                {
                    //1. Czy badanko istnieja ? 

                    com.CommandText = $"select IdProcedure from Procesja where Name=@Name";
                    com.Parameters.AddWithValue("Name", request.NazwaBadanko);
                    com.Transaction = tran;

                    using (var dr = com.ExecuteReader())
                    {
                        //dr.Read();

                        if (!dr.Read())
                        {
                            dr.Close();
                            tran.Rollback();
                            //return "Failed";
                            //...
                        }
                        else if (dr.Read())
                        {
                            int idbadanko = (int)dr["IdProcedure"];
                        }
                    }

                    /*
                    //x. Dodanie studenta 
                    com.CommandText = "INSERT INTO Student(IndexNumber, FirstName) VALUES(@Index , @Fname)";
                    com.Parameters.AddWithValue("Index", request.IdAnimal);
                    com.Parameters.AddWithValue("Fname", request.Name);
                    //...

                    com.ExecuteNonQuery();
                    */

                    //con.Close();
                    tran.Commit();
                   
                }
                catch (SqlException exc)
                {
                    throw exc;
                    //tran.Rollback();
                }
            }
        }




        public void PromoteStudents(int semester, string studies)
        {
            throw new NotImplementedException(); //tutaj tez kopiujesz kod do gadania z sql
        }









    }
}
