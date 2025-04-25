using System;

namespace RedBall50.Scripts.Args
{
    public class InteractableUIEventArgs : EventArgs
    {
        public bool Entered { get; }

        public InteractableUIEventArgs(bool entered)
        {
            Entered = entered;
        }
    }
}
