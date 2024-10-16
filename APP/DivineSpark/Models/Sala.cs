using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    internal class Sala
    {
        public int Id { get; set; }

        [ForeignKey("Bau")]
        public int BauId { get; set; }
        public Bau Bau { get; set; }


        [ForeignKey("Monstro")]
        public int MonstroId { get; set; }
        public Monstro Monstro { get; set; }

        public string Image { get; set; }
        //isso aqui é da loucura da geração procedural
        /*  public bool PodeEsquerda { get; set; }
          public bool PodeFrente { get; set; }
          public bool PodeDireita { get; set; }*/


    }
}
