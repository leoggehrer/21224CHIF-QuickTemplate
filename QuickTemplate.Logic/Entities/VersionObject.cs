using System.ComponentModel.DataAnnotations;

namespace QuickTemplate.Logic.Entities
{
    public abstract class VersionObject : IdentityObject
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
