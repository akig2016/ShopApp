using com.application.communication;
using com.application.models;
using com.application.utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace com.application
{
    public class FilterManager : MonoBehaviour
    {
        [SerializeField]
        private Button _filterButton;
        [SerializeField]
        private GameObject _filterCheckMark;
        [SerializeField]
        private GameObject _filterParent;
        [SerializeField]
        private ToggleGroup _categoryToggles;
        [SerializeField]
        private ToggleGroup _subcategoryToggles;
        [SerializeField]
        private CategoryItem _categoryItemPrefab;
        [SerializeField]
        private Button _close;
        [SerializeField]
        private Button _applyFilter;
        [SerializeField]
        private Button _clearFilter;
        private List<Category> _categories;
        private Pool<CategoryItem> _subcategoryItemPool; 
        public bool IsFilterApplied { get; private set; } = false;
        public string Category { get; private set; } = "";
        public string Subcategory { get; private set; } = "";
        private void Start()
        {
            _subcategoryItemPool = new Pool<CategoryItem>(_categoryItemPrefab, _subcategoryToggles.transform);
            EnableSubcategory(false);
            _filterCheckMark.SetActive(IsFilterApplied);
            _filterButton.onClick.AddListener(EnableMenu);
            _close.onClick.AddListener(CloseFilter);
            _clearFilter.onClick.AddListener(ClearFilter);
            _applyFilter.onClick.AddListener(ApplyFilter);
           // Communication.Instance.EnableFilterMenuNotifier.AddListener(EnableMenu);
        }
        void EnableMenu()
        {
            _filterParent.SetActive(true);
            if (string.IsNullOrEmpty(Category))
            {
                ClearFilter();
                return;
            }
            if (_categoryToggles.AnyTogglesOn())
            {
                _categoryToggles.GetFirstActiveToggle().SetIsOnWithoutNotify(false);
            }
            var catToggle = _categoryToggles.transform.Find(Category).GetComponent<Toggle>();
            catToggle.SetIsOnWithoutNotify(true);
            OnCategoryItemSelect(true, catToggle.GetComponent<CategoryItem>());
            if (!string.IsNullOrEmpty(Subcategory))
            {
                var subCatToggle = _subcategoryToggles.transform.Find(Subcategory).GetComponent<Toggle>();
                Debug.Log(subCatToggle.name);
                subCatToggle.SetIsOnWithoutNotify(true);
            }
        }
        public void PopulateFilter(List<Category> categories)
        {
            _categories = categories;
            foreach (var cat in categories)
            {
                CategoryItem catItem = Instantiate(_categoryItemPrefab, _categoryToggles.transform, false);
                catItem.SetData(cat.Name, _categoryToggles,OnCategoryItemSelect);                
            }
        }
        void OnCategoryItemSelect(bool isSelected,CategoryItem item)
        {
            _subcategoryItemPool.ReleaseAll();
            if (!isSelected || !_categoryToggles.AnyTogglesOn())
            {
                EnableSubcategory(false);
                return;
            }
            Category cat = _categories.Find(c => c.Name.Equals(item.name));
            if(cat!=null || cat.Subcategories != null)
            {
                foreach(var subcat in cat.Subcategories)
                {
                    var catitem = _subcategoryItemPool.Get();
                    catitem.SetData(subcat, _subcategoryToggles);
                }
            }
            EnableSubcategory(true);
        }
        void EnableSubcategory(bool enable)
        {
            _subcategoryToggles.transform.parent.gameObject.SetActive(enable);
        }
        void ClearFilter()
        {
            if (_categoryToggles.AnyTogglesOn())
            {
                _categoryToggles.GetFirstActiveToggle().isOn = false;
            }            
        }      
        void ApplyFilter()
        {
            IsFilterApplied = _categoryToggles.AnyTogglesOn();
            _filterCheckMark.SetActive(IsFilterApplied);
            var activeCategoryToggle = _categoryToggles.GetFirstActiveToggle();
            Category = (IsFilterApplied && activeCategoryToggle!=null)? activeCategoryToggle.name:"";
            var activeSubcategoryToggle = _subcategoryToggles.GetFirstActiveToggle();
            Subcategory = activeSubcategoryToggle != null? activeSubcategoryToggle.name : "";
            Communication.Instance.ApplyFilterNotifier.Notify(new CategoryFilter(Category, Subcategory));
            _filterParent.SetActive(false);
        }
        void CloseFilter()
        {
            _filterParent.SetActive(false);
        }
      
        private void OnDestroy()
        {
            _subcategoryItemPool.ClearPool();
            _filterButton.onClick.RemoveListener(EnableMenu);
            _close.onClick.RemoveListener(CloseFilter);
            _clearFilter.onClick.RemoveListener(ClearFilter);
            _applyFilter.onClick.RemoveListener(ApplyFilter);
           // Communication.Instance.EnableFilterMenuNotifier.RemoveListener(EnableMenu);
        }
    }
}
