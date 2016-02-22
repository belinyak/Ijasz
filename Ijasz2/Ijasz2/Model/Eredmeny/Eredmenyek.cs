using System.Collections.ObjectModel;

namespace Ijasz2.Model.Eredmeny {
    public class Eredmenyek {
        public ObservableCollection<Eredmeny> _eredmenyek;

        /// <summary> |
        /// TODO adatbazis hozzaadas |
        /// model add |
        /// </summary>
        /// <param name="eredmeny"></param>
        public void Add( Eredmeny eredmeny ) {
            _eredmenyek.Add( eredmeny );
        }

        /// <summary> |
        /// TODO adatbazis modositas |
        /// model update |
        /// </summary>
        /// <param name="eredmeny"></param>
        public void Update( Eredmeny eredmeny ) {
            foreach( var eredmeny1 in _eredmenyek ) {
                if( eredmeny1.Indulo.Equals( eredmeny.Indulo ) ) {
                    eredmeny1.Sorszam = eredmeny.Sorszam;
                    eredmeny1.Ijtipus = eredmeny.Ijtipus;
                    eredmeny1.Csapat = eredmeny.Csapat;
                    eredmeny1.Talalat10 = eredmeny.Talalat10;
                    eredmeny1.Talalat8 = eredmeny.Talalat8;
                    eredmeny1.Talalat5 = eredmeny.Talalat5;
                    eredmeny1.Melle = eredmeny.Melle;
                    eredmeny1.OsszPont = eredmeny.OsszPont;
                    eredmeny1.Szazalek = eredmeny.OsszPont;
                    eredmeny1.Megjelent = eredmeny.Megjelent;
                    eredmeny1.KorosztalyModositott = eredmeny.KorosztalyModositott;
                    eredmeny1.KorosztalyAzonosito = eredmeny.KorosztalyAzonosito;
                }
            }
        }
    }
}
