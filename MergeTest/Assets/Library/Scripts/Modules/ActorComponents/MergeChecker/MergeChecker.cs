using System.Collections.Generic;
using Library.Scripts.Core;
using Library.Scripts.Modules.Actor;
using Library.Scripts.Modules.ElementController;
using UnityEngine;

namespace Library.Scripts.Modules.ActorComponents.MergeChecker
{
    public class MergeChecker : ActorComponentBase
    {
        private bool _isChecked;

        public void StartChecked(bool state)
        {
            _isChecked = state;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!_isChecked) return;
            var mergeChecker = other.GetComponent<MergeChecker>();
            if (mergeChecker)
            {
                mergeChecker._owner.AddData(_owner.ElementDataExes);
                CommonComponents.ElementController.DestroyActor(_owner);
            }
               
        }

        private bool AllowMerge(List<ElementDataEx> elementDataExes)
        {
            var allowCount = 0;
            foreach (var ownerElementDataEx in _owner.ElementDataExes)
            {
                if (elementDataExes.Exists(
                        e => e.ElementData.AllowedConnection.Contains(ownerElementDataEx.ElementData)))
                    allowCount++;
            }

            return allowCount > 0;
        }

        private void OnTriggerExit(Collider other)
        {
            
        }
    }
}
