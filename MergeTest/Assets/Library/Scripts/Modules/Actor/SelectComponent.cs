using Library.Scripts.Interfaces;
using UnityEngine;

namespace Library.Scripts.Modules.Actor
{
    public class SelectComponent : ActorComponentBase, ISelectable
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _selectMaterial;
        [SerializeField] private Material _deselectMaterial;
        [SerializeField] private Material _submitMaterial;
        [SerializeField] private Material _wrongMaterial;

        private bool _isSelected;

        public override void Init(ActorBase owner)
        {
            base.Init(owner);
            
        }

        public GameObject GetSelected()
        {
            return _owner.gameObject;
        }

        public void Select()
        {   
            if(_isSelected) return;
            _meshRenderer.material = _selectMaterial;
            _isSelected = true;
        }

        public void Deselect()
        {
            if(!_isSelected) return;
            _meshRenderer.material = _deselectMaterial;
            _isSelected = false;
        }

        public void Submit()
        {
            _meshRenderer.material = _submitMaterial;
        }

        public void Wrong()
        {
            _meshRenderer.material = _wrongMaterial;
        }
    }
}
