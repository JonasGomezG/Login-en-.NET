using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_BD.Modelo
{
    [Table("Usuarios")]
    public class Usuario
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }

        [Unique]
        public String User {  get; set; }

        public String Name {  get; set; }

        public String Password { get; set; }

        public int Age {  get; set; }

    }
}
