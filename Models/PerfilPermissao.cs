using Models.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PerfilPermissao : BaseModel
    {
        public long perfil_id { get; set; }
        public string permissao { get; set; }
        public Perfil perfil { get; set; }
    }
}
