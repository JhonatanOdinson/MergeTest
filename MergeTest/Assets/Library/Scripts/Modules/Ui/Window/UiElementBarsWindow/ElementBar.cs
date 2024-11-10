using System;
using System.Collections.Generic;
using Library.Scripts.Modules.Actor;
using Library.Scripts.Modules.ElementController;
using Library.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Library.Scripts.Modules.Ui.Window.UiElementBarsWindow
{
    public class ElementBar : PoolableItem
    {
        [SerializeField] private TextMeshProUGUI _elementName;
        [SerializeField] private TextMeshProUGUI _combinationName;
        [SerializeField] private ActorBase _owner;
      
        
        public ActorBase Owner => _owner;

        public void Init(ActorBase actorBase)
        {
            _owner = actorBase;
            gameObject.SetActive(true);
        }

        public void UpdateBarName(List<ElementDataEx> elementDataExes, CombinationData combination)
        {
            foreach (var elementDataEx in elementDataExes)
            {
                string count = elementDataEx.Count == 1 ? "" : elementDataEx.Count.ToString();
                _elementName.text += $"{elementDataEx.ElementData.Name}{count}";
            }
            _combinationName.gameObject.SetActive(combination);
            if(combination)
                _combinationName.text = $"({combination.Name})";

        }

        public void UpdateTransform()
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(_owner.transform.position);
        }

        public override void Free()
        {
            gameObject.SetActive(false);
            _elementName.text = string.Empty;
        }
    }
}
