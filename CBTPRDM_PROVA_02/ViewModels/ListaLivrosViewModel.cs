using CBTPRDM_PROVA_02.Models;
using CBTPRDM_PROVA_02.Repositories;
using CBTPRDM_PROVA_02.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPRDM_PROVA_02.ViewModels
{
    public partial class ListaLivrosViewModel : ObservableObject
    {
        private readonly LivroRepository _livroRepository;

        [ObservableProperty]
        private ObservableCollection<Livro> livros;

        public ListaLivrosViewModel(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
            Livros = new ObservableCollection<Livro>();

            _ = LoadLivros();
        }

        [RelayCommand]
        async Task LoadLivros()
        {
            var lista = await _livroRepository.GetLivrosAsync();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Livros.Clear();
                foreach (var livro in lista)
                {
                    Livros.Add(livro);
                }
            });
        }

        [RelayCommand]
        async Task GoToCadastroPage()
        {
            await Shell.Current.GoToAsync(nameof(CadastrarLivro));
        }

        [RelayCommand]
        async Task GoToEdicaoPage(Livro livro)
        {
            if (livro == null)
                return;

            var parameters = new Dictionary<string, object>
            {
                ["LivroData"] = livro
            };

            await Shell.Current.GoToAsync(nameof(EditarLivro), parameters);
        }

        [RelayCommand]
        async Task GoToCreditosPage()
        {
            await Shell.Current.GoToAsync(nameof(Creditos));
        }

        [RelayCommand]
        async Task GoToLocalizacaoPage()
        {
            await Shell.Current.GoToAsync(nameof(Localizacao));
        }

        [RelayCommand]
        async Task DeleteLivro(Livro livroToDelete)
        {
            bool confirmed = await Shell.Current.DisplayAlert(
                "Confirmar Exclusão",
                $"Você deseja excluir o livro '{livroToDelete.NomeLivro}'?", 
                "Sim", 
                "Cancelar");

            if (confirmed)
            {
                await _livroRepository.DeleteLivroAsync(livroToDelete);
                Livros.Remove(livroToDelete);
            }
        }

        
    }
}
