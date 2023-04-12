using DemoAdo.Classes.Filter;
using Helper.Classes;
using Microsoft.Data.SqlClient;

namespace DemoAdo.Classes
{
    internal class Contact
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _telephone;
        public static SqlConnection connection = DataBase.Connection;
        public static SqlCommand command;

        public Contact(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public Contact(int id, string nom, string prenom, string telephone) : this(nom, prenom, telephone)
        {
            Id = id;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }

        public override string ToString()
        {
            return $"{Id} : {Prenom} {Nom} qui a pour téléphone {Telephone}";
        }

        /// <summary>
        /// Use the filters given to return contacts from the database
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static List<Contact> GetContactsByFilter(ContactFilter filters)
        {
            connection.Open();
            string request = "SELECT contact_id, nom, prenom, telephone FROM contact";

            List<string> names = AdoHelper.GetFilterPropertiesName(filters);
            AdoHelper.UpdateRequestWithWhere(ref request, names);
            command = new SqlCommand(request, connection);
            PopulateCommand(names, filters);
            List<Contact> contacts = new();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                contacts.Add(new Contact(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return contacts;
        }

        /// <summary>
        /// return all the contacts in the database
        /// </summary>
        /// <returns></returns>
        public static List<Contact> GetAllContacts()
        {
            connection.Open();
            string request = "SELECT contact_id, nom, prenom, telephone FROM contact";
            command = new SqlCommand(request, connection);
            List<Contact> contacts = new();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                contacts.Add(new Contact(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return contacts;
        }

        /// <summary>
        /// Insert a contact and return the inserted id
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static int InsertContact(Contact contact)
        {
            connection.Open();
            string request = "INSERT INTO contact (nom, prenom, telephone) OUTPUT INSERTED.contact_id VALUES (@nom, @prenom, @telephone)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", contact.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", contact.Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", contact.Telephone));

            int result = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return result;
        }

        /// <summary>
        /// Get the contact via the filters object and update its field via the uContact values
        /// </summary>
        /// <param name="uContact"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static bool UpdateContactByFilter(ContactFilter uContact, ContactFilter filters)
        {
            connection.Open();
            string request = "UPDATE contact";

            List<string> propertyFilterNames = AdoHelper.GetFilterPropertiesName(filters);
            List<string> propertyUpdateNames = AdoHelper.GetFilterPropertiesName(uContact);
            AdoHelper.UpdateRequestWithSet(ref request, propertyUpdateNames, "_u");
            AdoHelper.UpdateRequestWithWhere(ref request, propertyFilterNames, "_f");
            command = new SqlCommand(request, connection);
            PopulateCommand(propertyUpdateNames, uContact, "_u");
            PopulateCommand(propertyFilterNames, filters, "_f");

            int nb = command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

            return nb > 0;
        }

        /// <summary>
        /// Remove a contact gotten via the filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static bool RemoveContactByFilter(ContactFilter filters)
        {
            connection.Open();
            string request = "DELETE FROM contact";

            List<string> propertyFilterNames = AdoHelper.GetFilterPropertiesName(filters);
            AdoHelper.UpdateRequestWithWhere(ref request, propertyFilterNames);
            command = new SqlCommand(request, connection);
            PopulateCommand(propertyFilterNames, filters);

            int nb = command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

            return nb > 0;
        }

        /// <summary>
        /// Add sql parameters to the command via the propsNames and the filters
        /// </summary>
        /// <param name="propsNames"></param>
        /// <param name="filters"></param>
        /// <param name="suffix"></param>
        public static void PopulateCommand(List<string> propsNames, ContactFilter filters, string suffix = "_f")
        {
            if (propsNames.Count > 0)
            {
                for (int i = 0; i < propsNames.Count; i++)
                {
                    command.Parameters.Add(new SqlParameter($"@{propsNames[i]}{suffix}", filters[propsNames[i]]));
                }
            }
        }
    }
}
