using System.Collections.Generic;
using Library.Scripts.Core;
using Library.Scripts.Modules.ElementController;
using Library.Scripts.ScriptableObjects;
using Unity.Collections;
using UnityEngine;

namespace Library.Scripts.Modules.Actor
{
    public class ActorBase : MonoBehaviour
    {
        //[SerializeField] private ActorDataEx _actorDataEx; 
        [SerializeField] private ElementDataEx _baseElementDataEx;
        [SerializeField] private List<ElementDataEx> _elementsDataEx;
        [SerializeField] private ActorComponents _actorComponents;
        
        private CombinationData _combination;

        public ActorComponents ActorComponents => _actorComponents;
        public List<ElementDataEx> ElementDataExes => _elementsDataEx;
        public CombinationData Combination =>_combination;

        public void SetBaseData(ElementDataEx elementDataEx)
        {
            _baseElementDataEx = elementDataEx;
            AddData(elementDataEx);
        }

        public void AddData(ElementDataEx elementDataEx)
        {
            var element = _elementsDataEx.Find(e => e.ElementData == elementDataEx.ElementData);
            if (element is not null) element.Add(elementDataEx.Count);
            else _elementsDataEx.Add(elementDataEx);

            var combination = CommonComponents.ElementController.CheckCombination(_elementsDataEx);
            Debug.Log($"Combination: {combination}");
            if (combination)
            {
                _elementsDataEx = new List<ElementDataEx>(combination.Formula);
                _combination = combination;
            }
            else _combination = null;
        }
        public void AddData(List<ElementDataEx> elementDataEx)
        {
            elementDataEx.ForEach(AddData);
        }

        public void Init()
        {
            _actorComponents.Init(this);
        }

        public virtual void Destruct() {
            _actorComponents.Destruct();
            Destroy(gameObject);
        }
    }
}
