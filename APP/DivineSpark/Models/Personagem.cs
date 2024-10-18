﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int VidaMax { get; set; }
        public int VidaAtual { get; set; }
        public int Forca { get; set; }
        public int Agilidade { get; set; }
        public int Nivel { get; set; }
        public string Image { get; set; }



    }
}