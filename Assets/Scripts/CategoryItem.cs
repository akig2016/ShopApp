using com.application.utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.application
{
    public class CategoryItem : MonoBehaviour,IPoolItem
    {
        [SerializeField]
        private Toggle _toggle;
        [SerializeField]
        private TMP_Text _text;
        private ToggleGroup _group;
        System.Action<bool, CategoryItem> notify;
        
        public void Reset()
        {
            _text.text = "";
            gameObject.name = "";
            _group.UnregisterToggle(_toggle);
            _toggle.group = null;
            _toggle.onValueChanged.RemoveListener(OnToggleValueChange);
            notify = null;
            _toggle.SetIsOnWithoutNotify(false);
        }

        public void SetData(string name, ToggleGroup group)
        {
            _toggle.SetIsOnWithoutNotify(false);
            _text.text = name;
            gameObject.name = name;
            _toggle.group = group;
            group.RegisterToggle(_toggle);
            _group = group;
        }
        public void SetData(string name, ToggleGroup group,System.Action<bool, CategoryItem> callback)
        {
            SetData(name, group);
            notify = callback;
            _toggle.onValueChanged.AddListener(OnToggleValueChange);
        }
        void OnToggleValueChange(bool value)
        {
            notify(value,this);
        }
    }
}