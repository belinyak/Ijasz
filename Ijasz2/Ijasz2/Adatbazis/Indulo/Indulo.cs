using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;

namespace Ijasz2.Adatbazis.Indulo {
    public static class Indulo {
        public static ObservableCollection<Model.Indulo.Indulo> Load() {
            var value = new ObservableCollection<Model.Indulo.Indulo>();


            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();

            command.CommandText = "SELECT INNEVE, INNEME, INSZUL, INVEEN, EGAZON, INERSZ FROM Indulók;";
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                var index = -1;
                value.Add(new Model.Indulo.Indulo {
                    Nev = reader.GetString(++index),
                    Nem = reader.GetString(++index),
                    SzuletesiDatum = reader.GetString(++index),
                    Engedely = reader.GetString(++index),
                    Egyesulet = reader.GetString(++index),
                    Eredmenyek = reader.GetInt32(++index)
                });
            }
            command.Dispose();
            Database.Connection.Close();
            return value;
        }

        public static void Add(Model.Indulo.Indulo indulo) {
            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "INSERT INTO Indulók (INNEVE, INNEME, INSZUL, INVEEN, EGAZON, INERSZ) VALUES(@INNEVE, @INNEME, @INSZUL, @INVEEN, @EGAZON, @INERSZ);";

            command.Parameters.Add(new SQLiteParameter("@INNEVE", indulo.Nev));
            command.Parameters.Add(new SQLiteParameter("@INNEME", indulo.Nem));
            command.Parameters.Add(new SQLiteParameter("@INSZUL", indulo.SzuletesiDatum));
            command.Parameters.Add(new SQLiteParameter("@INVEEN", indulo.Engedely));
            command.Parameters.Add(new SQLiteParameter("@EGAZON", indulo.Egyesulet));
            command.Parameters.Add(new SQLiteParameter("@INERSZ", "0"));

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

        public static void Update(Model.Indulo.Indulo indulo) {
            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();
            command.CommandText =
                "UPDATE Indulók SET INNEVE = @INNEVE, INNEME = @INNEME, INSZUL = @INSZUL, INVEEN = @INVEEN, EGAZON = @EGAZON WHERE INNEVE = @INNEVE";
            command.Parameters.Add(new SQLiteParameter("@INNEVE", indulo.Nev));
            command.Parameters.Add(new SQLiteParameter("@INNEME", indulo.Nem));
            command.Parameters.Add(new SQLiteParameter("@INSZUL", indulo.SzuletesiDatum));
            command.Parameters.Add(new SQLiteParameter("@INVEEN", indulo.Engedely));
            command.Parameters.Add(new SQLiteParameter("@EGAZON", indulo.Egyesulet));
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
            command.CommandText = "DELETE FROM Indulók WHERE INNEVE=@INNEVE;";

            command.Parameters.Add(new SQLiteParameter("@INNEVE", azonosito));

            try {
                command.ExecuteNonQuery();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            command.Dispose();
            Database.Connection.Close();
        }

        public static void EredmenyekNoveles(string azonosito) {
            Database.Connection.Open();

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Indulók SET INERSZ = INERSZ + 1 WHERE INNEVE=@INNEVE;";
            command.Parameters.AddWithValue("@INNEVE", azonosito);
            command.ExecuteNonQuery();

            command.Dispose();
            Database.Connection.Close();
        }

        public static void EredmenyekCsokkentes(string azonosito) {
            Database.Connection.Open();

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Indulók SET INERSZ = INERSZ - 1 WHERE INNEVE=@INNEVE;";
            command.Parameters.AddWithValue("@INNEVE", azonosito);
            command.ExecuteNonQuery();

            command.Dispose();
            Database.Connection.Close();
        }
    }
}