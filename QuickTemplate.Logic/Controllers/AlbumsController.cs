using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTemplate.Logic.Controllers
{
    public sealed class AlbumsController : GenericController<Entities.Album>
    {
        public AlbumsController()
        {
        }

        public AlbumsController(ControllerObject other) : base(other)
        {
        }
    }
}
