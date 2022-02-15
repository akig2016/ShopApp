using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace com.application.utility.services
{
    public interface IRestAPIService
    {
        void GetTexureRequest(string url, System.Action<bool, Texture2D> responseCallback);
    }

    /// <summary>
    /// REST Service for making GET Texture(Images) requests to server.
    /// </summary>
    public class RestAPIService : IRestAPIService
    {
        MonoBehaviour _monoRef;
        IEnumerator _coroutine;
        public RestAPIService(MonoBehaviour mono)
        {
            _monoRef = mono;
        }
        void StartRequest(IEnumerator request)
        {
            _coroutine = request;
            _monoRef.StartCoroutine(_coroutine);
        }
        void StopRequest()
        {
            if(_coroutine!=null) _monoRef.StopCoroutine(_coroutine);
        }        
        public void GetTexureRequest(string url, System.Action<bool, Texture2D> responseCallback)
        {
            StartRequest(GetTexture(url, responseCallback));            
        }
        IEnumerator GetTexture(string url, System.Action<bool, Texture2D> responseCallback)
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
            {
                yield return uwr.SendWebRequest();
                string response;
                Texture2D remoteTexture;
                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    response = uwr.error;
                    remoteTexture = new Texture2D(1, 1);
                }
                else
                {
                    remoteTexture = DownloadHandlerTexture.GetContent(uwr);
                    response = uwr.downloadHandler.text;
                }
                DebugLog("GET Texture", url, uwr.responseCode, response);
                responseCallback(uwr.result == UnityWebRequest.Result.Success, remoteTexture);
            }
            StopRequest();
        }  
        void DebugLog(string requestType, string url,long responsecode, string response)
        {
            Debug.Log($"{requestType} Request : {url} \nResponse Code : {responsecode} \nResponse :\n{response}");
        }
    }
}