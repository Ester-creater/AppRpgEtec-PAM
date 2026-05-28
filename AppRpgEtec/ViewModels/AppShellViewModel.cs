using AppRpgEtec.Services.Usuarios;

namespace AppRpgEtec.ViewModels;

public class AppShellViewModel : BaseViewModel
{
    private UsuarioService uService;
    public AppShellViewModel()
    {
        string token = Preferences.Get("UsuarioToken", string.Empty);
        uService = new UsuarioService(token);

        CarregarUsuarioAzure();
    }

    private byte[] foto;
    public byte[] Foto
    {
        get => foto;
        set
        {
            foto = value;
            OnPropertyChanged();
        }
    }
}