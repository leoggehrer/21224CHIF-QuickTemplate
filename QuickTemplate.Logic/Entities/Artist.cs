using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickTemplate.Logic.Entities
{
    [Table("Artist")]
    [Index(nameof(Name), IsUnique = true)]
    public class Artist : VersionObject
    {
        [MaxLength(128)]
        public string Name { get; set; }

        // Navigation properties
        public List<Album> Albums { get; set; } = new();
    }
}
