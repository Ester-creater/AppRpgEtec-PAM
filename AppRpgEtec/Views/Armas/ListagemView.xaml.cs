using AppRpgEtec.ViewModels.Armas;
using AppRpgEtec.ViewModels.Personagens;

namespace AppRpgEtec.Views.Armas;

public partial class ListagemView : ContentPage
{
    ListagemArmaView viewModel;

    public ListagemView()
	{
		InitializeComponent();

        viewModel = new ListagemArmaView();
        BindingContext = viewModel;
        Title = "Armas - App Rpg Etec";

    }
}