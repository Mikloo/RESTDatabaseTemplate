using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTDatabaseTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBTempsController : ControllerBase
    {
        private static readonly string ConnectionString =
            "Server=tcp:basic1997.database.windows.net,1433;Initial Catalog=DBTemp;Persist Security Info=False;User ID=basic;Password=Polo1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public object GetDBTempById()
        {
            throw new NotImplementedException();
        }

        // GET: api/DBTemps
        [HttpGet]
        //Har returtypen IEnumerable med type of object DBTemp 
        // <> hedder type parameter
        // here’s something that when you ask it for the next element, it will figure out how to get it and then give you the element until you stop asking or there are none left
        // Kan også bare være en List under hjelmet 
        //  While kommer til at opfører sig som en foreach med IEnumerable
        public IEnumerable<DBTemp> GetAllTemp()
        {
            // Query String 
            const string selectString = "select * from dbo.DBTemp";
            // Etabler en connection til Databasen 
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                // Åbner Databasen 
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    // Executer Query String
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        // Opretter en list med typen DBTemp
                        List<DBTemp> dbTempList = new List<DBTemp>();
                        // Adder hvert obejct til listen
                        while (reader.Read())
                        {
                            DBTemp book = Read(reader);
                            dbTempList.Add(book);
                        }
                        // Returner Listen
                        return dbTempList;
                    }
                }
            }
        }

        // IDataRecord giver adgang til hver column i hver rækker
        private static DBTemp Read(IDataRecord reader)
        {
            //Får value af dens specfice kolonne
            int id = reader.GetInt32(0);
            string firstName = reader.IsDBNull(1) ? null : reader.GetString(1);
            string lastName = reader.IsDBNull(2) ? null : reader.GetString(2);
            DBTemp dbTemp = new DBTemp
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
            return dbTemp;
        }

        // GET: api/DBTemps/5
        [HttpGet("{id}")]
        public DBTemp GetDBTempById(int id)
        {
            const string selectString = "select * from DBTemp where id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows) { return null; }
                        reader.Read(); // advance cursor to first row
                        return Read(reader);
                    }
                }
            }
        }

        // POST: api/DBTemps
        [HttpPost]
        public int AddDBTemp([FromBody] DBTemp value)
        {
            const string insertString = "insert into book (FirstName, LastName) values (@firstName, @lastName)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@firstName", value.FirstName);
                    insertCommand.Parameters.AddWithValue("@lastName", value.LastName);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/DBTemps/5
        [HttpPut("{id}")]
        public int UpdateDBTemp(int id, [FromBody] DBTemp value)
        {
            const string updateString =
                "update DBTemp set FirstName=@title, LastName=@author where Id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    updateCommand.Parameters.AddWithValue("@firstName", value.FirstName);
                    updateCommand.Parameters.AddWithValue("@lastName", value.LastName);
                    updateCommand.Parameters.AddWithValue("@id", id);
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteDBTemp(int id)
        {
            const string deleteStatement = "delete from DBTemp where Id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(deleteStatement, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@id", id);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
