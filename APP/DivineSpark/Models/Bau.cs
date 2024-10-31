using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class Bau
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }


        [JsonPropertyName("pocao_ID")]
        public int? PocaoId { get; set; }



        [JsonPropertyName("arma_ID")]
        public int? ArmaId { get; set; }
        
    }
}
