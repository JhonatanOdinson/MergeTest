using Library.Scripts.Core;
using UnityEngine;
namespace Library.Scripts.Modules.Ui.Window.UiInventoryWindow
{
    public class UiInventoryProvider : MonoBehaviour
    {
        private UiInventoryWindow _window;
        private ElementController.ElementController _elementController;
        
        public void Init(WindowBase window)
        {
            _window = (UiInventoryWindow)window;
            _elementController = CommonComponents.ElementController;
            ShowWindow();
        }
        
        public void ShowWindow()
        {
            _window.UpdateData(_elementController.ElementDatas);
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
