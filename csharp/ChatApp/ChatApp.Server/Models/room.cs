using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ChatApp.Server.Models
{
    [Table("room")]
    public class room : BaseModel
    {

        [PrimaryKey("id", false)] //indicates that never can be take null values because is created in the supabase db side 
        public long Id { get; set; }
        [Column("name")]
        public string Name{ get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
