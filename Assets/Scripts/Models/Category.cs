
using System.Collections.Generic;
using UnityEngine;

namespace com.application.models
{
    [System.Serializable]
    public class Category
    {
        public Category(string name, List<string> subcatogries)
        {
            _name = name;
            _subcategories = subcatogries;
        }
        [SerializeField]
        private string _name;
        public string Name { get => _name; }
        [SerializeField]
        private List<string> _subcategories;
        public List<string> Subcategories { get => _subcategories; }        
    }   
}
