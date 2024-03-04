using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddManyPeople.Data
{
    public class PeopleDb
    {
        private string _conStr;

        public PeopleDb(string conStr)
        {
            _conStr = conStr;
        }

        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_conStr);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            var ppl = new List<Person>();
            while (reader.Read())
            {
                ppl.Add(new()
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return ppl;
        }

        public void AddPerson(Person p)
        {
            using var connection = new SqlConnection(_conStr);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO People (FirstName, LastName, Age)
                                VALUES (@first, @last, @age)";

            cmd.Parameters.AddWithValue("@first", p.FirstName);
            cmd.Parameters.AddWithValue("@last", p.LastName); 
            cmd.Parameters.AddWithValue("@age", p.Age);

            connection.Open();

            cmd.ExecuteNonQuery();
        }

        public void AddManyPeople(List<Person> ppl)
        {
            foreach(var p in ppl)
            {
                AddPerson(p);
            }
        }
    }
}
