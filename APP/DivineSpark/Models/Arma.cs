using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Dano { get; set; }
        public string Descricao { get; set; }
        public bool Possui { get; set; }
        public string Image { get; set; }

    }
}
