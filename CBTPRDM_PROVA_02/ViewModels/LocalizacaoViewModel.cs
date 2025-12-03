using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Desenvolvido por Beatriz Bastos Borges e Miguel Luizatto Alves

namespace CBTPRDM_PROVA_02.ViewModels
{
    public partial class LocalizacaoViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PodeExibirLocalizacao))]
        private Location? localizacaoAtual;

        [ObservableProperty]
        private bool isBusy; 

        [ObservableProperty]
        private string? statusMensagem = "Pressione o botão para obter sua localização atual.";

        public bool PodeExibirLocalizacao => LocalizacaoAtual != null;

        public LocalizacaoViewModel()
        {
            //Task.Run(GetLocationCommand.ExecuteAsync); 
        }

        [RelayCommand]
        async Task GetLocation()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                StatusMensagem = "Tentando obter localização...";

                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status != PermissionStatus.Granted)
                {
                    StatusMensagem = "Permissão de localização negada. Ative nas configurações do dispositivo.";
                    return;
                }

                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                LocalizacaoAtual = await Geolocation.GetLocationAsync(request);

                if (LocalizacaoAtual != null)
                {
                    StatusMensagem = $"Localização obtida com sucesso!";
                }
                else
                {
                    StatusMensagem = "Não foi possível obter a localização. Verifique o GPS.";
                }
            }
            catch (FeatureNotSupportedException)
            {
                StatusMensagem = "Geolocalização não é suportada neste dispositivo.";
            }
            catch (FeatureNotEnabledException)
            {
                StatusMensagem = "O serviço de GPS está desabilitado no dispositivo.";
            }
            catch (PermissionException)
            {
                StatusMensagem = "Permissões de localização não foram concedidas.";
            }
            catch (Exception ex)
            {
                StatusMensagem = $"Erro ao obter localização: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
