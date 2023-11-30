namespace Practica2_BD.Vista;

public partial class IncioSesion : ContentPage
{
	public IncioSesion()
	{
		InitializeComponent();
	}

	public void cambiarVista(object sender, EventArgs e) 
	{ 
		Navigation.PushAsync(new Vista.Registro());
	}

}