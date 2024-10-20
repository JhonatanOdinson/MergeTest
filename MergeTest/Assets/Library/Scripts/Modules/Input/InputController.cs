using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Library.Scripts.Modules.Input
{
   public class InputController : MonoBehaviour
   {
      private Controls _controls;

      public event Action OnClickPerformed;
      public event Action OnClickCancel;
   
      public event Action OnRightClickPerformed;
      public event Action OnRightClickCancel;

      public Vector3 MousePos => _controls.UI.Point.ReadValue<Vector2>();

      public void Init()
      {
         _controls = new Controls();
         _controls.Enable();
         Subscribe();
      }

      private void Subscribe()
      {
         _controls.UI.Click.performed += OnClickPerformedHandler;
         _controls.UI.Click.canceled += OnClickCancelHandler;
         _controls.UI.RightClick.performed += OnRightClickPerformedHandler;
         _controls.UI.RightClick.canceled += OnRightClickCancelHandler;
      }

      private void Unsubscribe()
      {
         _controls.UI.Click.performed -= OnClickPerformedHandler; 
         _controls.UI.Click.canceled -= OnClickCancelHandler;
         _controls.UI.RightClick.performed -= OnRightClickPerformedHandler;
         _controls.UI.RightClick.canceled -= OnRightClickCancelHandler;
      }

      private void OnRightClickCancelHandler(InputAction.CallbackContext obj) {
         OnRightClickCancel?.Invoke();
      }

      private void OnRightClickPerformedHandler(InputAction.CallbackContext obj)
      {
         OnRightClickPerformed?.Invoke();
      }

      private void OnClickCancelHandler(InputAction.CallbackContext obj)
      {
         OnClickCancel?.Invoke();
      }

      private void OnClickPerformedHandler(InputAction.CallbackContext obj)
      {
         OnClickPerformed?.Invoke();
      }

      public void Free()
      {
         Unsubscribe();
      }
   }
}
