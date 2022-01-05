using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCaleb.Models
{
    public class pessoas
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Email { get; set; }
        [Range(minimum: 18,maximum: 100)]
        public int Idade { get; set; }

    }
}