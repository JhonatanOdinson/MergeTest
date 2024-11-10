using System.Collections.Generic;
using UnityEngine;

namespace Library.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "elementData", menuName = "ScriptableData/Data/ElementData")]
    public class ElementData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Color _elementColor;
        [SerializeField] private List<ElementData> _allowedConnection = new ();

        public string Name => _name;
        public Sprite Icon => _icon;
        public Color ElementColor => _elementColor;
        public List<ElementData> AllowedConnection => _allowedConnection;
    }
}
