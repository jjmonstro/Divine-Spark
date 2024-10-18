using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    internal class Sala
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        //[ForeignKey("Monstro")]
        [JsonPropertyName("monstro_ID")]
        public int? MonstroId { get; set; }

        //[ForeignKey("Bau")]
        [JsonPropertyName("bau_id")]
        public int? BauId { get; set; }

        [JsonPropertyName("esquerda")]
        public int? Esquerda {  get; set; }

        [JsonPropertyName("direita")]
        public int? Direita { get; set; }

        [JsonPropertyName("frente")]
        public int? Frente { get; set; }

        [JsonPropertyName("tras")]
        public int? Tras { get; set; }

        [JsonPropertyName("imagem")]
        public string Image { get; set; }

        

        //isso aqui é da loucura da geração procedural
        /*  public bool PodeEsquerda { get; set; }
          public bool PodeFrente { get; set; }
          public bool PodeDireita { get; set; }*/

        /* public Sala(int Id, int BauId, int MonstroId, string image) { 
             this.Id = Id;
             this.BauId = BauId;
             this.MonstroId = MonstroId; 
             this.Image = image;

         }*/

    }
}
