using CBTPRDM_PROVA_02.ViewModels;

namespace CBTPRDM_PROVA_02.Views;

public partial class CadastrarLivro : ContentPage
{
	public CadastrarLivro(CadastroLivroViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}