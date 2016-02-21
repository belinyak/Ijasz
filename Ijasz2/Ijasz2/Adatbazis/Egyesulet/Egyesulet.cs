using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ijasz2.Adatbazis.Egyesulet {
    public class Egyesulet {

        public static ObservableCollection<Model.Egyesulet.Egyesulet> Load( ) {
            var value = new ObservableCollection<Model.Egyesulet.Egyesulet>();

            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand( );

            command.CommandText = "SELECT EGAZON,EGCIME,EGVENE,EGVET1,EGVET2,EGVEM1,EGVEM2,EGLIST,EGTASZ FROM Egyesuletek;";
            SQLiteDataReader reader = command.ExecuteReader( );
            while( reader.Read( ) ) {
                int index = -1;
                value.Add( new Model.Egyesulet.Egyesulet {
                    Azonosito = reader.GetString( ++index ),
                    Cim = reader.GetString( ++index ),
                    Vezeto = reader.GetString( ++index ),
                    Telefon1 = reader.GetString( ++index ),
                    Telefon2 = reader.GetString( ++index ),
                    Email1 = reader.GetString( ++index ),
                    Email2 = reader.GetString( ++index ),
                    Listazando = reader.GetBoolean( ++index ),
                    TagokSzama = reader.GetInt32( ++index )
                } );
            }
            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return value;
        }

        public static void Add( Model.Egyesulet.Egyesulet egyesulet ) {
            Adatbazis.Database.Connection.Open( );
            var command = Adatbazis.Database.Connection.CreateCommand();

            command.CommandText = "INSERT INTO Egyesuletek (EGAZON,EGCIME,EGVENE,EGVET1,EGVET2,EGVEM1,EGVEM2,EGLIST,EGTASZ)" +
                                  " VALUES(@EGAZON, @EGCIME, @EGVENE, @EGVET1, @EGVET2, @EGVEM1, @EGVEM2, @EGLIST, @EGTASZ);";

            command.Parameters.AddWithValue( "@EGAZON", egyesulet.Azonosito );
            command.Parameters.AddWithValue( "@EGCIME", egyesulet.Cim );
            command.Parameters.AddWithValue( "@EGVENE", egyesulet.Vezeto );
            command.Parameters.AddWithValue( "@EGVET1", egyesulet.Telefon1 );
            command.Parameters.AddWithValue( "@EGVET2", egyesulet.Telefon2 );
            command.Parameters.AddWithValue( "@EGVEM1", egyesulet.Email1 );
            command.Parameters.AddWithValue( "@EGVEM2", egyesulet.Email2 );
            command.Parameters.AddWithValue( "@EGLIST", egyesulet.Listazando );
            command.Parameters.AddWithValue( "@EGTASZ", egyesulet.TagokSzama );

            try {
                command.ExecuteNonQuery( );
            } catch( SQLiteException exception ) {
                MessageBox.Show( exception.Message );
            } finally {
                command.Dispose( );
                Adatbazis.Database.Connection.Close( );
            }
        }

        public static void Update( Model.Egyesulet.Egyesulet egyesulet ) {
            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Egyesuletek SET " +
                "EGAZON=@EGAZON" +
                ", EGCIME=@EGCIME" +
                ", EGVENE=@EGVENE" +
                ", EGVET1=@EGVET1" +
                ", EGVET2=@EGVET2" +
                ", EGVEM1=@EGVEM1" +
                ", EGVEM2=@EGVEM2" +
                ", EGLIST=@EGLIST " +
                ", EGTASZ=@EGTASZ " +
                " WHERE EGAZON=@EGAZON ;";

            command.Parameters.AddWithValue( "@EGAZON", egyesulet.Azonosito );
            command.Parameters.AddWithValue( "@EGCIME", egyesulet.Cim );
            command.Parameters.AddWithValue( "@EGVENE", egyesulet.Vezeto );
            command.Parameters.AddWithValue( "@EGVET1", egyesulet.Telefon1 );
            command.Parameters.AddWithValue( "@EGVET2", egyesulet.Telefon2 );
            command.Parameters.AddWithValue( "@EGVEM1", egyesulet.Email1 );
            command.Parameters.AddWithValue( "@EGVEM2", egyesulet.Email2 );
            command.Parameters.AddWithValue( "@EGLIST", egyesulet.Listazando );
            command.Parameters.AddWithValue( "@EGTASZ", egyesulet.TagokSzama );
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

            command.CommandText = "DELETE FROM Egyesuletek WHERE EGAZON=@EGAZON ;";

            command.Parameters.AddWithValue( "@EGAZON", azonosito );

            try {
                command.ExecuteNonQuery( );
            } catch( Exception e ) {
                Console.WriteLine( e );
            }

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
        }

        public bool Egyesulet_TagokNoveles( string azonosito ) {
            Adatbazis.Database.Connection.Open( );

            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Egyesuletek SET EGTASZ = EGTASZ + 1 WHERE EGAZON=@EGAZON";
            command.Parameters.AddWithValue( "@EGAZON", azonosito );

            command.ExecuteNonQuery( );

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return true;
        }

        public bool Egyesulet_TagokCsokkentes( string azonosito ) {
            Adatbazis.Database.Connection.Open( );

            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Egyesuletek SET EGTASZ = EGTASZ - 1 WHERE EGAZON=@EGAZON";
            command.Parameters.AddWithValue( "@EGAZON", azonosito );

            command.ExecuteNonQuery( );

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return true;
        }
    }
}
