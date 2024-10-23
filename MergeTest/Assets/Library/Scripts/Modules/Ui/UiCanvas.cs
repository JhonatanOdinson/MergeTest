using System.Collections.Generic;
using Library.Scripts.Modules.Ui.Window;
using UnityEngine;

namespace Library.Scripts.Modules.Ui
{
   public class UiCanvas : MonoBehaviour
   {
      [SerializeField] private Canvas _canvasRef;
      [SerializeField] private Transform _windowContainer;
      [SerializeField] private RectTransform _canvasRect;
      [SerializeField] private CanvasGroup _canvasGroup;

      [SerializeField] private List<WindowBase> _windowList = new();

      public void Init(IEnumerable<WindowData> windowList)
      {
         foreach (WindowData windowData in windowList)
         {
            var window = Instantiate(windowData.GetWindowRef, _windowContainer).GetComponent<WindowBase>();
            window.Init();
         }
      }

      public void Destruct()
      {
         foreach (WindowBase windowBase in _windowList)
         {
            windowBase.Destruct();
         }
      }
   }
}
