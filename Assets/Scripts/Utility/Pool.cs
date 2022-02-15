using System.Collections.Generic;
using UnityEngine;
namespace com.application.utility
{
    /// <summary>
    /// Interface which is required by poolable item to implement inorder to be added to pool.
    /// </summary>
    public interface IPoolItem
    {
        void Reset();
    }
    public class Pool<T> where T : MonoBehaviour, IPoolItem
    {
        /// <summary>
        /// Generic Object Pool.
        /// </summary>
        /// <param name="prefab">Poolable item (Note: Must be derived from IPoolItem.)</param>
        /// <param name="itemParent">Transform for poolable item parent.</param>
        public Pool(T prefab, Transform itemParent)
        {
            _prefab = prefab;
            _itemParent = itemParent;
            _poolParent = new GameObject(typeof(T).Name).GetComponent<Transform>();
        }
        private Stack<T> _pool = new Stack<T>();
        private List<T> _activeItems = new List<T>();
        private T _prefab;
        private Transform _itemParent;
        private Transform _poolParent;
        /// <summary>
        /// Returns and instance of item from the pool. 
        /// If pool is empty it inflates the pool and provide instance of item. 
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            if (_pool.Count > 0)
            {
                T item = _pool.Pop();
                _activeItems.Add(item);
                item.transform.SetParent(_itemParent);
                item.gameObject.SetActive(true);
                return item;
            }
            return Inflate();
        }
        T Inflate()
        {
            T item = GameObject.Instantiate<T>(_prefab, _itemParent);
            _activeItems.Add(item);
            return item;
        }

        public void Release(T item)
        {
            SendBackToPool(item);
        }  
        /// <summary>
        /// Sends back all the items back to the pool.
        /// </summary>
        public void ReleaseAll()
        {
            foreach (var item in _activeItems)
            {
                SendBackToPool(item);
            }
            _activeItems.Clear();
        }
        void SendBackToPool(T item)
        {
            item.Reset();
            item.transform.SetParent(_poolParent);
            item.gameObject.SetActive(false);
            _pool.Push(item);
        }
        /// <summary>
        /// Reset the pool to initial state. Destroy all the created instances of items created.
        /// </summary>
        public void ClearPool()
        {
            foreach(var item in _pool)
            {
                GameObject.Destroy(item.gameObject);
            }
            foreach (var item in _activeItems)
            {
                GameObject.Destroy(item.gameObject);
            }
            _pool.Clear();
            _activeItems.Clear();
        }
    }
    
}
