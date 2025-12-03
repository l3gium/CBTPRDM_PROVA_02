using CBTPRDM_PROVA_02.ViewModels;

namespace CBTPRDM_PROVA_02.Views;

public partial class EditarLivro : ContentPage
{
	public EditarLivro(EditarLivroViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}