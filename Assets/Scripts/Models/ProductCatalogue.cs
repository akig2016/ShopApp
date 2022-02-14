
using System.Collections.Generic;
using UnityEngine;

namespace com.application.models
{
    [System.Serializable]
    public class ProductCatalogue
    {
        [SerializeField]
        private List<ProductModel> _products;
        public List<ProductModel> Products { get => _products; set => _products = value; }
        [SerializeField]
        private List<Category> _catogries;
        public List<Category> Catogries { get => _catogries; set => _catogries = value; }

    }
}
