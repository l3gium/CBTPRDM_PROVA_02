using CBTPRDM_PROVA_02.Views;

namespace CBTPRDM_PROVA_02
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CadastrarLivro), typeof(CadastrarLivro));
            Routing.RegisterRoute(nameof(EditarLivro), typeof(EditarLivro));
            Routing.RegisterRoute(nameof(Creditos), typeof(Creditos));
            Routing.RegisterRoute(nameof(Localizacao), typeof(Localizacao));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}