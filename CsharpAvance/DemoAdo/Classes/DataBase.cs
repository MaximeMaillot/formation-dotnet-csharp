using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;

namespace DemoAdo.Classes
{
    internal class DataBase
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        public SqlConnection Connection
        {
            get => _connection; private set
            {
                _connection = value;
            }
        }
        public SqlCommand Command
        {
            get => _command; private set
            {
                _command = value;
            }
        }
        public DataBase(SqlConnection connection)
        {
            Connection = connection;
        }

        public int InsertEtudiant(Etudiant etudiant)
        {
            Connection.Open();
            string request;
            if (etudiant.DateDiplome != null)
            {
                request = "INSERT INTO etudiant (nom, prenom, num_classe, date_diplome) OUTPUT INSERTED.etudiant_id VALUES (@nom, @prenom, @numClasse, @dateDiplome)";
            }
            else
            {
                request = "INSERT INTO etudiant (nom, prenom, num_classe) OUTPUT INSERTED.etudiant_id VALUES (@nom, @prenom, @numClasse)";
            }
            _command = new SqlCommand(request, Connection);
            _command.Parameters.Add(new SqlParameter("@nom", etudiant.Nom));
            _command.Parameters.Add(new SqlParameter("@prenom", etudiant.Prenom));
            _command.Parameters.Add(new SqlParameter("@numClasse", etudiant.NumClasse));
            if (etudiant.DateDiplome != null)
            {
                _command.Parameters.Add(new SqlParameter("@dateDiplome", etudiant.DateDiplome));
            }

            int result = (int)_command.ExecuteScalar();
            _command.Dispose();
            _connection.Close();
            return result;
        }

        public List<Etudiant> GetEtudiants()
        {
            Connection.Open();
            string request = "SELECT etudiant_id, prenom, nom, num_classe, date_diplome FROM etudiant";
            _command = new SqlCommand(request, Connection);

            List<Etudiant> etudiants = new();
            SqlDataReader reader = _command.ExecuteReader();

            while (reader.Read())
            {
                etudiants.Add(new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader[4] == System.DBNull.Value ? null : reader.GetDateTime(4)));
            }
            reader.Close();
            _command.Dispose();
            _connection.Close();
            return etudiants;
        }

        public List<Etudiant> GetEtudiantsByClass(int numClass)
        {
            Connection.Open();
            string request = "SELECT etudiant_id, prenom, nom, num_classe, date_diplome FROM etudiant WHERE num_classe = @numClass";

            _command = new SqlCommand(request, Connection);
            _command.Parameters.Add(new SqlParameter("@numClass", numClass));

            List<Etudiant> etudiants = new();
            SqlDataReader reader = _command.ExecuteReader();

            while (reader.Read())
            {
                etudiants.Add(new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader[4] == System.DBNull.Value ? null : reader.GetDateTime(4)));
            }
            reader.Close();
            _command.Dispose();
            _connection.Close();
            return etudiants;
        }

        public List<Etudiant> GetEtudiantsByFilter(EtudiantFilter filters)
        {
            Connection.Open();
            PropertyInfo[] props = typeof(EtudiantFilter).GetProperties();
            string request = "SELECT etudiant_id, prenom, nom, num_classe, date_diplome FROM etudiant";
            List<string> names = new List<string>();
            filters.GetType().GetProperties().ToList().ForEach(item => {
                if (item.Name != "Item" && filters[item.Name] != null) {
                    names.Add(item.Name);
                }
                });
            if (names.Count > 0)
            {
                request += " WHERE";
                for (int i = 0; i < names.Count; i++)
                {
                    if (i < names.Count - 1)
                    {
                        request += $" {names[i]} = @{names[i]} AND";
                    }
                    else
                    {
                        request += $" {names[i]} =  @{names[i]}";
                    }
                }
            }
            _command = new SqlCommand(request, Connection);
            if (names.Count > 0)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    _command.Parameters.Add(new SqlParameter($"@{names[i]}", filters[names[i]]));
                }
            }
            List<Etudiant> etudiants = new();

            SqlDataReader reader = _command.ExecuteReader();

            while (reader.Read())
            {
                etudiants.Add(new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader[4] == System.DBNull.Value ? null : reader.GetDateTime(4)));
            }
            reader.Close();
            _command.Dispose();
            _connection.Close();

            return etudiants;
        }

        public bool RemoveEtudiant(int id)
        {
            Connection.Open();
            string request = "DELETE FROM etudiant WHERE etudiant_id = @id";
            _command = new SqlCommand(request, Connection);
            _command.Parameters.Add(new SqlParameter("@id", id));
            int nbRow = _command.ExecuteNonQuery();
            _command.Dispose();
            _connection.Close();
            return nbRow > 0;
        }
    }
}
