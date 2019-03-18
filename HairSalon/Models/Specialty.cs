using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Models
{
    public class Specialty
    {
        private string _name;
        private int _id;

        public Specialty(string specialtyName, int id = 0)
        {
            _name = specialtyName;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"insert into specialties (name) select * from (select @name) AS tmp where not exists (select name from specialties where name = @name) limit 1;";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);
            cmd.ExecuteNonQuery();    // This line is new!

            // One more line of logic will go here in the next lesson.

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void AddStylist(int specialtyId, int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"insert stylists_specialties (stylist_id, specialty_id) values (@stylistId, @specialtyId);";
            MySqlParameter specialtyIdParam = new MySqlParameter();
            specialtyIdParam.ParameterName = "@specialtyId";
            specialtyIdParam.Value = specialtyId;
            cmd.Parameters.Add(specialtyIdParam);
            MySqlParameter stylistIdParam = new MySqlParameter();
            stylistIdParam.ParameterName = "@stylistId";
            stylistIdParam.Value = stylistId;
            cmd.Parameters.Add(stylistIdParam);
            cmd.ExecuteNonQuery();    // This line is new!

            // One more line of logic will go here in the next lesson.

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        public void Update()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE specialties SET name=@name WHERE id=@id;";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;

            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "@id";
            id.Value = this._id;
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();    // This line is new!

            // One more line of logic will go here in the next lesson.

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Specialty specialty = new Specialty(name, id);
                allSpecialties.Add(specialty);
            }

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }

            return allSpecialties;
        }

        public static Specialty Find(int id)
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties where id = " + id.ToString() + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            
            while (rdr.Read())
            {
                string name = rdr.GetString(1);
                Specialty specialty = new Specialty(name, id);
                return specialty;
            }
            return null;
        }

        public static Specialty FindByName(string name)
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties where name = '" + name + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                Specialty specialty = new Specialty(name, id);
                return specialty;
            }
            return null;
        }

        internal List<Stylist> GetStylists()
        {
            List<Stylist> allStylists = new List<Stylist> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT distinct a.id, a.name FROM stylists as a INNER JOIN stylists_specialties as b on a.id = b.stylist_id where b.specialty_id = " + this._id.ToString() + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Stylist stylist = new Stylist(name, id);
                allStylists.Add(stylist);
            }

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }

            return allStylists;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists_specialties WHERE specialty_id = @specialtyId; DELETE FROM specialties WHERE id = @specialtyId;";
            MySqlParameter specialtyIdParameter = new MySqlParameter();
            specialtyIdParameter.ParameterName = "@specialtyId";
            specialtyIdParameter.Value = this._id;
            cmd.Parameters.Add(specialtyIdParameter);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties; ";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }
}