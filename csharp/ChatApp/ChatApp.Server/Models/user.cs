
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ChatApp.Server.Models
{
    [Table("user")]
    public class user : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("avatar")]
        public string AvatarUrl { get; set; }
        [Column("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
