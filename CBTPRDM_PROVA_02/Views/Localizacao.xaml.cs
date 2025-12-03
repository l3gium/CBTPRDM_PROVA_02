using CBTPRDM_PROVA_02.ViewModels;

namespace CBTPRDM_PROVA_02.Views;

public partial class Localizacao : ContentPage
{
    private readonly LocalizacaoViewModel _vm;

    public Localizacao(LocalizacaoViewModel viewModel)
    {
        InitializeComponent();
        _vm = viewModel;
        BindingContext = _vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.GetLocationCommand.ExecuteAsync(null);
    }
}