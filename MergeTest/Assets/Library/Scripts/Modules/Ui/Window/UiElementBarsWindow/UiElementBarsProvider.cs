using Library.Scripts.Core;
using UnityEngine;

namespace Library.Scripts.Modules.Ui.Window.UiElementBarsWindow
{
    public class UiElementBarsProvider : MonoBehaviour
    {
        private UiElementBarsWindow _window;
        private ElementController.ElementController _elementController;
        
        public void Init(WindowBase window)
        {
            _window = (UiElementBarsWindow)window;
            _elementController = CommonComponents.ElementController;
            CommonComponents.UiCanvas.OnUpdateWindow += UpdateBars;
            ShowWindow();
        }

        private void UpdateBars()
        {
            _window.UpdateBars(_elementController.GetActors);
        }

        public void ShowWindow()
        {
            _window.UpdateBars(_elementController.GetActors);
            _window.Show();
        }

        public void HideWindow()
        {
            
        }

        public void FreeWindow()
        {
            
        }
    }
}
