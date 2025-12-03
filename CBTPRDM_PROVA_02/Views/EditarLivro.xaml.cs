using CBTPRDM_PROVA_02.ViewModels;

//Desenvolvido por Beatriz Bastos Borges e Miguel Luizatto Alves

namespace CBTPRDM_PROVA_02.Views;

public partial class EditarLivro : ContentPage
{
	public EditarLivro(EditarLivroViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}