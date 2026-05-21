//using Android.Locations;
using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Collections.ObjectModel;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace AppRpgEtec.ViewModels.Usuarios;

public class LocalizacaoViewModel : BaseViewModel
{
    private UsuarioService uService;
    public LocalizacaoViewModel()
    {
        string token = Preferences.Get("UsuarioToken", string.Empty);
        uService = new UsuarioService(token);
    }
	private Map meuMapa;
	public Map MeuMapa
	{
		get => meuMapa;
		set
		{
			if (value != null)
			{
				meuMapa = value;
				OnPropertyChanged();
			}
		}

	}

    public async void IncializarMapa()
    {
        try
        {
            Location location = new Location(-23.5200241d, -46.596498d);
            Pin pinEtec = new Pin()
            {
                Type = PinType.Place,
                Label = "Etec Horácio",
                Address = "Rua alcântara, 113, Vila Guilherme",
                Location = location

            };
            

            Map map = new Map();
            MapSpan mapSpan = MapSpan
                .FromCenterAndRadius(location, Distance.FromKilometers(5));
            map.Pins.Add(pinEtec);
            map.MoveToRegion(mapSpan);

            MeuMapa = map;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage
                .DisplayAlert("Erro", ex.Message, "OK");
        }

    }

    public async void ExibirUsuariosMapa()
    {
        try
        {
            ObservableCollection<Usuario> ocUsuarios = await uService.GetUsuariosAsync();
            List<Usuario> listaUsuarios = new List<Usuario>(ocUsuarios);
            Map map = new Map();

            foreach (Usuario u in listaUsuarios)
            {
                if (u.Latitude != null && u.Longitude != null)
                {
                    double latidude = (double)u.Latitude;
                    double longitude = (double)u.Longitude;
                    Location location = new Location(latidude, longitude);

                    Pin pinAtual = new Pin()
                    {
                        Type = PinType.Place,
                        Label = u.Username,
                        Address = $"E-mail: {u.Email}",
                        Location = location
                    };
                    map.Pins.Add(pinAtual);
                }
            }
            MeuMapa = map;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
        }
     }


}