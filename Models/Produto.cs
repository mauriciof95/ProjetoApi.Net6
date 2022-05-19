using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Produto : BaseModel
    {
        [Required(ErrorMessage = "Informe uma descrição.")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        [JsonProperty(PropertyName = "descricao")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Informe o valor.")]
        [JsonProperty(PropertyName = "valor")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "Selecione a categoria.")]
        [JsonProperty(PropertyName = "categoria_id")]
        public long categoria_id { get; set; }

        public Categoria categoria { get; set; }

        public ICollection<MovimentacaoEstoque> movimentacoes { get; set; }
    }
}
