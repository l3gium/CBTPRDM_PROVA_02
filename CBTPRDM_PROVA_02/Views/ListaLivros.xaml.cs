using CBTPRDM_PROVA_02.ViewModels;

namespace CBTPRDM_PROVA_02.Views
{
    public partial class ListaLivros : ContentPage
    {
        public ListaLivros(ListaLivrosViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ListaLivrosViewModel)?.LoadLivrosCommand.Execute(null);
        }
    }
}