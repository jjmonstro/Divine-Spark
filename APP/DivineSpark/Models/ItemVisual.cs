using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    //É para tentar fazer funcionar o inventário, coisa do amigo
    public class ItemVisual
    {
        public string Source { get; set; }  // Caminho da imagem
        public string Descricao { get; set; }
        public float Dano { get; set; }
        public int Tipo { get; set; } // 1=aram   2=pocao
        public int GanhoNivel { get; set; }

    }
}
