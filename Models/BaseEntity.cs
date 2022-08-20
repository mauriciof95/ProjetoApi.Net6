using System;

namespace Models
{
    public class BaseEntity
    {
        public Guid id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
