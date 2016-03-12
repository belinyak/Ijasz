using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;

namespace Ijasz2.Adatbazis.Egyesulet {
    public static class Egyesulet {
        public static ObservableCollection<Model.Egyesulet.Egyesulet> Load( ) {
            var value = new ObservableCollection<Model.Egyesulet.Egyesulet>();

            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "SELECT EGAZON,EGCIME,EGVENE,EGVET1,EGVET2,EGVEM1,EGVEM2,EGLIST,EGTASZ FROM Egyesuletek;";
            var reader = command.ExecuteReader();
            while( reader.Read( ) ) {
                var index = -1;
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
            Database.Connection.Close( );
            return value;
        }

        public static void Add( Model.Egyesulet.Egyesulet egyesulet ) {
            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "INSERT INTO Egyesuletek (EGAZON,EGCIME,EGVENE,EGVET1,EGVET2,EGVEM1,EGVEM2,EGLIST,EGTASZ)" +
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
                Database.Connection.Close( );
            }
        }

        public static void Update( Model.Egyesulet.Egyesulet egyesulet ) {
            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();
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
                Database.Connection.Close( );
            }
        }

        public static void Remove( string azonosito ) {
            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText = "DELETE FROM Egyesuletek WHERE EGAZON=@EGAZON;";

            command.Parameters.AddWithValue( "@EGAZON", azonosito );

            try {
                command.ExecuteNonQuery( );
            } catch( Exception e ) {
                Console.WriteLine( e );
            }

            command.Dispose( );
            Database.Connection.Close( );
        }

        public static void TagokNoveles( string azonosito ) {
            Database.Connection.Open( );

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Egyesuletek SET EGTASZ = EGTASZ + 1 WHERE EGAZON=@EGAZON";
            command.Parameters.AddWithValue( "@EGAZON", azonosito );

            command.ExecuteNonQuery( );

            command.Dispose( );
            Database.Connection.Close( );
        }

        public static void TagokCsokkentes( string azonosito ) {
            Database.Connection.Open( );

            var command = Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Egyesuletek SET EGTASZ = EGTASZ - 1 WHERE EGAZON=@EGAZON";
            command.Parameters.AddWithValue( "@EGAZON", azonosito );

            command.ExecuteNonQuery( );

            command.Dispose( );
            Database.Connection.Close( );
        }

        public static List<Nyomtatas.Eredmenylap.Egyesulet > EredmenyLap( string versenyAzonosito ) {
        /*
            select Egyesuletek.EGAZON, sum(Eredmények.INOSZP) from Egyesuletek
            join Indulók on Egyesuletek.EGAZON=Indulók.EGAZON
            join Eredmények on Indulók.INNEVE = Eredmények.INNEVE
            group by Egyesuletek.EGAZON
            order by sum(Eredmények.INOSZP)  desc
        */
            var value = new List<Nyomtatas.Eredmenylap.Egyesulet>();

            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "select Egyesuletek.EGAZON, Egyesuletek.EGCIME, sum(Eredmények.INOSZP) from Egyesuletek" +
                " join Indulók on Egyesuletek.EGAZON=Indulók.EGAZON" +
                " join Eredmények on Indulók.INNEVE = Eredmények.INNEVE" +
                " where VEAZON=@VEAZON" + 
                " group by Egyesuletek.EGAZON" +
                " order by sum(Eredmények.INOSZP) desc;" + 

            command.Parameters.AddWithValue( "@VEAZON", versenyAzonosito );

            var reader = command.ExecuteReader();
            while( reader.Read( ) ) {
                value.Add(new Nyomtatas.Eredmenylap.Egyesulet {
                    Nev = reader.GetString(0),
                    Cim = reader.GetString(1),
                    OsszPont = reader.GetInt32(2)
                });
            }
            command.Dispose( );
            Database.Connection.Close( );
            return value;
        }
    }
}