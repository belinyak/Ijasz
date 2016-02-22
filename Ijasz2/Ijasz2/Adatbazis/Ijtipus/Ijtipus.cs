using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;

namespace Ijasz2.Adatbazis.Ijtipus {
    public class Ijtipus {
        public static ObservableCollection<Model.Ijtipus.Ijtipus> Load( ) {
            var value = new ObservableCollection<Model.Ijtipus.Ijtipus>();

            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand( );

            command.CommandText = "SELECT ITAZON, ITMEGN, ITLISO, ITERSZ FROM Íjtípusok;";
            SQLiteDataReader reader = command.ExecuteReader( );
            while( reader.Read( ) ) {
                int index = -1;
                value.Add( new Model.Ijtipus.Ijtipus {
                    Azonosito = reader.GetString( ++index ),
                    Megnevezes = reader.GetString( ++index ),
                    Sorszam = reader.GetInt32( ++index ),
                    Eredmenyek = reader.GetInt32( ++index )
                } );

            }
            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return value;
        }

        public static void Add( Model.Ijtipus.Ijtipus ijtipus ) {
            Adatbazis.Database.Connection.Open( );
            var command = Adatbazis.Database.Connection.CreateCommand();

            command.CommandText = "INSERT INTO Íjtípusok (ITAZON, ITMEGN, ITLISO, ITERSZ) " +
                "VALUES(@ITAZON, @ITMEGN, @ITLISO, @ITERSZ)";

            command.Parameters.AddWithValue( "@ITAZON", ijtipus.Azonosito );
            command.Parameters.AddWithValue( "@ITMEGN", ijtipus.Megnevezes );
            command.Parameters.AddWithValue( "@ITLISO", ijtipus.Sorszam );
            command.Parameters.AddWithValue( "@ITERSZ", ijtipus.Eredmenyek );

            try {
                command.ExecuteNonQuery( );
            } catch( SQLiteException exception ) {
                MessageBox.Show( exception.Message );
            } finally {
                command.Dispose( );
                Adatbazis.Database.Connection.Close( );
            }
        }

        public static void Update( Model.Ijtipus.Ijtipus ijtipus ) {
            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Íjtípusok SET ITAZON=@ITAZON, ITMEGN=@ITMEGN, ITLISO=@ITLISO  WHERE ITAZON=@ITAZON;";

            command.Parameters.AddWithValue( "@ITAZON", ijtipus.Azonosito );
            command.Parameters.AddWithValue( "@ITMEGN", ijtipus.Megnevezes );
            command.Parameters.AddWithValue( "@ITLISO", ijtipus.Sorszam );
            command.Parameters.AddWithValue( "@ITERSZ", ijtipus.Eredmenyek );
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
            command.CommandText = "DELETE FROM Íjtípusok WHERE ITAZON=@ITAZON;";

            command.Parameters.AddWithValue( "@ITAZON", azonosito );

            try {
                command.ExecuteNonQuery( );
            } catch( Exception e ) {
                Console.WriteLine( e );
            }

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
        }

        /// <summary>
        /// TODO 
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public bool EredmenyekNovelese( string azonosito ) {
            Adatbazis.Database.Connection.Open( );

            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Íjtípusok SET ITERSZ = ITERSZ + 1 WHERE ITAZON=@ITAZON;";
            command.Parameters.AddWithValue( "@ITAZON", azonosito );

            command.ExecuteNonQuery( );

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return true;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="azonosito"></param>
        /// <returns></returns>
        public bool EredmenyekCsokkentes( string azonosito ) {
            Adatbazis.Database.Connection.Open( );

            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Íjtípusok SET ITERSZ = ITERSZ - 1 WHERE ITAZON=@ITAZON;";
            command.Parameters.AddWithValue( "@ITAZON", azonosito );

            command.ExecuteNonQuery( );

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return true;
        }
    }
}
