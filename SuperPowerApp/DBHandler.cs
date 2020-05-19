using SuperPowerApp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPowerApp
{
    public class DBHandler
    {
        private String connectionString;
        private SqlConnection dbConnection;

        public DBHandler() {
            this.connectionString = @"Data Source=(localdb)\ProjectsV13; Initial Catalog=SuperRegistry; Integrated Security=True; User ID=AzureAD\IanGleeson;";
            this.dbConnection = new SqlConnection(connectionString);
            this.OpenConnection();
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
                command.CommandText = "DELETE FROM dbo.Superhero WHERE SuperheroID = @param; " +
                    "DELETE FROM dbo.Background WHERE SuperheroID = @param; " +
                    "DELETE FROM dbo.SuperheroAbility WHERE SuperheroID = @param;" +
                    "DELETE FROM dbo.SuperheroRegion WHERE SuperheroID  = @param;";
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
            Superhero superhero = null;
                command.CommandText = "SELECT dbo.Superhero.SuperheroID,dbo.Superhero.Name,dbo.Affinity.AffinityID,dbo.Affinity.Type " +
                "FROM dbo.Superhero INNER JOIN dbo.Affinity ON dbo.Superhero.AffinityID = dbo.Affinity.AffinityID " +
                "WHERE SuperheroID = @param;";
                command.Parameters.AddWithValue("@param", characterID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    superhero = new Superhero();
                    superhero.SuperheroID = Int32.Parse(reader.GetValue(0).ToString());
                    superhero.Name = reader.GetValue(1).ToString();
                    superhero.Affinity = new Affinity(Int32.Parse(reader.GetValue(2).ToString()), reader.GetValue(3).ToString());
                    //maxID = this.GetMaxSuperheroID();
                }

                //if (superhero == null)
                //{
                //    characterID += 1;
                //}
                command.Parameters.Clear();
                reader.Close();
            return superhero;
        }

        public int GetMaxSuperheroID() {
            SqlCommand commandMax = dbConnection.CreateCommand();
            commandMax.CommandText = "SELECT Max(Superhero.SuperheroID) FROM dbo.Superhero;";
            SqlDataReader readerMax = commandMax.ExecuteReader();
            int maxID = 0;
            while (readerMax.Read())
            {
                maxID = Int32.Parse(readerMax.GetValue(0).ToString());
            }
            readerMax.Close();
            return maxID;
        }

        //Creating character
        public Boolean CreateSuperCharacter(Superhero superhero) {

            using (SqlCommand command = dbConnection.CreateCommand())
            {

                command.CommandText = "INSERT INTO dbo.Superhero(AffinityID,Superhero.Name) VALUES(@param2,@param3)";

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

        //Obtaining a list of affinities from Db
        public List<Affinity> GetAffinities() {
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandText = "SELECT AffinityID,Type FROM Affinity";
            SqlDataReader reader = command.ExecuteReader();
            List<Affinity> affinities = new List<Affinity>();
            while (reader.Read())
            {
                Affinity affinity = new Affinity();
                affinity.AffinityID = Int32.Parse(reader.GetValue(0).ToString());
                affinity.Type = reader.GetValue(1).ToString();
                affinities.Add(affinity);
            }
            
            return affinities;
        }

    }
}
