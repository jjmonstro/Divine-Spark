using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Pocao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string GanhoVida { get; set; }
        public int GanhoNivel { get; set; }
        public bool Possui {  get; set; }
        public string Image { get; set; }
    }
}
