using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;

namespace Ijasz2.Adatbazis.Verseny {
    public static class Verseny {
        public static ObservableCollection<Model.Verseny.Verseny> Load() {
            var value = new ObservableCollection<Model.Verseny.Verseny>();

            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "SELECT VEAZON, VEMEGN, VEDATU, VSAZON, VEOSPO, VEALSZ, VEINSZ, VELEZAR, VEDUBE FROM Verseny;";
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                var index = -1;
                value.Add(new Model.Verseny.Verseny {
                    Azonosito = reader.GetString(++index),
                    Megnevezes = reader.GetString(++index),
                    Datum = reader.GetString(++index),
                    Versenysorozat = reader.GetString(++index),
                    Osszes = reader.GetInt32(++index),
                    Allomasok = reader.GetInt32(++index),
                    Indulok = reader.GetInt32(++index),
                    Lezarva = reader.GetBoolean(++index),
                    DuplaBeirolap = reader.GetBoolean(++index)
                });
            }
            command.Dispose();
            Database.Connection.Close();
            return value;
        }

        public static void Add(Model.Verseny.Verseny verseny) {
            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();

            command.CommandText = "INSERT INTO Verseny (VEAZON, VEMEGN, VEDATU, VSAZON, VEOSPO, VEALSZ, VEINSZ, VELEZAR, VEDUBE)"
                                  +
                                  " VALUES(@VEAZON, @VEMEGN, @VEDATU, @VSAZON, @VEOSPO, @VEALSZ, @VEINSZ, @VELEZAR, @VEDUBE);";

            command.Parameters.AddWithValue("@VEAZON", verseny.Azonosito);
            command.Parameters.AddWithValue("@VEMEGN", verseny.Megnevezes);
            command.Parameters.AddWithValue("@VEDATU", verseny.Datum);
            command.Parameters.AddWithValue("@VSAZON", verseny.Versenysorozat);
            command.Parameters.AddWithValue("@VEOSPO", verseny.Osszes);
            command.Parameters.AddWithValue("@VEALSZ", verseny.Allomasok);
            command.Parameters.AddWithValue("@VEINSZ", verseny.Indulok);
            command.Parameters.AddWithValue("@VELEZAR", verseny.Lezarva);
            command.Parameters.AddWithValue("@VEDUBE", verseny.DuplaBeirolap);

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

        public static void Update(Model.Verseny.Verseny verseny) {
            Database.Connection.Open();
            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Verseny SET " +
                                  "VEAZON=@VEAZON, VEMEGN=@VEMEGN, VEDATU=@VEDATU," +
                                  "VSAZON=@VSAZON, VEOSPO=@VEOSPO, VEALSZ=@VEALSZ," +
                                  "VEINSZ=@VEINSZ, VELEZAR=@VELEZAR, VEDUBE=@VEDUBE" +
                                  " WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue("@VEAZON", verseny.Azonosito);
            command.Parameters.AddWithValue("@VEMEGN", verseny.Megnevezes);
            command.Parameters.AddWithValue("@VEDATU", verseny.Datum);
            command.Parameters.AddWithValue("@VSAZON", verseny.Versenysorozat);
            command.Parameters.AddWithValue("@VEOSPO", verseny.Osszes);
            command.Parameters.AddWithValue("@VEALSZ", verseny.Allomasok);
            command.Parameters.AddWithValue("@VEINSZ", verseny.Indulok);
            command.Parameters.AddWithValue("@VELEZAR", verseny.Lezarva);
            command.Parameters.AddWithValue("@VEDUBE", verseny.DuplaBeirolap);
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
            command.CommandText = "DELETE FROM Verseny WHERE VEAZON=@VEAZON;";
            command.CommandText += "DELETE FROM Korosztályok WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue("@VEAZON", azonosito);

            try {
                command.ExecuteNonQuery();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            command.Dispose();
            Database.Connection.Close();
        }

        /// <summary>
        ///     |
        ///     indulo beirasakor |
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public static void IndulokNoveles(string azonosito) {
            Database.Connection.Open();

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Verseny SET VEINSZ = VEINSZ + 1 WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue("@VEAZON", azonosito);
            command.ExecuteNonQuery();

            command.Dispose();
            Database.Connection.Close();
        }

        /// <summary>
        ///     TODO eredmeny torlesekor
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public static void IndulokCsokkentes(string azonosito) {
            Database.Connection.Open();

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Verseny SET VEINSZ = VEINSZ - 1 WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue("@VEAZON", azonosito);
            command.ExecuteNonQuery();

            command.Dispose();
            Database.Connection.Close();
        }
    }
}