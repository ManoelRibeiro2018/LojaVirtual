using LojaVirtual.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Gender { get; set; }

        public string Cpf { get; set; }

        public string Phone { get; set; }
        public string Role { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
