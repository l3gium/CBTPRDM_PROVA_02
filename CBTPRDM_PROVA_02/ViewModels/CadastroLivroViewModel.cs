using CBTPRDM_PROVA_02.Models;
using CBTPRDM_PROVA_02.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPRDM_PROVA_02.ViewModels
{
    public partial class CadastroLivroViewModel : ObservableObject
    {
        private readonly LivroRepository _livroRepository;

        [ObservableProperty]
        private Livro livro;

        public CadastroLivroViewModel(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;

            Livro = new Livro();
        }

        [RelayCommand]
        async Task Salvar()
        {
            if (string.IsNullOrWhiteSpace(Livro.NomeLivro) || string.IsNullOrWhiteSpace(Livro.NomeAutor))
            {
                await Shell.Current.DisplayAlert("Atenção", "O nome do Livro e Autor são obrigatórios.", "OK");
                return;
            }

            await _livroRepository.SaveLivroAsync(Livro);

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Cancelar()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
