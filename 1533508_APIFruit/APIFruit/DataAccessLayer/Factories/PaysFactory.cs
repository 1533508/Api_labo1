using APIFruit.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFruit.DataAccessLayer.Factories
{
    public class PaysFactory
    {
        private Pays CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string nom = mySqlDataReader["Nom"].ToString();

            return new Pays(id, nom);
        }

        public Pays CreateEmpty()
        {
            return new Pays(0, string.Empty);
        }

        public Pays[] GetAll()
        {
            List<Pays> listePays = new List<Pays>();
            MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM demo_apifruit2 ORDER BY Nom";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    listePays.Add(CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return listePays.ToArray();
        }

        public Pays Get(int id)
        {
            Pays pays = null;
            MySqlConnection mySqlCnn = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM demo_apifruit2 WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    pays = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return pays;
        }

        public void Save(Pays pays)
        {
            MySqlConnection mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    if (pays.Id == 0)
                    {
                        // On sait que c'est un nouveau produit avec Id == 0,
                        // car c'est ce que nous avons affecter dans la fonction CreateEmpty().
                        mySqlCmd.CommandText = "INSERT INTO demo_apifruit2(Nom) " +
                                               "VALUES (@Nom)";
                    }
                    else
                    {
                        mySqlCmd.CommandText = "UPDATE demo_apifruit2 " +
                                               "SET Nom=@Nom " +
                                               "WHERE Id=@Id";

                        mySqlCmd.Parameters.AddWithValue("@Id", pays.Id);
                    }

                    mySqlCmd.Parameters.AddWithValue("@Nom", pays.Nom.Trim());

                    mySqlCmd.ExecuteNonQuery();

                    if (pays.Id == 0)
                    {
                        // Si c'était un nouveau produit (requête INSERT),
                        // nous affectons le nouvel Id de l'instance au cas où il serait utilisé dans le code appelant.
                        pays.Id = (int)mySqlCmd.LastInsertedId;
                    }
                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }
        }

        public void Delete(int id)
        {
            MySqlConnection mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = "DELETE FROM demo_apifruit2 WHERE Id=@Id";
                    mySqlCmd.Parameters.AddWithValue("@Id", id);
                    mySqlCmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }
        }
    }
}
