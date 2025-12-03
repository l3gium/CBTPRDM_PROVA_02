using CBTPRDM_PROVA_02.Repositories;
using CBTPRDM_PROVA_02.ViewModels;
using CBTPRDM_PROVA_02.Views;
using Microsoft.Extensions.Logging;

namespace CBTPRDM_PROVA_02
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
            builder.Services.AddSingleton<LivroRepository>();
            
            builder.Services.AddTransient<ListaLivrosViewModel>();
            builder.Services.AddTransient<ListaLivros>();

            builder.Services.AddTransient<CadastroLivroViewModel>();
            builder.Services.AddTransient<CadastrarLivro>();

            builder.Services.AddTransient<EditarLivroViewModel>();
            builder.Services.AddTransient<EditarLivro>();

            builder.Services.AddTransient<Localizacao>();
            builder.Services.AddTransient<LocalizacaoViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
