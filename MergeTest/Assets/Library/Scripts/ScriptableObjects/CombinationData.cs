using System.Collections.Generic;
using Library.Scripts.Modules.ElementController;
using UnityEngine;

namespace Library.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CombinationData", menuName = "ScriptableData/Data/CombinationData")]
        public class CombinationData : ElementData
        {
            [SerializeField] private List<ElementDataEx> _formula = new ();
            public List<ElementDataEx> Formula => _formula;
            public bool CheckFormula(List<ElementDataEx> elementDatas)
            {
                var allowElementCount = 0;
                foreach (var elementDataEx in elementDatas)
                {
                    if (_formula.Exists(e=> e.ElementData == elementDataEx.ElementData && e.Count == elementDataEx.Count))
                        allowElementCount++;
                }

                Debug.Log($"AllowElementCount: {allowElementCount}/{_formula.Count} | Formula: {Name}");
                return allowElementCount == _formula.Count && elementDatas.Count == _formula.Count;
            }
        }
}
