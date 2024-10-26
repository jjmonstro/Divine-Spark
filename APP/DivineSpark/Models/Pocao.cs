using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Pocao
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("ganho_vida")]
        public int? GanhoVida { get; set; }

        [JsonPropertyName("ganho_nivel")]
        public int? GanhoNivel { get; set; }

        [JsonPropertyName("possui")]
        public int? Possui {  get; set; }

        [JsonPropertyName("imagem")]
        public string Image { get; set; }
    }
}
