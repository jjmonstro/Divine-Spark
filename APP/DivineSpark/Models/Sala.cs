using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    internal class Sala
    {
        public int Id { get; set; }
        public int MonstroId { get; set; }
        public int BauID { get; set; }
        public string Image { get; set; }
        public bool PodeEsquerda { get; set; }
        public bool PodeFrente { get; set; }
        public bool PodeDireita { get; set; }

        
    }
}
