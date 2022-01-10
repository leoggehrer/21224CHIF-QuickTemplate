using QuickTemplate.Logic.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTemplate.Logic.Controllers
{
    public abstract partial class ControllerObject : IDisposable
    {
        private bool contextOwner;
        private ProjectDbContext context;

        internal ProjectDbContext Context => context;
        internal ControllerObject(ProjectDbContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            this.context = context;
            contextOwner = true;
        }
        protected ControllerObject(ControllerObject other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            context = other.context;
            contextOwner = false;
        }
        #region Dispose
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (contextOwner)
                    {
                        context.Dispose();
                    }
                    context = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ControllerObject()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose
    }
}
