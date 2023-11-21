using Practica2_BD.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_BD.Repositorios
{
    public class UsuarioRepositorio
    {
        private String ruta;

        private SQLiteConnection conexion;

        public UsuarioRepositorio(String ruta2) 
        {
            ruta = ruta2;
            conexion = new SQLiteConnection(ruta);
            System.Diagnostics.Debug.WriteLine($"La ruta es: {ruta}");

            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Usuarios")) 
            {
                conexion.CreateTable<Usuario>();
            }

        }

        public void add(Usuario usuario) 
        {
            try 
            {
                conexion.Insert(usuario);
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed")) 
                {
                    // add en lista de errores user registrado 
                }
                else
                {
                    // add en lisa de errores error inesperado
                }
            }
            finally 
            {
                // ir a la pagina de inicio de sesion
            }
        }
    }
}
