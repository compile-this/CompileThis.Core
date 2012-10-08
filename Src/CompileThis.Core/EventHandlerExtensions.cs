namespace CompileThis
{
    using System;

    public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler handler, object sender, EventArgs e)
        {
            var handlerReference = handler;
            if (handlerReference != null)
            {
                handlerReference(sender, e);
            }
        }

        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs e)
            where TEventArgs : EventArgs
        {
            var handlerReference = handler;
            if (handlerReference != null)
            {
                handlerReference(sender, e);
            }
        }
    }
}
