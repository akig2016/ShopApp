using System;
using System.Collections.Generic;

namespace com.application.communication
{
    /// <summary>
    /// A generic notifier with one payload.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Notifier<T>
    {
        private Action<T> _observerList = delegate { };
        public void AddListener(Action<T> callback)
        {
            _observerList += callback;
        }
        public void RemoveListener(Action<T> callback)
        {
            _observerList -= callback;
        }
        public void RemoveAllListener()
        {
            _observerList = delegate { };
        }
        public void Notify(T data1)
        {
            _observerList(data1);
        }
    }
}
