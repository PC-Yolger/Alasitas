using System;
using System.Collections.Generic;
using System.Text;

namespace Alasitas.Service
{
    public class EventObject<T> : EventArgs
    {
        public T Result { private set; get; }
        public EventObject(T result)
        {
            this.Result = result;
        }
    }

    public class EventList<T> : EventArgs
    {
        public IList<T> Result { private set; get; }

        public EventList(IList<T> result)
        {
            this.Result = result;
        }
    }
}
