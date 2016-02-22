using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using Ijasz2.Model.Oklevel;

namespace Ijasz2.Adatbazis.Oklevel {
    public class Oklevel {
        public static ObservableCollection<Model.Oklevel.Sablon> Load( ) {
            var value = new ObservableCollection<Model.Oklevel.Sablon>();

            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand( );

            command.CommandText = "SELECT OKAZON, OKTIPU, " +
            "OKVENEX, OKVENEY, OKVENEH, OKVENEF , OKVENEB , OKVENEM , OKVENEI ," +
            "OKVSNEX, OKVSNEY, OKVSNEH, OKVSNEF , OKVSNEB , OKVSNEM , OKVSNEI ," +
            "OKHELYX, OKHELYY, OKHELYH, OKHELYF , OKHELYB , OKHELYM , OKHELYI ," +
            "OKNEVEX, OKNEVEY, OKNEVEH, OKNEVEF , OKNEVEB , OKNEVEM , OKNEVEI ," +
            "OKEGYEX, OKEGYEY, OKEGYEH, OKEGYEF , OKEGYEB , OKEGYEM , OKEGYEI ," +
            "OKIJTIX, OKIJTIY, OKIJTIH, OKIJTIF , OKIJTIB , OKIJTIM , OKIJTII ," +
            "OKKOROX, OKKOROY, OKKOROH, OKKOROF , OKKOROB , OKKOROM , OKKOROI ," +
            "OKNEMEX, OKNEMEY, OKNEMEH, OKNEMEF , OKNEMEB , OKNEMEM , OKNEMEI ," +
            "OKDATUX, OKDATUY, OKDATUH, OKDATUF , OKDATUB , OKDATUM , OKDATUI " +
            " FROM Oklevelek;";

            SQLiteDataReader reader = command.ExecuteReader( );
            while( reader.Read( ) ) {
                int index = -1;
                value.Add( new Sablon {
                    Azonosito = reader.GetString( ++index ),
                    Tipus = reader.GetString( ++index ),
                    Verseny = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    Versenysorozat = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    Helyezes = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    Indulo = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    Egyesulet = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    Ijtipus = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    Korosztaly = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    InduloNem = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    },
                    Datum = reader.IsDBNull( ++index ) == true ? null :
                    new SablonMezo {
                        X = reader.GetInt32( index ),
                        Y = reader.GetInt32( ++index ),
                        Hossz = reader.GetInt32( ++index ),
                        Formatum = reader.GetString( ++index ),
                        Betutipus = reader.GetString( ++index ),
                        BetuMeret = reader.GetInt32( ++index ),
                        Igazitas = reader.GetString( ++index )
                    }
                } );
            }
            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
            return value;
        }

        public static void Add( Model.Oklevel.Sablon sablon ) {
            Adatbazis.Database.Connection.Open( );
            var command = Adatbazis.Database.Connection.CreateCommand();

            command.CommandText = "INSERT INTO Oklevelek (" +
                                  "OKAZON, OKTIPU, " +
                                  "OKVENEX, OKVENEY, OKVENEH, OKVENEF , OKVENEB , OKVENEM , OKVENEI ," +
                                  "OKVSNEX, OKVSNEY, OKVSNEH, OKVSNEF , OKVSNEB , OKVSNEM , OKVSNEI ," +
                                  "OKHELYX, OKHELYY, OKHELYH, OKHELYF , OKHELYB , OKHELYM , OKHELYI ," +
                                  "OKNEVEX, OKNEVEY, OKNEVEH, OKNEVEF , OKNEVEB , OKNEVEM , OKNEVEI ," +
                                  "OKEGYEX, OKEGYEY, OKEGYEH, OKEGYEF , OKEGYEB , OKEGYEM , OKEGYEI ," +
                                  "OKIJTIX, OKIJTIY, OKIJTIH, OKIJTIF , OKIJTIB , OKIJTIM , OKIJTII ," +
                                  "OKKOROX, OKKOROY, OKKOROH, OKKOROF , OKKOROB , OKKOROM , OKKOROI ," +
                                  "OKNEMEX, OKNEMEY, OKNEMEH, OKNEMEF , OKNEMEB , OKNEMEM , OKNEMEI ," +
                                  "OKDATUX, OKDATUY, OKDATUH, OKDATUF , OKDATUB , OKDATUM , OKDATUI" +
                                  ") VALUES (" +
                                  "@OKAZON,  @OKTIPU, " +
                                  "@OKVENEX, @OKVENEY, @OKVENEH, @OKVENEF , @OKVENEB , @OKVENEM , @OKVENEI ," +
                                  "@OKVSNEX, @OKVSNEY, @OKVSNEH, @OKVSNEF , @OKVSNEB , @OKVSNEM , @OKVSNEI ," +
                                  "@OKHELYX, @OKHELYY, @OKHELYH, @OKHELYF , @OKHELYB , @OKHELYM , @OKHELYI ," +
                                  "@OKNEVEX, @OKNEVEY, @OKNEVEH, @OKNEVEF , @OKNEVEB , @OKNEVEM , @OKNEVEI ," +
                                  "@OKEGYEX, @OKEGYEY, @OKEGYEH, @OKEGYEF , @OKEGYEB , @OKEGYEM , @OKEGYEI ," +
                                  "@OKIJTIX, @OKIJTIY, @OKIJTIH, @OKIJTIF , @OKIJTIB , @OKIJTIM , @OKIJTII ," +
                                  "@OKKOROX, @OKKOROY, @OKKOROH, @OKKOROF , @OKKOROB , @OKKOROM , @OKKOROI ," +
                                  "@OKNEMEX, @OKNEMEY, @OKNEMEH, @OKNEMEF , @OKNEMEB , @OKNEMEM , @OKNEMEI ," +
                                  "@OKDATUX, @OKDATUY, @OKDATUH, @OKDATUF , @OKDATUB , @OKDATUM , @OKDATUI" +
                                  ");";
            command.Parameters.Add( new SQLiteParameter( "@OKAZON", sablon.Azonosito ) );
            command.Parameters.Add( new SQLiteParameter( "@OKTIPU", sablon.Tipus ) );

            command.Parameters.Add( new SQLiteParameter( "@OKVENEX", sablon.Verseny?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEY", sablon.Verseny?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEH", sablon.Verseny?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEF", sablon.Verseny?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEB", sablon.Verseny?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEM", sablon.Verseny?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEI", sablon.Verseny?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKVSNEX", sablon.Versenysorozat?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEY", sablon.Versenysorozat?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEH", sablon.Versenysorozat?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEF", sablon.Versenysorozat?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEB", sablon.Versenysorozat?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEM", sablon.Versenysorozat?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEI", sablon.Versenysorozat?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKHELYX", sablon.Helyezes?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYY", sablon.Helyezes?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYH", sablon.Helyezes?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYF", sablon.Helyezes?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYB", sablon.Helyezes?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYM", sablon.Helyezes?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYI", sablon.Helyezes?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKNEVEX", sablon.Indulo?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEY", sablon.Indulo?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEH", sablon.Indulo?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEF", sablon.Indulo?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEB", sablon.Indulo?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEM", sablon.Indulo?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEI", sablon.Indulo?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKEGYEX", sablon.Egyesulet?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEY", sablon.Egyesulet?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEH", sablon.Egyesulet?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEF", sablon.Egyesulet?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEB", sablon.Egyesulet?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEM", sablon.Egyesulet?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEI", sablon.Egyesulet?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKIJTIX", sablon.Ijtipus?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIY", sablon.Ijtipus?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIH", sablon.Ijtipus?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIF", sablon.Ijtipus?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIB", sablon.Ijtipus?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIM", sablon.Ijtipus?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTII", sablon.Ijtipus?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKKOROX", sablon.Korosztaly?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROY", sablon.Korosztaly?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROH", sablon.Korosztaly?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROF", sablon.Korosztaly?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROB", sablon.Korosztaly?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROM", sablon.Korosztaly?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROI", sablon.Korosztaly?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKNEMEX", sablon.InduloNem?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEY", sablon.InduloNem?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEH", sablon.InduloNem?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEF", sablon.InduloNem?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEB", sablon.InduloNem?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEM", sablon.InduloNem?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEI", sablon.InduloNem?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKDATUX", sablon.Datum?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUY", sablon.Datum?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUH", sablon.Datum?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUF", sablon.Datum?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUB", sablon.Datum?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUM", sablon.Datum?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUI", sablon.Datum?.Igazitas ) );

            try {
                command.ExecuteNonQuery( );
            } catch( SQLiteException exception ) {
                MessageBox.Show( exception.Message );
            } finally {
                command.Dispose( );
                Adatbazis.Database.Connection.Close( );
            }
        }

        public static void Update( Model.Oklevel.Sablon sablon ) {
            Adatbazis.Database.Connection.Open( );
            SQLiteCommand command = Adatbazis.Database.Connection.CreateCommand();
            command.CommandText = "UPDATE Oklevelek SET " +
                                  "OKAZON=@OKAZON, " +
                                  "OKTIPU=@OKTIPU, " +
                                  "OKVENEX=@OKVENEX, " +
                                  "OKVENEY=@OKVENEY, " +
                                  "OKVENEH=@OKVENEH, " +
                                  "OKVENEF=@OKVENEF, " +
                                  "OKVENEB=@OKVENEB, " +
                                  "OKVENEM=@OKVENEM, " +
                                  "OKVENEI=@OKVENEI, " +
                                  "OKVSNEX=@OKVSNEX, " +
                                  "OKVSNEY=@OKVSNEY, " +
                                  "OKVSNEH=@OKVSNEH, " +
                                  "OKVSNEF=@OKVSNEF, " +
                                  "OKVSNEB=@OKVSNEB, " +
                                  "OKVSNEM=@OKVSNEM, " +
                                  "OKVSNEI=@OKVSNEI, " +
                                  "OKHELYX=@OKHELYX, " +
                                  "OKHELYY=@OKHELYY, " +
                                  "OKHELYH=@OKHELYH, " +
                                  "OKHELYF=@OKHELYF, " +
                                  "OKHELYB=@OKHELYB, " +
                                  "OKHELYM=@OKHELYM, " +
                                  "OKHELYI=@OKHELYI, " +
                                  "OKNEVEX=@OKNEVEX, " +
                                  "OKNEVEY=@OKNEVEY, " +
                                  "OKNEVEH=@OKNEVEH, " +
                                  "OKNEVEF=@OKNEVEF, " +
                                  "OKNEVEB=@OKNEVEB, " +
                                  "OKNEVEM=@OKNEVEM, " +
                                  "OKNEVEI=@OKNEVEI, " +
                                  "OKEGYEX=@OKEGYEX, " +
                                  "OKEGYEY=@OKEGYEY, " +
                                  "OKEGYEH=@OKEGYEH, " +
                                  "OKEGYEF=@OKEGYEF, " +
                                  "OKEGYEB=@OKEGYEB, " +
                                  "OKEGYEM=@OKEGYEM, " +
                                  "OKEGYEI=@OKEGYEI, " +
                                  "OKIJTIX=@OKIJTIX, " +
                                  "OKIJTIY=@OKIJTIY, " +
                                  "OKIJTIH=@OKIJTIH, " +
                                  "OKIJTIF=@OKIJTIF, " +
                                  "OKIJTIB=@OKIJTIB, " +
                                  "OKIJTIM=@OKIJTIM, " +
                                  "OKIJTII=@OKIJTII, " +
                                  "OKKOROX=@OKKOROX, " +
                                  "OKKOROY=@OKKOROY, " +
                                  "OKKOROH=@OKKOROH, " +
                                  "OKKOROF=@OKKOROF, " +
                                  "OKKOROB=@OKKOROB, " +
                                  "OKKOROM=@OKKOROM, " +
                                  "OKKOROI=@OKKOROI, " +
                                  "OKNEMEX=@OKNEMEX, " +
                                  "OKNEMEY=@OKNEMEY, " +
                                  "OKNEMEH=@OKNEMEH, " +
                                  "OKNEMEF=@OKNEMEF, " +
                                  "OKNEMEB=@OKNEMEB, " +
                                  "OKNEMEM=@OKNEMEM, " +
                                  "OKNEMEI=@OKNEMEI, " +
                                  "OKDATUX=@OKDATUX, " +
                                  "OKDATUY=@OKDATUY, " +
                                  "OKDATUH=@OKDATUH, " +
                                  "OKDATUF=@OKDATUF, " +
                                  "OKDATUB=@OKDATUB, " +
                                  "OKDATUM=@OKDATUM, " +
                                  "OKDATUI=@OKDATUI " +
                                  "WHERE OKAZON=@OKAZON";

            command.Parameters.Add( new SQLiteParameter( "@OKAZON", sablon.Azonosito ) );
            command.Parameters.Add( new SQLiteParameter( "@OKTIPU", sablon.Tipus ) );

            command.Parameters.Add( new SQLiteParameter( "@OKVENEX", sablon.Verseny?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEY", sablon.Verseny?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEH", sablon.Verseny?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEF", sablon.Verseny?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEB", sablon.Verseny?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEM", sablon.Verseny?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVENEI", sablon.Verseny?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKVSNEX", sablon.Versenysorozat?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEY", sablon.Versenysorozat?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEH", sablon.Versenysorozat?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEF", sablon.Versenysorozat?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEB", sablon.Versenysorozat?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEM", sablon.Versenysorozat?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKVSNEI", sablon.Versenysorozat?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKHELYX", sablon.Helyezes?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYY", sablon.Helyezes?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYH", sablon.Helyezes?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYF", sablon.Helyezes?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYB", sablon.Helyezes?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYM", sablon.Helyezes?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKHELYI", sablon.Helyezes?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKNEVEX", sablon.Indulo?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEY", sablon.Indulo?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEH", sablon.Indulo?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEF", sablon.Indulo?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEB", sablon.Indulo?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEM", sablon.Indulo?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEVEI", sablon.Indulo?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKEGYEX", sablon.Egyesulet?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEY", sablon.Egyesulet?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEH", sablon.Egyesulet?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEF", sablon.Egyesulet?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEB", sablon.Egyesulet?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEM", sablon.Egyesulet?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKEGYEI", sablon.Egyesulet?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKIJTIX", sablon.Ijtipus?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIY", sablon.Ijtipus?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIH", sablon.Ijtipus?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIF", sablon.Ijtipus?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIB", sablon.Ijtipus?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTIM", sablon.Ijtipus?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKIJTII", sablon.Ijtipus?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKKOROX", sablon.Korosztaly?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROY", sablon.Korosztaly?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROH", sablon.Korosztaly?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROF", sablon.Korosztaly?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROB", sablon.Korosztaly?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROM", sablon.Korosztaly?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKKOROI", sablon.Korosztaly?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKNEMEX", sablon.InduloNem?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEY", sablon.InduloNem?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEH", sablon.InduloNem?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEF", sablon.InduloNem?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEB", sablon.InduloNem?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEM", sablon.InduloNem?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKNEMEI", sablon.InduloNem?.Igazitas ) );

            command.Parameters.Add( new SQLiteParameter( "@OKDATUX", sablon.Datum?.X ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUY", sablon.Datum?.Y ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUH", sablon.Datum?.Hossz ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUF", sablon.Datum?.Formatum ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUB", sablon.Datum?.Betutipus ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUM", sablon.Datum?.BetuMeret ) );
            command.Parameters.Add( new SQLiteParameter( "@OKDATUI", sablon.Datum?.Igazitas ) );

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
            command.CommandText = "DELETE FROM Oklevelek WHERE OKAZON=@OKAZON;";

            command.Parameters.Add( new SQLiteParameter( "@OKAZON", azonosito ) );

            try {
                command.ExecuteNonQuery( );
            } catch( Exception e ) {
                Console.WriteLine( e );
            }

            command.Dispose( );
            Adatbazis.Database.Connection.Close( );
        }
    }
}
