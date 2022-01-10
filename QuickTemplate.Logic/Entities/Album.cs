using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickTemplate.Logic.Entities
{
    [Table("Album")]
    public class Album : VersionObject
    {
        public int ArtistId { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }

        // Navigation
        public Artist Artist { get; set; }
    }
}
