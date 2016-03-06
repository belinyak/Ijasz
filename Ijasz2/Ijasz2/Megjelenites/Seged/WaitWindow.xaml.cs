using System.ComponentModel;
using System.Threading;

namespace Ijasz2.Megjelenites.Seged {
    /// <summary>
    /// Interaction logic for WaitWindow.xaml
    /// </summary>
    public partial class WaitWindow {
        public WaitWindow( string content ) {
            InitializeComponent( );
            Title = content;
        }

        protected override void OnClosing( CancelEventArgs e ) {
            Title = "Kész";
            Thread.Sleep( 1000 );
            base.OnClosing( e );
        }
    }
}
