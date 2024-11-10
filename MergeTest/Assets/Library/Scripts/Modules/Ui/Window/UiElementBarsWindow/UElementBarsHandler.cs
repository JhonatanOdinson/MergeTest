using Library.Scripts.Core;
using Library.Scripts.Interrfaces;
using Library.Scripts.ScriptableObjects;
using UnityEngine;

namespace Library.Scripts.Modules.Ui.Window.UiElementBarsWindow
{
    public class UiElementBarsHandler : MonoBehaviour,IWindowHandler
    {
        private UiElementBarsWindow _window;
        private SpawnManager.SpawnManager _spawnManager;

        public void Init(WindowBase window)
        {
            _window = (UiElementBarsWindow)window;
            _spawnManager = GameDirector.GetEnterPoint.SceneComponentsRef.SpawnManager;
        }

        public void OnCreateElementHandler(ElementData elementData)
        {
            _spawnManager.SpawnActor(elementData);
        }
    }
}
