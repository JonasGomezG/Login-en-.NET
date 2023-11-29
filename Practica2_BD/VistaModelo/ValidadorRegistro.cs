using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Practica2_BD.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_BD.VistaModelo
{
    public partial class ValidadorRegistro : ObservableValidator
    {
        public ObservableCollection<String> Errores { get; set; } = new ObservableCollection<string>();

        private String usuario;
        [Required(ErrorMessage = "Usuario es un campo obligatorio")]
        public String Usuario
        {
            get { return usuario; }
            set => SetProperty(ref usuario, value);
        }

        private String nombre;
        [Required(ErrorMessage = "Nombre es un campo obligatorio")]
        [RegularExpression(@"^a-zA-Z$", ErrorMessage = "El nombre no puede contener numeros")]
        public String Nombre
        {
            get { return nombre; }
            set => SetProperty(ref nombre, value);
        }

        private String edad;
        [Required(ErrorMessage = "Edad es un campo obligatorio")]
        [RegularExpression(@"^\d$", ErrorMessage = "Tiene que ser un entero")]
        [Range(0, 100, ErrorMessage = "La edad debe estar entre 0 y 100 años")]
        public String Edad
        {
            get { return edad; }
            set => SetProperty(ref edad, value);
        }

        private String passwd;
        [Required(ErrorMessage = "Contraseña es un campo obligatorio")]
        [MinLength(5, ErrorMessage = "La contraseña debe tener longitud mayor a 5 caracteres")]
        public String Passwd
        {
            get { return passwd; }
            set => SetProperty(ref passwd, value);
        }

        private String passwd2;
        [Required(ErrorMessage = "Repetir contraseña es un campo obligatorio")]
        [Compare(nameof(passwd), ErrorMessage = "Las contraseñas no coinciden")]
        public String Passwd2
        {
            get { return passwd2; }
            set => SetProperty(ref passwd2, value);
        }

        [RelayCommand]
        public void validar() 
        {
            ValidateAllProperties();
            Errores.Clear();
            GetErrors(nameof(Usuario)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Nombre)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Passwd)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Passwd2)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));

            if (Errores.Count == 0)
            {
                int numeroEdad;
                if (int.TryParse(Edad, out numeroEdad))
                {
                    App.usuarioRepositorio.add(new Usuario { User = Usuario, Name = Nombre, Password = Passwd , Age = numeroEdad });
                }
            }
        }

    }
}
