namespace Practica2_BD.Vista;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
        
	}

    public void cambiarVista(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vista.IncioSesion());
        
    }

   

}