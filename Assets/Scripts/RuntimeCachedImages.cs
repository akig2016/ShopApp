using com.application.utility;
using System.Collections.Generic;
using UnityEngine;
namespace com.application.singletons
{
    /// <summary>
    /// Singleton used for caching image at runtime to load downloaded image faster.
    /// </summary>
    public class RuntimeCachedImages : Singleton<RuntimeCachedImages>
    {
        private Dictionary<string, Sprite> _cache = new Dictionary<string, Sprite>();
        public bool TryAddImage(string url, Sprite sprite)
        {
            if (_cache.ContainsKey(url)) return false;
            _cache.Add(url, sprite);
            return true;
        }
        public bool TryGetImage(string url, out Sprite sprite)
        {
            return _cache.TryGetValue(url, out sprite);
        }
        public void ClearCache()
        {
            _cache.Clear();
        }
    }
}

