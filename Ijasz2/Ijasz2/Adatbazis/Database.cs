using System;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Ijasz2.Adatbazis {
    public sealed partial class Database {
        private SQLiteConnection Connection { get; set; }

        public Database( ) {
            Connection = new SQLiteConnection( "Data Source=adat.db; Version=3; New=False; Compress=True;" );

            if( !File.Exists( "adat.db" ) ) {
                SQLiteConnection.CreateFile( "adat.db" );
                Connection.Open( );

                var command = Connection.CreateCommand();

                const string createVersenysorozat = "CREATE TABLE Versenysorozat (VSAZON char(10) PRIMARY KEY, VSMEGN char(30), VSVESZ int);";
                const string createVerseny ="CREATE TABLE Verseny (VEAZON char(10) PRIMARY KEY, VEMEGN char(30), VEDATU char(20), VSAZON char(10), VEOSPO int NOT NULL, VEALSZ int, VEINSZ int, VELEZAR boolean, VEDUBE boolean);";
                const string createKorosztalyok ="CREATE TABLE Korosztályok (VEAZON char(10) NOT NULL, KOAZON char(10) NOT NULL, KOMEGN char(30), KOEKMI int NOT NULL, KOEKMA int NOT NULL, KONOK boolean, KOFERF boolean, KOINSN int, KOINSF int, KOEGYB boolean);";
                const string createIjtipusok ="CREATE TABLE Íjtípusok (ITAZON char(10) PRIMARY KEY, ITMEGN char(30), ITLISO int, ITERSZ int);";
                const string createEgyesuletek ="CREATE TABLE Egyesuletek (EGAZON char(30) PRIMARY KEY,EGCIME char(30),EGVENE char(30),EGVET1 char(30),EGVET2 char(30),EGVEM1 char(30),EGVEM2 char(30),EGLIST boolean,EGTASZ int);";
                const string createIndulok="CREATE TABLE Indulók (INNEVE char(30) PRIMARY KEY, INNEME char(1) NOT NULL, INSZUL char(20) NOT NULL, INVEEN char(30),INERSZ int, EGAZON char(10));";
                const string createOklevelek = "CREATE TABLE Oklevelek (" + " OKAZON char(10) PRIMARY KEY," + " OKTIPU char(30)," +
                                      " OKBETU char(30)," +
                                      " OKVENEX int, OKVENEY int, OKVENEH int, OKVENEF char(1), OKVENEM int, OKVENEI char(1)," +
                                      " OKVSNEX int, OKVSNEY int, OKVSNEH int, OKVSNEF char(1), OKVSNEM int, OKVSNEI char(1)," +
                                      " OKHELYX int, OKHELYY int, OKHELYH int, OKHELYF char(1), OKHELYM int, OKHELYI char(1)," +
                                      " OKINNEVEX int, OKINNEVEY int, OKINNEVEH int, OKINNEVEF char(1), OKINNEVEM int, OKINNEVEI char(1)," +
                                      " OKEGYEX int, OKEGYEY int, OKEGYEH int, OKEGYEF char(1), OKEGYEM int, OKEGYEI char(1)," +
                                      " OKIJTIX int, OKIJTIY int, OKIJTIH int, OKIJTIF char(1), OKIJTIM int, OKIJTII char(1)," +
                                      " OKKOROX int, OKKOROY int, OKKOROH int, OKKOROF char(1), OKKOROM int, OKKOROI char(1)," +
                                      " OKINNEMEX int, OKINNEMEY int, OKINNEMEH int, OKINNEMEF char(1), OKINNEMEM int, OKINNEMEI char(1)," +
                                      " OKDATUX int, OKDATUY int, OKDATUH int, OKDATUF char(1), OKDATUM int, OKDATUI char(1) );";

                command.CommandText = createVersenysorozat + createVerseny + createKorosztalyok + createIjtipusok +
                                      createEgyesuletek + createIndulok + createOklevelek;

                if( command.ExecuteNonQuery( ) != 0 ) {
                } // MessageBox.Show("Adatbázis hiba!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                }
                //MessageBox.Show( "Adatbázis létrehozva!", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information );
                command.Dispose( );
                Connection.Close( );

                // Biztonsági mentések mappája

                //if( !Directory.Exists( @"backup" ) ) Directory.CreateDirectory( @"backup" );
            }
            else {
                //CreateBackup( "adat_indítás_" + DateTime.Now.ToString( ).Trim( new Char[] { '-' } ).Replace( ' ', '_' ).Replace( '.', '-' ).Replace( ':', '-' ) );
            }

        }


    }
}

