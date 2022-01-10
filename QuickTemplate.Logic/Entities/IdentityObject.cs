using System.ComponentModel.DataAnnotations;

namespace QuickTemplate.Logic.Entities
{
    public abstract class IdentityObject
    {
        [Key]
        public int Id { get; set; }
    }
}
