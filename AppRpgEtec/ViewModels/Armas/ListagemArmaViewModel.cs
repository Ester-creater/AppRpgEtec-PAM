using AppRpgEtec.Models;
using AppRpgEtec.Services.Armas;
using AppRpgEtec.Services.Personagens;
using System.Collections.ObjectModel;

namespace AppRpgEtec.ViewModels.Armas;

public class ListagemArmaView : BaseViewModel
{

    private ArmasService aService;
    public ObservableCollection<Arma> Armas { get; set; }

    public ListagemArmaView()
	{
        string token = Preferences.Get("UsuarioToken", string.Empty);
        aService = new ArmasService(token);
        Armas = new ObservableCollection<Arma>();

        _ = ObterArmas();
    }

    public async Task ObterArmas()
    {
        try //Junto com o catch evitará que erros fechem o aplicativo
        {
            Armas = await aService.GetArmasAsync();
            OnPropertyChanged(nameof(Armas));
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage
                .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
        }
    }



}