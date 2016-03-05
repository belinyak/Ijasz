using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;

namespace Ijasz2.Adatbazis.Versenysorozat {
    public static class Versenysorozat {
        public static ObservableCollection<Model.Versenysorozat.Versenysorozat> Load() {
            var value = new ObservableCollection<Model.Versenysorozat.Versenysorozat>();

            Database.Connection.Open();

            var command = Database.Connection.CreateCommand();
            command.CommandText = "SELECT VSAZON, VSMEGN, VSVESZ FROM Versenysorozat;";
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                var index = -1;
                value.Add(new Model.Versenysorozat.Versenysorozat {
                    Azonosito = reader.GetString(++index),
                    Megnevezes = reader.GetString(++index),
                    VersenyekSzama = reader.GetInt32(++index)
                });
            }
            command.Dispose();
            Database.Connection.Close();
            return value;
        }

        public static void Add(Model.Versenysorozat.Versenysorozat versenysorozat) {
            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "INSERT INTO Versenysorozat (VSAZON, VSMEGN, VSVESZ) VALUES(@VSAZON, @VSMEGN, @VSVESZ);";
            command.Parameters.AddWithValue("@VSAZON", versenysorozat.Azonosito);
            command.Parameters.AddWithValue("@VSMEGN", versenysorozat.Megnevezes);
            command.Parameters.AddWithValue("@VSVESZ", "0");

            try {
                command.ExecuteNonQuery();
            }
            catch (SQLiteException exception) {
                MessageBox.Show(exception.Message);
            }
            finally {
                command.Dispose();
                Database.Connection.Close();
            }
        }

        public static void Update(Model.Versenysorozat.Versenysorozat versenysorozat) {
            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Versenysorozat SET VSAZON=@VSAZON, VSMEGN=@VSMEGN WHERE VSAZON=@VSAZON;";
            command.Parameters.AddWithValue("@VSMEGN", versenysorozat.Megnevezes);
            command.Parameters.AddWithValue("@VSAZON", versenysorozat.Azonosito);

            try {
                command.ExecuteNonQuery();
            }
            catch (SQLiteException exception) {
                MessageBox.Show(exception.Message);
            }
            finally {
                command.Dispose();
                Database.Connection.Close();
            }
        }

        public static void Remove(string azonosito) {
            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();
            command.CommandText = "DELETE FROM Versenysorozat WHERE VSAZON=@VSAZON;";
            command.Parameters.AddWithValue("@VSAZON", azonosito);
            command.ExecuteNonQuery();

            command.Dispose();
            Database.Connection.Close();
        }

        /// <summary>
        ///     |
        ///     TODO verseny hozzaadashoz |
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public static void VersenyekNovel(string azonosito) {
            Database.Connection.Open();

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Versenysorozat SET VSVESZ = VSVESZ + 1 WHERE VSAZON=@VSAZON;";
            command.Parameters.AddWithValue("@VSAZON", azonosito);

            command.ExecuteNonQuery();
            command.Dispose();
            Database.Connection.Close();
        }

        /// <summary>
        ///     |
        ///     TODO verseny torleshez |
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public static void VersenyekCsokkent(string azonosito) {
            Database.Connection.Open();

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Versenysorozat SET VSVESZ = VSVESZ - 1 WHERE VSAZON=@VSAZON;";
            command.Parameters.AddWithValue("@VSAZON", azonosito);

            command.ExecuteNonQuery();
            command.Dispose();
            Database.Connection.Close();
        }
    }
}