using System.Collections.Generic;
using Library.Scripts.ScriptableObjects;
using Modules.Tool.UniversalPool;
using UnityEngine;

namespace Library.Scripts.Modules.Ui.Window.UiInventoryWindow
{
    public class UiInventoryWindow : WindowBase
    {
        [SerializeField] private UiInventoryProvider _provider;
        [SerializeField] private UiInventoryHandler _handler;
        [SerializeField] private UniversalPool<ElementItem> _elementPool;

        public override void Init()
        {
            base.Init();
            _elementPool.Initialize();
            _provider.Init(this);
            _handler.Init(this);
        }

        public void UpdateData(List<ElementData> elementDatas)
        {
            foreach (var elementData in elementDatas)
            {
               var element = _elementPool.Take();
               element.Init();
               element.UpdateElement(elementData);
               element.OnElementClick += CreateElement;
            }
        }

        private void CreateElement(ElementData elementData)
        {
            _handler.OnCreateElementHandler(elementData);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            base.Show();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            base.Hide();
        }

        public override void Destruct()
        {
            _elementPool.Clear();
            base.Destruct();
        }
    }
}
