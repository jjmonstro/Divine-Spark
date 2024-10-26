using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Monstro
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("NOME")]
        public string Nome { get; set; }

        [JsonPropertyName("vidaMax")]
        public int VidaMax { get; set; }

        [JsonPropertyName("vidaAtual")]
        public int VidaAtual { get; set; }

        [JsonPropertyName("forca")]
        public int Forca {  get; set; }

        [JsonPropertyName("agilidade")]
        public int Agilidade { get; set; }

        [JsonPropertyName("imagem")]
        public string Image { get; set; }
    }
}
