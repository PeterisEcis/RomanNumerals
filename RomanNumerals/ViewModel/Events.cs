using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals.ViewModel
{
    // Here again I am not totally sure what is going on, but I found this example on the web and I have used it in previous projects
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }

    public static class EventRaiser
    {
        public static void Raise(this EventHandler handler, object sender)
        {
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
        {
            if (handler != null)
            {
                handler(sender, new EventArgs<T>(value));
            }
        }

        public static void Raise<T>(this EventHandler<T> handler, object sender, T value) where T : EventArgs
        {
            if (handler != null)
            {
                handler(sender, value);
            }
        }

        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, EventArgs<T> value)
        {
            if (handler != null)
            {
                handler(sender, value);
            }
        }
    }
}
