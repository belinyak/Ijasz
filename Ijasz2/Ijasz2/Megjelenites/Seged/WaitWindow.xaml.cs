using System.ComponentModel;

namespace Ijasz2.Megjelenites.Seged {
    /// <summary>
    /// Interaction logic for WaitWindow.xaml
    /// TODO loading process bar
    /// </summary>
    public partial class WaitWindow {
        public WaitWindow( string content ) {
            InitializeComponent( );
            Title = content;
        }
    }
}
