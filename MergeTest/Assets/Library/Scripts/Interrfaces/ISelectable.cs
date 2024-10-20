using UnityEngine;

namespace Library.Scripts.Interfaces
{
    public interface ISelectable
    {
        GameObject GetSelected();
        void Select();
        void Deselect();
        void Submit();
        void Wrong();
    }
}
