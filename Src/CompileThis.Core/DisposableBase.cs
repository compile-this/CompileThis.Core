namespace CompileThis
{
    using System;

    /// <summary>
    /// Base class for objects implementing <see cref="IDisposable"/>.
    /// </summary>
    public abstract class DisposableBase : IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="DisposableBase"/> is reclaimed by garbage collection.
        /// </summary>
        ~DisposableBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed
        {
            get
            {
                return _isDisposed;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Checks whether this instance has already been disposed, if so throws <see cref="ObjectDisposedException" />.
        /// </summary>
        /// <exception cref="ObjectDisposedException" />
        protected void GuardDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        /// <summary>
        /// Called when this instance is being disposed.
        /// </summary>
        /// <param name="isDisposing">If set to <c>true</c> release both managed and unmanaged resources; <c>false</c> release only unmanaged resources.</param>
        protected abstract void OnDisposing(bool isDisposing);

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }

            OnDisposing(isDisposing);

            _isDisposed = true;
        }
    }
}
