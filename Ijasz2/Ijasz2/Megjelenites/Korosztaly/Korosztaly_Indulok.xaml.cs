using Ijasz2.Model.Korosztaly;

namespace Ijasz2.Megjelenites.Korosztaly {
    /// <summary>
    ///     Interaction logic for Korosztaly_Indulok.xaml
    /// </summary>


    public partial class Korosztaly_Indulok {
        public Korosztaly_Indulok( string versenyAzonosito, string korosztalyAzonosito ) {
            InitializeComponent( );
            var tagok = VersenyKorosztalyok.Tagok( versenyAzonosito, korosztalyAzonosito );

            TagokGrid.ItemsSource = tagok;
        }




    }
}