using System;
using Library.Scripts.ScriptableObjects;
using UnityEngine;

namespace Library.Scripts.Modules.ElementController
{
    [Serializable]
    public class ElementDataEx 
    {
        [SerializeField] private ElementData _elementData;
        [SerializeField] private int _count;

        public ElementData ElementData => _elementData;
        public int Count => _count;
        
        public ElementDataEx (ElementData elementData)
        {
            _elementData = elementData;
            _count = 1;
        }

        public void Add(int count)
        {
            if (_elementData is CombinationData) return;
            _count += count;
        }

        public void Remove(int count)
        {
            
        }
        
    }
}
