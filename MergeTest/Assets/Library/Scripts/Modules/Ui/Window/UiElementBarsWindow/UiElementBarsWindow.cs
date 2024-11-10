using System.Collections.Generic;
using System.Linq;
using Library.Scripts.Modules.Actor;
using Library.Scripts.ScriptableObjects;
using Modules.Tool.UniversalPool;
using UnityEngine;

namespace Library.Scripts.Modules.Ui.Window.UiElementBarsWindow
{
    public class UiElementBarsWindow : WindowBase
    {
        [SerializeField] private UiElementBarsProvider _provider;
        [SerializeField] private UiElementBarsHandler _handler;
        [SerializeField] private UniversalPool<ElementBar> _elementPool;

        public override void Init()
        {
            base.Init();
            _elementPool.Initialize();
            _provider.Init(this);
            _handler.Init(this);
        }

        public void UpdateBars(List<ActorBase> actorList)
        {
            if (!actorList.Any()) {
                if(_elementPool.GetBusy().Any()) _elementPool.Clear();
                return;
            }

            if (_elementPool.GetBusy().Count() != actorList.Count)
            {
                _elementPool.Clear();
                foreach (var actorBase in actorList) {
                    var bar = _elementPool.Take();
                    bar.Init(actorBase);
                    bar.UpdateBarName(actorBase.ElementDataExes,actorBase.Combination);
                    bar.UpdateTransform();
                }
            }
            else
            {
                foreach (var elementBar in _elementPool.GetBusy()) {
                    elementBar.UpdateTransform();
                }
            }

            
        }

        public void FreeBar(ActorBase actorBase)
        {
            var bar = _elementPool.GetBusy().ToList().Find(e => e.Owner.GetInstanceID() == actorBase.GetInstanceID());
            _elementPool.Return(bar);
        }
        
        private void CreateElement(ElementData elementData)
        {
            
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
