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
    public class RepositoryContattiAdo : IRepositoryContatti
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Contatto Add(Contatto item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into Contatto values(@nome, @cognome)", connection);
                
                command.Parameters.AddWithValue("@nome", item.Nome);
                command.Parameters.AddWithValue("@cognome", item.Cognome);
                

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

        public Contatto Delete(Contatto item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete Contatto where ID=@idContatto", connection);

                command.Parameters.AddWithValue("@idContatto", item.Id);
                int rigaEliminata = command.ExecuteNonQuery();
                if (rigaEliminata == 1)
                {
                    connection.Close();
                    return item;

                }
                else
                {
                    connection.Close();
                    return null;

                }
            }
        }

        public List<Contatto> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select * from Contatto", connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Contatto> contatti = new List<Contatto>();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];

                    var c = new Contatto(id, nome, cognome);

                    contatti.Add(c);
                }
                connection.Close();

                return contatti;
            }

        }

        public Contatto GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select * from Contatto where ID=@id", connection);
                
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                Contatto s = null;

                while (reader.Read())
                {
                    //var id = (int)reader["ID"];
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    
                    s = new Contatto(id, nome, cognome);                    
                }
                connection.Close();
                return s;
            }
        }
    }
}
