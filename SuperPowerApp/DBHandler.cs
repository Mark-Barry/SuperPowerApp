using SuperPowerApp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPowerApp
{
    class DBHandler
    {
        private String connectionString;
        private SqlConnection dbConnection;

        public DBHandler() {
            this.connectionString = @"Data Source=AzureAD\IanGleeson;Initial Catalog=Demodb;User ID=sa;Password=hello12345";
            this.dbConnection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                this.dbConnection.Open();
            }
            catch (SqlException exp)
            {
                Console.WriteLine("SQL Exception:",exp);
                throw new InvalidOperationException("Data could not be read", exp);
            }
        }

        public void CloseConnection() {
            this.dbConnection.Close();
        }

        //Deleting character
        public Boolean DeleteSuperCharacter(int characterID) {
            using (SqlCommand command = dbConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM dbo.Superhero,dbo.Background,dbo.SuperheroAbility,dbo.SuperheroRegion WHERE SuperheroID == @param";
                command.Parameters.AddWithValue("@param", characterID);

                int result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        //Reading character from db
        public Superhero ReadSuperCharacter(int characterID) {
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandText = "SELECT SuperheroID,AffinityID,Name FROM Superhero WHERE SuperheroID == @param";
            command.Parameters.AddWithValue("@param", characterID);
            SqlDataReader reader = command.ExecuteReader();
            Superhero superhero = new Superhero();
            while (reader.Read())
            {
                superhero.SuperheroID = Int32.Parse(reader.GetValue(0).ToString());
                superhero.AffinityID = Int32.Parse(reader.GetValue(1).ToString());
                superhero.Name = reader.GetValue(2).ToString();
            }
            
            return superhero;
        }

        //TODO: Creating character
        public Boolean CreateSuperCharacter(Superhero superhero) {

            using (SqlCommand command = dbConnection.CreateCommand())
            {
                command.CommandText = "INSERT INTO dbo.Superhero(SuperheroID,AffinityID,Name) VALUES(@param1,@param2,@param3)";

                command.Parameters.AddWithValue("@param1", superhero.SuperheroID);
                command.Parameters.AddWithValue("@param2", superhero.AffinityID);
                command.Parameters.AddWithValue("@param3", superhero.Name);

                int result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            } 
        }

        //Updating character
        public Boolean UpdateSuperCharacter(Superhero superhero) {
            using (SqlCommand command = dbConnection.CreateCommand())
            {
                command.CommandText = "UPDATE dbo.Superhero SET SuperheroID = @param1,AffinityID = @param2,Name = @param3)";

                command.Parameters.AddWithValue("@param1", superhero.SuperheroID);
                command.Parameters.AddWithValue("@param2", superhero.AffinityID);
                command.Parameters.AddWithValue("@param3", superhero.Name);

                int result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

    }
}
