using com.application.communication;
using com.application.models;
using com.application.utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.application
{
    public class ProductItem : MonoBehaviour , IPoolItem
    {
        [SerializeField]
        private NetworkImage _productImage;
        [SerializeField]
        private TMP_Text _title;
        [SerializeField]
        private TMP_Text _price;
        [SerializeField]
        private Button _exploreButton;
        ProductModel _data;
        private void Awake()
        {
            _exploreButton.onClick.AddListener(OnClick);
        }
        void OnClick()
        {
            if(_data!=null) Communication.Instance.ShowProductDetails.Notify(_data);
        }
        public void Reset()
        {
            _title.text="";
            _price.text = "";
            _productImage.Set("");
        }        
        public void SetDetails(ProductModel data)
        {
            _title.text = data.Title;
            _price.text = $"$ {data.Price}";
            _productImage.Set(data.ImageUrl);
            _data = data;
        }
        void OnDestroy()
        {
            _exploreButton.onClick.AddListener(OnClick);
        }
    }    
}

