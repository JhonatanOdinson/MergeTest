using Library.Scripts.Core;
using Library.Scripts.Interrfaces;
using Library.Scripts.ScriptableObjects;
using UnityEngine;

namespace Library.Scripts.Modules.Ui.Window.UiInventoryWindow
{
    public class UiInventoryHandler : MonoBehaviour,IWindowHandler
    {
        private UiInventoryWindow _window;
        private SpawnManager.SpawnManager _spawnManager;

        public void Init(WindowBase window)
        {
            _window = (UiInventoryWindow)window;
            _spawnManager = GameDirector.GetEnterPoint.SceneComponentsRef.SpawnManager;
        }

        public void OnCreateElementHandler(ElementData elementData)
        {
            _spawnManager.SpawnActor(elementData);
        }
    }
}
