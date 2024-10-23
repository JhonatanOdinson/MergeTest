using System.Collections.Generic;
using Library.Scripts.Modules.ElementController;
using UnityEngine;

namespace Library.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CombinationData", menuName = "ScriptableData/Data/CombinationData")]
        public class CombinationData : ScriptableObject
        {
            [SerializeField] private string _name;
            [SerializeField] private Sprite _icon;
            [SerializeField] private List<ElementDataEx> _formula = new ();

            public string Name => _name;
            public Sprite Icon => _icon;

            public bool CheckFormula(List<ElementDataEx> elementDatas)
            {
                return _formula == elementDatas;
            }
        }
}
