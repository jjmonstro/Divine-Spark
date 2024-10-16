using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Bau
    {
        public int Id { get; set; }


        [ForeignKey("Pocao")]
        public int PocaoId { get; set; }
        public Pocao Pocao { get; set; }


        [ForeignKey("Arma")]
        public int ArmaId { get; set; }
        public Arma Arma { get; set; }
        public string Image { get; set; }
    }
}
