using Library.Scripts.Core;
using Library.Scripts.Interfaces;
using Library.Scripts.Modules.Actor;
using Library.Scripts.Modules.Input;
using UnityEngine;

namespace Library.Scripts.Modules.ObjectMergeManager
{
   public class ObjectMergeManager : MonoBehaviour
   {
      [SerializeField] private Vector2 _draggableZone;
      
      private InputController _inputController;
      private ISelectable _lastSelected;
      private bool _isGrab;
      
      public void Init()
      {
         _inputController = CommonComponents.InputController;
         Subscribe();
      }
      
      private void FixedUpdate()
      {
         SelectObject(CheckClick());
         if (_isGrab && _lastSelected is not null)
            MoveObject(_lastSelected.GetSelected());
      }

      private void MoveObject(GameObject moveObject)
      {
         var mousePos =  _inputController.MousePos;
         mousePos.z = 10;
         var worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
         var objectPos = moveObject.transform.position;

         if ((worldPoint.x < _draggableZone.x / 2 && worldPoint.x > -_draggableZone.x / 2))
            moveObject.transform.position = new Vector3(worldPoint.x, objectPos.y, objectPos.z);
         
         if (worldPoint.z < _draggableZone.y / 2 && worldPoint.z > -_draggableZone.y / 2)
            moveObject.transform.position = new Vector3(objectPos.x, objectPos.y, worldPoint.z);
      }

      private void Subscribe()
      {
         _inputController.OnClickPerformed += OnClickHandler;
         _inputController.OnClickCancel += OnClickCancelHandler;
         _inputController.OnRightClickPerformed += OnRightClickHandler;
      }

      private void Unsubscribe()
      {
         _inputController.OnClickPerformed -= OnClickHandler;
         _inputController.OnClickCancel -= OnClickCancelHandler;
         _inputController.OnRightClickPerformed -= OnRightClickHandler;
      }
      
      private void OnClickCancelHandler()
      {
         GrabObject(false);
      }

      private void OnClickHandler()
      {
         //SelectObject(CheckClick());
         GrabObject(true);
      }

      private void GrabObject(bool state)
      {
         if (_lastSelected is null){
            _isGrab = false;
            return;
         }
         _isGrab = state;
      }

      private void SelectObject(object objectClick)
      {
         if (_isGrab) return;
         if (_lastSelected is not null && objectClick == null)
         {
            _lastSelected.Deselect();
            _lastSelected = null;
            return;
         }
         if (objectClick is ActorBase actorBase)
         {
            var select = actorBase.ActorComponents.FetchComponent<SelectComponent>();
            if (select is null) return;
            select.Select();
            //if(_lastSelected is not null) _lastSelected.Deselect();
            _lastSelected = select;
         }

         if (objectClick is ISelectable selectable)
         {
            selectable.Select();
          //  if(_lastSelected is not null) _lastSelected.Deselect();
            _lastSelected = selectable;
         }
           
      }

      private object CheckClick()
      {
         Ray ray = Camera.main.ScreenPointToRay(_inputController.MousePos);
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit, 100))
         {
            object selectable = hit.collider.gameObject.GetComponent<ActorBase>() == null ? 
               hit.collider.gameObject.GetComponent<ISelectable>() : 
               hit.collider.gameObject.GetComponent<ActorBase>();
            if (selectable is not null) 
               return selectable;
         }
         
         return null;
      }

      private void OnRightClickHandler()
      {
         Debug.Log($"RightClick");
      }

      public void Free()
      {
         //Unsubscribe();
      }
   }
}
