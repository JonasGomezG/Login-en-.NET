using Practica2_BD.Repositorios;

namespace Practica2_BD
{
    public partial class App : Application
    {

        public static UsuarioRepositorio usuarioRepositorio {  get; set; }

        public App(UsuarioRepositorio _usuarioRepositorio)
        {
            usuarioRepositorio = _usuarioRepositorio;

            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}