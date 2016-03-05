using System.Data.SQLite;
using System.IO;

namespace Ijasz2.Adatbazis {
    public sealed class Database {
        public Database() {
            Connection = new SQLiteConnection("Data Source=adat.db; Version=3; New=False; Compress=True;");

            if (!File.Exists("adat.db")) {
                SQLiteConnection.CreateFile("adat.db");
                Connection.Open();

                var command = Connection.CreateCommand();
                //TODO beállítani a primary key párokat!

                const string createVersenysorozat =
                    "CREATE TABLE Versenysorozat (VSAZON char(10) PRIMARY KEY, VSMEGN char(30), VSVESZ int);";
                const string createVerseny =
                    "CREATE TABLE Verseny (VEAZON char(10) PRIMARY KEY, VEMEGN char(30), VEDATU char(20), VSAZON char(10), VEOSPO int NOT NULL, VEALSZ int, VEINSZ int, VELEZAR boolean, VEDUBE boolean);";
                const string createKorosztalyok =
                    "CREATE TABLE Korosztályok (VEAZON char(10) NOT NULL, KOAZON char(10) NOT NULL, KOMEGN char(30), KOEKMI int NOT NULL, KOEKMA int NOT NULL, KONOK boolean, KOFERF boolean, KOINSN int, KOINSF int, KOEGYB boolean);";
                const string createIjtipusok =
                    "CREATE TABLE Íjtípusok (ITAZON char(10) PRIMARY KEY, ITMEGN char(30), ITLISO int, ITERSZ int);";
                const string createEgyesuletek =
                    "CREATE TABLE Egyesuletek (EGAZON char(30) PRIMARY KEY,EGCIME char(30),EGVENE char(30),EGVET1 char(30),EGVET2 char(30),EGVEM1 char(30),EGVEM2 char(30),EGLIST boolean,EGTASZ int);";
                const string createIndulok =
                    "CREATE TABLE Indulók (INNEVE char(30) PRIMARY KEY, INNEME char(1) NOT NULL, INSZUL char(20) NOT NULL, INVEEN char(30),INERSZ int, EGAZON char(10));";
                const string createOklevelek = "CREATE TABLE Oklevelek (" +
                                               "OKAZON char(30) PRIMARY KEY, OKTIPU char(30)," +
                                               "OKVENEX int, OKVENEY int, OKVENEH int, OKVENEF char(1), OKVENEB char(30), OKVENEM int, OKVENEI char(1)," +
                                               "OKVSNEX int, OKVSNEY int, OKVSNEH int, OKVSNEF char(1), OKVSNEB char(30), OKVSNEM int, OKVSNEI char(1)," +
                                               "OKHELYX int, OKHELYY int, OKHELYH int, OKHELYF char(1), OKHELYB char(30), OKHELYM int, OKHELYI char(1)," +
                                               "OKNEVEX int, OKNEVEY int, OKNEVEH int, OKNEVEF char(1), OKNEVEB char(30), OKNEVEM int, OKNEVEI char(1)," +
                                               "OKEGYEX int, OKEGYEY int, OKEGYEH int, OKEGYEF char(1), OKEGYEB char(30), OKEGYEM int, OKEGYEI char(1)," +
                                               "OKIJTIX int, OKIJTIY int, OKIJTIH int, OKIJTIF char(1), OKIJTIB char(30), OKIJTIM int, OKIJTII char(1)," +
                                               "OKKOROX int, OKKOROY int, OKKOROH int, OKKOROF char(1), OKKOROB char(30), OKKOROM int, OKKOROI char(1)," +
                                               "OKNEMEX int, OKNEMEY int, OKNEMEH int, OKNEMEF char(1), OKNEMEB char(30), OKNEMEM int, OKNEMEI char(1)," +
                                               "OKDATUX int, OKDATUY int, OKDATUH int, OKDATUF char(1), OKDATUB char(30), OKDATUM int, OKDATUI char(1));";

                const string createEredmenyek =
                    "CREATE TABLE Eredmények(VEAZON char(10), INNEVE char(30) NOT NULL, INSOSZ INTEGER PRIMARY KEY AUTOINCREMENT, ITAZON char(10), INCSSZ int, " +
                    "IN10TA int, IN08TA int, IN05TA int, INMETA int, INOSZP int, INERSZ int, INMEGJ boolean, INKOMO boolean, KOAZON char(10),UNIQUE(INNEVE, VEAZON));";


                command.CommandText = createVersenysorozat + createVerseny + createKorosztalyok + createIjtipusok +
                                      createEgyesuletek + createIndulok + createOklevelek + createEredmenyek;

                if (command.ExecuteNonQuery() != 0) {
                } // MessageBox.Show("Adatbázis hiba!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show( "Adatbázis létrehozva!", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information );
                command.Dispose();
                Connection.Close();

                // Biztonsági mentések mappája

                //if( !Directory.Exists( @"backup" ) ) Directory.CreateDirectory( @"backup" );
            }
        }

        public static SQLiteConnection Connection { get; private set; }
    }
}