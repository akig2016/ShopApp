using com.application.singletons;
using com.application.utility.services;
using UnityEngine;
using UnityEngine.UI;
namespace com.application.utility
{
    /// <summary>
    /// Network Image can be used for getting image from urls.
    /// </summary>
    public class NetworkImage : Image
    {
        public void Set(string url)
        {
            Sprite cachedSprite;
            if (string.IsNullOrEmpty(url))
            {
                sprite = null;
                return;
            }
            if (RuntimeCachedImages.Instance.TryGetImage(url, out cachedSprite))
            {
                sprite = cachedSprite;
                return;
            }
            GetTexture(url);
        }
        void GetTexture(string url)
        {
            IRestAPIService requset = new RestAPIService(this);
            requset.GetTexureRequest(url, (isSucess, tex) => OnResponse(isSucess, tex, url));
        }
        void OnResponse(bool isSucess, Texture2D tex, string url)
        {
            if (isSucess)
            {
                Sprite downloadedSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height),
                                        new Vector2(0.5f, 0.5f), 100.0f);
                RuntimeCachedImages.Instance.TryAddImage(url, downloadedSprite);
                sprite = downloadedSprite;
            }
        }
    }
}

