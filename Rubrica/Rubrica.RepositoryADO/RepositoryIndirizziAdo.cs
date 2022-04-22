using Rubrica.Core;
using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryADO
{
    public class RepositoryIndirizziAdo : IRepositoryIndirizzi
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Indirizzo Add(Indirizzo item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into Indirizzo values(@tipologia, @via, @citta, @cap, @provincia, @nazione, @idContatto)", connection);

                // Tipologia, via, citta, cap, provincia, nazione, id contatto
                
                command.Parameters.AddWithValue("@tipologia", item.Tipologia);
                command.Parameters.AddWithValue("@via", item.Via);
                command.Parameters.AddWithValue("@citta", item.Citta);
                command.Parameters.AddWithValue("@cap", item.CAP);
                command.Parameters.AddWithValue("@provincia", item.Provincia);
                command.Parameters.AddWithValue("@nazione", item.Nazione);
                command.Parameters.AddWithValue("@idContatto", item.IdContatto);               


                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return item;
                }
                connection.Close();
                return item;
            }
        }

        public List<Indirizzo> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select * from Indirizzo", connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Indirizzo> indirizzi = new List<Indirizzo>();

                while (reader.Read())
                {
                    var id = (int)reader["IdIndirizzo"];
                    var tipologia = (string)reader["Tipologia"];
                    var via = (string)reader["Via"];
                    var citta = (string)reader["Citta"];
                    var cap = (int)reader["CAP"];
                    var provincia = (string)reader["Provincia"];
                    var nazione = (string)reader["Nazione"];
                    var idContatto = (int)reader["IdContatto"];
                    

                    var i = new Indirizzo(id, tipologia, via, citta, cap, provincia, nazione, idContatto);

                    indirizzi.Add(i);
                }
                connection.Close();

                return indirizzi;
            }
        }

        public Indirizzo GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select * from Indirizzo where IdIndirizzo=@id", connection);

                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                Indirizzo i = null;

                while (reader.Read())
                {
                    //var id = (int)reader["ID"];
                    var tipologia = (string)reader["Tipologia"];
                    var via = (string)reader["Via"];
                    var citta = (string)reader["Citta"];
                    var cap = (int)reader["CAP"];
                    var provincia = (string)reader["Provincia"];
                    var nazione = (string)reader["Nazione"];
                    var idContatto = (int)reader["IdContatto"];

                    i = new Indirizzo(id, tipologia, via, citta, cap, provincia, nazione, idContatto);
                }
                connection.Close();
                return i;
            }
        }
    }
}
