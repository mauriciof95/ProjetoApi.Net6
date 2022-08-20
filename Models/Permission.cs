namespace Models
{
    public class Permission : BaseEntity
    {
        public long role_id { get; set; }
        public string permission { get; set; }
        public Role perfil { get; set; }
    }
}
