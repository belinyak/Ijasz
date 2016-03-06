using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using Ijasz2.Model.Eredmeny;

namespace Ijasz2.Adatbazis.Eredmeny {
    public static class Eredmeny {
        public static List<VersenyEredmeny> Load( ) {
            var value = new List<VersenyEredmeny>();

            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText = "SELECT VEAZON, INNEVE, INSOSZ, ITAZON, INCSSZ, IN10TA, IN08TA, IN05TA, INMETA, " +
                                  "INOSZP, INERSZ, INMEGJ, INKOMO, KOAZON, INBEEK FROM Eredmények ORDER BY VEAZON;";
            var reader = command.ExecuteReader();
            while( reader.Read( ) ) {
                var index = -1;

                var q = new Model.Eredmeny.Eredmeny {
                    Verseny = reader.GetString(++index),
                    Indulo = reader.GetString(++index),
                    Sorszam = reader.GetInt32(++index),
                    Ijtipus = reader.GetString(++index),
                    Csapat = reader.GetInt32(++index),
                    Talalat10 = reader.GetInt32(++index),
                    Talalat8 = reader.GetInt32(++index),
                    Talalat5 = reader.GetInt32(++index),
                    Melle = reader.GetInt32(++index),
                    OsszPont = reader.GetInt32(++index),
                    Szazalek = reader.GetInt32(++index),
                    Megjelent = reader.GetBoolean(++index),
                    KorosztalyModositott = reader.GetBoolean(++index),
                    KorosztalyAzonosito = reader.GetString(++index),
                    Kor = reader.GetInt32(++index)
                };

                var found = false;

                foreach( var versenyEredmeny in value.Where( versenyEredmeny => versenyEredmeny.VersenyAzonosito.Equals( q.Verseny ) ) ) {
                    versenyEredmeny.Eredmenyek._eredmenyek.Add( q );
                    found = true;
                    break;
                }
                if( !found ) {
                    value.Add( new VersenyEredmeny {
                        VersenyAzonosito = q.Verseny,
                        Eredmenyek = new Eredmenyek {
                            _eredmenyek = new ObservableCollection<Model.Eredmeny.Eredmeny> {
                                q
                            }
                        }
                    } );
                }
            }
            command.Dispose( );
            Database.Connection.Close( );
            return value;
        }

        /// <summary>
        ///     |
        ///     vissza kell adni az autoincrementelt insoszt |
        ///     veazon + inneve együtt key
        /// </summary>
        /// <param name="eredmeny"></param>
        public static void Add( Model.Eredmeny.Eredmeny eredmeny ) {
            if( Database.Connection.State == ConnectionState.Open ) {
                Database.Connection.Close( );
            }
            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "INSERT INTO Eredmények(VEAZON, INNEVE, ITAZON, INCSSZ, IN10TA, IN08TA, IN05TA, INMETA, " +
                "INOSZP, INERSZ, INMEGJ, INKOMO, KOAZON, INBEEK)" +
                "VALUES(@VEAZON, @INNEVE, @ITAZON, @INCSSZ, @IN10TA, @IN08TA, @IN05TA, @INMETA, " +
                "@INOSZP, @INERSZ, @INMEGJ, @INKOMO, @KOAZON, @INBEEK)";

            command.Parameters.AddWithValue( "@VEAZON", eredmeny.Verseny );
            command.Parameters.AddWithValue( "@INNEVE", eredmeny.Indulo );
            command.Parameters.AddWithValue( "@ITAZON", eredmeny.Ijtipus );
            command.Parameters.AddWithValue( "@INCSSZ", eredmeny.Csapat );
            command.Parameters.AddWithValue( "@IN10TA", eredmeny.Talalat10 );
            command.Parameters.AddWithValue( "@IN08TA", eredmeny.Talalat8 );
            command.Parameters.AddWithValue( "@IN05TA", eredmeny.Talalat5 );
            command.Parameters.AddWithValue( "@INMETA", eredmeny.Melle );
            command.Parameters.AddWithValue( "@INOSZP", eredmeny.OsszPont );
            command.Parameters.AddWithValue( "@INERSZ", eredmeny.Szazalek );
            command.Parameters.AddWithValue( "@INMEGJ", eredmeny.Megjelent );
            command.Parameters.AddWithValue( "@INKOMO", eredmeny.KorosztalyModositott );
            command.Parameters.AddWithValue( "@KOAZON", eredmeny.KorosztalyAzonosito );
            command.Parameters.AddWithValue( "@INBEEK", eredmeny.Kor);

            try {
                command.ExecuteNonQuery( );
            } catch( SQLiteException exception ) {
                MessageBox.Show( exception.Message );
            } finally {
                command.Dispose( );
                Database.Connection.Close( );
            }
        }

        public static void Update( Model.Eredmeny.Eredmeny eredmeny ) {
            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText =
                "UPDATE Eredmények SET " +
                "VEAZON=@VEAZON," +
                "INNEVE=@INNEVE," +
                "INSOSZ=@INSOSZ," +
                "ITAZON=@ITAZON," +
                "INCSSZ=@INCSSZ," +
                "IN10TA=@IN10TA," +
                "IN08TA=@IN08TA," +
                "IN05TA=@IN05TA," +
                "INMETA=@INMETA," +
                "INOSZP=@INOSZP," +
                "INERSZ=@INERSZ," +
                "INMEGJ=@INMEGJ," +
                "INKOMO=@INKOMO," +
                "INBEEK=@INBEEK," +
                "KOAZON=@KOAZON " + "WHERE VEAZON=@VEAZON AND INNEVE=@INNEVE";

            command.Parameters.AddWithValue( "@VEAZON", eredmeny.Verseny );
            command.Parameters.AddWithValue( "@INNEVE", eredmeny.Indulo );
            command.Parameters.AddWithValue( "@INSOSZ", eredmeny.Sorszam );
            command.Parameters.AddWithValue( "@ITAZON", eredmeny.Ijtipus );
            command.Parameters.AddWithValue( "@INCSSZ", eredmeny.Csapat );
            command.Parameters.AddWithValue( "@IN10TA", eredmeny.Talalat10 );
            command.Parameters.AddWithValue( "@IN08TA", eredmeny.Talalat8 );
            command.Parameters.AddWithValue( "@IN05TA", eredmeny.Talalat5 );
            command.Parameters.AddWithValue( "@INMETA", eredmeny.Melle );
            command.Parameters.AddWithValue( "@INOSZP", eredmeny.OsszPont );
            command.Parameters.AddWithValue( "@INERSZ", eredmeny.Szazalek );
            command.Parameters.AddWithValue( "@INMEGJ", eredmeny.Megjelent );
            command.Parameters.AddWithValue( "@INKOMO", eredmeny.KorosztalyModositott );
            command.Parameters.AddWithValue( "@INBEEK", eredmeny.Kor);
            command.Parameters.AddWithValue( "@KOAZON", eredmeny.KorosztalyAzonosito );

            try {
                command.ExecuteNonQuery( );
            } catch( SQLiteException exception ) {
                MessageBox.Show( exception.Message );
            } finally {
                command.Dispose( );
                Database.Connection.Close( );
            }
        }

        public static void Remove( Model.Eredmeny.Eredmeny eredmeny ) {
            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();
            command.CommandText = "DELETE FROM Eredmények WHERE VEAZON=@VEAZON AND INNEVE=@INNEVE;";

            command.Parameters.AddWithValue( "@VEAZON", eredmeny.Verseny );
            command.Parameters.AddWithValue( "@INNEVE", eredmeny.Indulo );

            try {
                command.ExecuteNonQuery( );
            } catch( Exception e ) {
                Console.WriteLine( e );
            }

            command.Dispose( );
            Database.Connection.Close( );
        }

        public static int InduloSorszam( Model.Eredmeny.Eredmeny eredmeny ) {
            var value = -1;

            Database.Connection.Open( );
            var command = Database.Connection.CreateCommand();

            command.CommandText = "SELECT INSOSZ FROM Eredmények WHERE VEAZON=@VEAZON AND INNEVE=@INNEVE;";
            command.Parameters.AddWithValue( "@VEAZON", eredmeny.Verseny );
            command.Parameters.AddWithValue( "@INNEVE", eredmeny.Indulo );

            var reader = command.ExecuteReader();
            while( reader.Read( ) ) {
                value = reader.GetInt32( 0 );
            }
            command.Dispose( );
            Database.Connection.Close( );
            return value;
        }
    }
}