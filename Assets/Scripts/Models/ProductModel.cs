using UnityEngine;

namespace com.application.models
{
    [System.Serializable]
    public class ProductModel
    {
        public ProductModel(string id, string title, string imageUrl,float price,
            string category, string subcategory,string description)
        {
            _id = id;
            _title = title;
            _description = description;
            _imageUrl = imageUrl;
            _price = price;
            _category = category;
            _subcategory = subcategory;
        }
        [SerializeField]
        private string _id;
        public string Id { get => _id; }
        [SerializeField]
        private string _title;
        public string Title { get => _title; }
        [SerializeField]
        private string _imageUrl;
        public string ImageUrl { get => _imageUrl; }
        [SerializeField]
        private float _price;
        public float Price { get => _price; }
        [SerializeField]
        private string _category;
        public string Category { get => _category; }
        [SerializeField]
        private string _subcategory;
        public string Subcategory { get => _subcategory; }
        [SerializeField]
        private string _description;
        public string Description { get => _description; }
    }
}
