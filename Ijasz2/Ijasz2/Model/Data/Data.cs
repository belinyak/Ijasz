using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ijasz2.Model.Egyesulet;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Model.Ijtipus;
using Ijasz2.Model.Indulo;
using Ijasz2.Model.Korosztaly;
using Ijasz2.Model.Verseny;
using Ijasz2.Model.Versenysorozat;

namespace Ijasz2.Model.Data {
    public class Data {
        public static Model.Versenysorozat.Versenysorozatok Versenysorozatok;
        public static Model.Verseny.Versenyek Versenyek;
        public static Model.Korosztaly.VersenyKorosztalyok Korosztalyok;
        public static Model.Ijtipus.Ijtipusok Ijtipusok;
        public static Model.Egyesulet.Egyesuletek Egyesuletek;
        public static Model.Indulo.Indulok Indulok;
        public static Model.Eredmeny.Eredmenyek Eredmenyek;

        /// <summary>
        /// korosztályt versennyel együtt töltjük be !!!
        /// </summary>
        public Data( ) {
            Versenysorozatok = new Versenysorozatok( );
            Versenyek = new Versenyek( );
            //Korosztalyok = new VersenyKorosztalyok();
            Ijtipusok = new Ijtipusok( );
            Egyesuletek = new Egyesuletek( );
            Indulok = new Indulok();
            Eredmenyek = new Eredmenyek();

            Versenyek.Load( );
            Versenysorozatok.Load( );
            //Korosztalyok.Load( );
            Ijtipusok.Load( );
            Egyesuletek.Load( );
            Indulok.Load();
            Eredmenyek.Load();
        }
    }
}
