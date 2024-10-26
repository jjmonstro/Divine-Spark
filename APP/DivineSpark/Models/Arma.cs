using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Arma
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("dano")]
        public float Dano { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("possui")]
        public int? Possui { get; set; }

        [JsonPropertyName("imagem")]
        public string Image { get; set; }

    }
}
