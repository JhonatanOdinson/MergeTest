using UnityEngine;

namespace Library.Scripts.Modules.Ui
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "ScriptableData/UI/WindowData")]
    public class WindowData : ScriptableObject
    {
        [SerializeField] private GameObject _windowRef;

        public GameObject GetWindowRef => _windowRef;
    }
}
