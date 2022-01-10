using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickTemplate.Logic.Entities
{
    [Table("Artist")]
    public class Artist : VersionObject
    {
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
