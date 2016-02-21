using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ijasz2.Adatbazis.Verseny {
    public class Verseny {

        public static ObservableCollection<Model.Verseny.Verseny> Load( ) {
            var value = new ObservableCollection<Model.Verseny.Verseny>();

            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand( );

            command.CommandText = "SELECT VEAZON, VEMEGN, VEDATU, VSAZON, VEOSPO, VEALSZ, VEINSZ, VELEZAR, VEDUBE FROM Verseny;";
            SQLiteDataReader reader = command.ExecuteReader( );
            while( reader.Read( ) ) {
                int index = -1;
                value.Add( new Model.Verseny.Verseny {
                    Azonosito = reader.GetString( ++index ),
                    Megnevezes = reader.GetString( ++index ),
                    Datum = reader.GetString( ++index ),
                    Versenysorozat = reader.GetString( ++index ),
                    Osszes = reader.GetInt32( ++index ),
                    Allomasok = reader.GetInt32( ++index ),
                    Indulok = reader.GetInt32( ++index ),
                    Lezarva = reader.GetBoolean( ++index ),
                    DuplaBeirolap = reader.GetBoolean( ++index ),
                } );
            }
            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return value;
        }

        public static void Add( Model.Verseny.Verseny verseny ) {
            Adatbazis.Database.Connection.Open( );
            var command = Adatbazis.Database.Connection.CreateCommand();

            command.CommandText = "INSERT INTO Verseny (VEAZON, VEMEGN, VEDATU, VSAZON, VEOSPO, VEALSZ, VEINSZ, VELEZAR, VEDUBE)"
                + " VALUES(@VEAZON, @VEMEGN, @VEDATU, @VSAZON, @VEOSPO, @VEALSZ, @VEINSZ, @VELEZAR, @VEDUBE);";
            command.Parameters.AddWithValue( "@VEAZON", verseny.Azonosito );
            command.Parameters.AddWithValue( "@VEMEGN", verseny.Megnevezes );
            command.Parameters.AddWithValue( "@VEDATU", verseny.Datum );
            command.Parameters.AddWithValue( "@VSAZON", verseny.Versenysorozat );
            command.Parameters.AddWithValue( "@VEOSPO", verseny.Osszes );
            command.Parameters.AddWithValue( "@VEALSZ", verseny.Allomasok );
            command.Parameters.AddWithValue( "@VEINSZ", verseny.Indulok );
            command.Parameters.AddWithValue( "@VELEZAR", verseny.Lezarva );
            command.Parameters.AddWithValue( "@VEDUBE", verseny.DuplaBeirolap );

            try {
                command.ExecuteNonQuery( );
            } catch( SQLiteException exception ) {
                MessageBox.Show( exception.Message );
            } finally {
                command.Dispose( );
                Adatbazis.Database.Connection.Close( );
            }
        }

        public static void Update( Model.Verseny.Verseny verseny ) {
            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Verseny SET " +
                "VEAZON=@VEAZON, " +
                "VEMEGN=@VEMEGN, " +
                "VEDATU=@VEDATU," +
                "VSAZON=@VSAZON," +
                "VEOSPO=@VEOSPO," +
                "VEALSZ=@VEALSZ," +
                "VEINSZ=@VEINSZ," +
                "VELEZAR=@VELEZAR," +
                "VEDUBE=@VEDUBE" +
                " WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue( "@VEAZON", verseny.Azonosito );
            command.Parameters.AddWithValue( "@VEMEGN", verseny.Megnevezes );
            command.Parameters.AddWithValue( "@VEDATU", verseny.Datum );
            command.Parameters.AddWithValue( "@VSAZON", verseny.Versenysorozat );
            command.Parameters.AddWithValue( "@VEOSPO", verseny.Osszes );
            command.Parameters.AddWithValue( "@VEALSZ", verseny.Allomasok );
            command.Parameters.AddWithValue( "@VEINSZ", verseny.Indulok );
            command.Parameters.AddWithValue( "@VELEZAR", verseny.Lezarva );
            command.Parameters.AddWithValue( "@VEDUBE", verseny.DuplaBeirolap );
            try {
                command.ExecuteNonQuery( );
            } catch( SQLiteException exception ) {
                MessageBox.Show( exception.Message );
            } finally {
                command.Dispose( );
                Adatbazis.Database.Connection.Close( );
            }
        }

        public static void Remove( string azonosito ) {
            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "DELETE FROM Verseny WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue( "@VEAZON", azonosito );
            command.ExecuteNonQuery( );

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public bool Verseny_IndulokNoveles( string azonosito ) {
            Adatbazis.Database.Connection.Open( );

            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand( );
            command.CommandText = "UPDATE Verseny SET VEINSZ = VEINSZ + 1 WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue( "@VEAZON", azonosito );
            command.ExecuteNonQuery( );

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return true;
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public bool Verseny_IndulokCsokkentes( string azonosito ) {
            Adatbazis.Database.Connection.Open( );

            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand( );
            command.CommandText = "UPDATE Verseny SET VEINSZ = VEINSZ - 1 WHERE VEAZON=@VEAZON;";
            command.Parameters.AddWithValue( "@VEAZON", azonosito );
            command.ExecuteNonQuery( );

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return true;
        }
    }
}
