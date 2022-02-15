using com.application.communication;
using com.application.models;
using com.application.utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.application
{    public class ProductDetails : MonoBehaviour
    {
        [SerializeField]
        private GameObject _root;
        [SerializeField]
        private NetworkImage _productImage;
        [SerializeField]
        private TMP_Text _title;
        [SerializeField]
        private TMP_Text _details;
        [SerializeField]
        private TMP_Text _price;
        [SerializeField]
        private Button _close;
        private void Start()
        {
            Communication.Instance.ShowProductDetails.AddListener(ShowDetails);
            _close.onClick.AddListener(OnClose);
        }
        void ShowDetails(ProductModel data)
        {
            _root.SetActive(true);
            _title.text = data.Title;
            _price.text = $"$ {data.Price}";
            _productImage.Set(data.ImageUrl);
            _details.text = data.Description;
        }
        public void Reset()
        {
            _title.text = "";
            _price.text = "";
            _productImage.Set("");
            _details.text = "";
        }  
        void OnClose()
        {
            Reset();
            _root.SetActive(false);
        }
        private void OnDestroy()
        {
            Communication.Instance.ShowProductDetails.RemoveListener(ShowDetails);
            _close.onClick.RemoveListener(OnClose);
        }
    }
}

