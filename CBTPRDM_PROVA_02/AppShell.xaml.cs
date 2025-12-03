using CBTPRDM_PROVA_02.Views;

namespace CBTPRDM_PROVA_02
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EditarLivro), typeof(EditarLivro));
        }
    }
}
