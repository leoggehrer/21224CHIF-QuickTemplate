using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTemplate.Logic.Controllers
{
    public sealed class ArtistsController : GenericController<Entities.Artist>
    {
        public ArtistsController()
        {
        }

        public ArtistsController(ControllerObject other) : base(other)
        {
        }
    }
}
