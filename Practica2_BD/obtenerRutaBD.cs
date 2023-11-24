using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_BD
{
    public class obtenerRutaBD
    {
        public static String devolverRuta(String nombreBD)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombreBD);
        }
    }
}
