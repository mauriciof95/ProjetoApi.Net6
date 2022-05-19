namespace Models
{
    public class PerfilPermissao : BaseModel
    {
        public long perfil_id { get; set; }
        public string permissao { get; set; }
        public Perfil perfil { get; set; }
    }
}
