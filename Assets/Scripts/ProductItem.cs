using com.application.models;
using com.application.utility;
using TMPro;
using UnityEngine;
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

        public void Reset()
        {
            _title.text="";
            _price.text = "";
            _productImage.Set("");
        }

        public void SetDetails(string title, int price, string url)
        {
            _title.text = title;
            _price.text = $"$ {price}";
            _productImage.Set(url);
        }
        public void SetDetails(ProductModel data)
        {
            _title.text = data.Title;
            _price.text = $"$ {data.Price}";
            _productImage.Set(data.ImageUrl);
        }
    }    
}

