using CommunityToolkit.Mvvm.ComponentModel;
using Practica2_BD.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_BD.VistaModelo
{
    public class ValidadorInicioSesion : ObservableValidator
    {
        public ObservableCollection<String> Errores { get; set; } = new ObservableCollection<string>();

        private String usuario;
        [Required(ErrorMessage = "Usuario es un campo obligatorio")]
        public String Usuario
        {
            get { return usuario; }
            set => SetProperty(ref usuario, value);
        }

        public void comprobarUsuario()
        {
            if (App.usuarioRepositorio.devolverRuta().Table<Usuario>().Where(c => c.User == Usuario).Count() > 0)
            {
                Errores.Add("El usuario ya está registrado");
            }

        }
    }

    


}
