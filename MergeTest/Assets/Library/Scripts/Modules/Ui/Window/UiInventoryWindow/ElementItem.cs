using System;
using Library.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Library.Scripts.Modules.Ui.Window.UiInventoryWindow
{
    public class ElementItem : PoolableItem
    {
        [SerializeField] private ElementData _elementData;
        [SerializeField] private TextMeshProUGUI _elementName;
        [SerializeField] private Image _bgImage;
        [SerializeField] private Button _button;

        public event Action<ElementData> OnElementClick; 

        public void Init()
        {
            _button.onClick.AddListener(OnElementClickHandler);
            gameObject.SetActive(true);
        }

        private void OnElementClickHandler()
        {
            OnElementClick?.Invoke(_elementData);
            Debug.Log($"Click: {_elementData.Name}");
        }

        public void UpdateElement(ElementData elementData)
        {
            _elementData = elementData;
            _elementName.text = _elementData.Name;
            _bgImage.color = _elementData.ElementColor;
        }

        public override void Free()
        {
            _button.onClick.RemoveListener(OnElementClickHandler);
            gameObject.SetActive(false);
            _elementData = null;
            _elementName.text = string.Empty;
        }
    }
}
