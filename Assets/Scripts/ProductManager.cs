using com.application.communication;
using com.application.models;
using com.application.utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace com.application 
{
    public class ProductManager : MonoBehaviour
    {
        private ProductCatalogue _productCatalouge;
        [SerializeField]
        private Transform _productsParent;
        [SerializeField]
        private ProductItem _productItem;
        private Pool<ProductItem> _productPool;

        private void Start()
        {
            _productPool = new Pool<ProductItem>(_productItem, _productsParent);
            LoadProducts();
            FindObjectOfType<FilterManager>().PopulateFilter(_productCatalouge.Catogries);
            Communication.Instance.ApplyFilterNotifier.AddListener(ApplyFilter);
        }
        public void LoadProducts()
        {
            //Data fetched using simulator class.
            //Can be replaced with an api which fetches data from server.
            _productCatalouge = JsonUtility.FromJson<ProductCatalogue>(DataSimulator.SimulateProductCatalouge());
            foreach(var prod in _productCatalouge.Products)
            {
                ProductItem prodItem = _productPool.Get();
                prodItem.SetDetails(prod);
            }
        }
        void ApplyFilter(CategoryFilter filter)
        {
            _productPool.ReleaseAll();
            Debug.Log(_productCatalouge.Products.Count);
            IEnumerable<ProductModel> items = string.IsNullOrEmpty(filter.Category)?_productCatalouge.Products:
                _productCatalouge.Products.Where(p => p.Category.Equals(filter.Category));
            int count = items.Count();
            IEnumerable<ProductModel> finalItems;
            if (items !=null && !string.IsNullOrEmpty(filter.SubCategory))
            {
                finalItems = items.Where(p => p.Subcategory.Equals(filter.SubCategory));
            }
            else
            {
                finalItems = items;
            }
            int finalItemscount = finalItems.Count();
            Debug.Log(count+" "+ finalItemscount+ filter.Category+ filter.SubCategory);
            foreach (var item in finalItems)
            {
                Debug.Log(item.Title);
                var poolItem = _productPool.Get();
                poolItem.SetDetails(item);
            }
        }
        private void OnDestroy()
        {
            Communication.Instance.ApplyFilterNotifier.RemoveListener(ApplyFilter);
        }
    }   
}
