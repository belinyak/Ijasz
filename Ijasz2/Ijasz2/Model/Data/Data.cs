using Ijasz2.Model.Egyesulet;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Model.Ijtipus;
using Ijasz2.Model.Indulo;
using Ijasz2.Model.Korosztaly;
using Ijasz2.Model.Oklevel;
using Ijasz2.Model.Verseny;
using Ijasz2.Model.Versenysorozat;

namespace Ijasz2.Model.Data {
    public class Data {
        public static Versenysorozatok Versenysorozatok;
        public static Versenyek Versenyek;
        public static VersenyKorosztalyok Korosztalyok;
        public static Ijtipusok Ijtipusok;
        public static Egyesuletek Egyesuletek;
        public static Indulok Indulok;
        //public static Model.Eredmeny.Eredmenyek Eredmenyek;
        public static VersenyEredmenyek Eredmenyek;
        public static Sablonok Sablonok;

        /// <summary>
        ///     korosztályt versennyel együtt töltjük be !!!
        ///     eredmenyt versenyyel együtt töltjük be !!!
        /// </summary>
        public Data() {
            Versenysorozatok = new Versenysorozatok();
            Versenyek = new Versenyek();
            Korosztalyok = new VersenyKorosztalyok();
            Ijtipusok = new Ijtipusok();
            Egyesuletek = new Egyesuletek();
            Indulok = new Indulok();
            Eredmenyek = new VersenyEredmenyek();
            Sablonok = new Sablonok();

            Versenyek.Load();
            Versenysorozatok.Load();
            Korosztalyok.Load();
            Ijtipusok.Load();
            Egyesuletek.Load();
            Indulok.Load();
            Eredmenyek.Load();
            Sablonok.Load();
        }
    }
}