using Library.Scripts.Core;
using Library.Scripts.Interfaces;
using Library.Scripts.Modules.Actor;
using Library.Scripts.Modules.ActorComponents.MergeChecker;
using Library.Scripts.Modules.Input;
using UnityEngine;

namespace Library.Scripts.Modules.ObjectMergeManager
{
   public class ObjectMergeManager : MonoBehaviour
   {
      [SerializeField] private Vector2 _draggableZone;
      
      private InputController _inputController;
      private ISelectable _lastSelected;
      private bool _isGrab = false;
      private bool _initialized;
      
      public void Init()
      {
         _inputController = CommonComponents.InputController;
         Subscribe();
         _initialized = true;
         CommonComponents.ElementController.OnDestroyActor += DestroyElement;
      }

      private void DestroyElement(ActorBase actorBase)
      {
         if (_lastSelected.GetSelected() == actorBase.gameObject)
         {
            _lastSelected = null;
            SelectObject(null);
         }
      }

      private void FixedUpdate()
      {
         if (!_initialized) return;
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

         //Debug.Log($"x: {worldPoint.x} < {_draggableZone.x / 2} && > {-(_draggableZone.x / 2)}");
         //Debug.Log($"y: {worldPoint.z} < {_draggableZone.y / 2} && > {-(_draggableZone.y / 2)}");

         bool xMove = (worldPoint.x < _draggableZone.x / 2 && worldPoint.x > -(_draggableZone.x / 2));
         bool yMove = (worldPoint.z < _draggableZone.y / 2 && worldPoint.z > -(_draggableZone.y / 2));
         
         if (xMove)
            moveObject.transform.position = new Vector3(worldPoint.x, objectPos.y, objectPos.z);
         
         if (yMove)
            moveObject.transform.position = new Vector3(objectPos.x, objectPos.y, worldPoint.z);
         
         if(xMove && yMove)
            moveObject.transform.position = new Vector3(worldPoint.x, objectPos.y, worldPoint.z);
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
            var actorGO = _lastSelected.GetSelected();
            if (actorGO)
            {
               var actor = actorGO.GetComponent<ActorBase>();
               if (actor)
               {
                  var mergeChecker = actor.ActorComponents.FetchComponent<MergeChecker>();
                  if(mergeChecker)
                     mergeChecker.StartChecked(false);
               }
                  
            }
               
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
            var mergeChecker = actorBase.ActorComponents.FetchComponent<MergeChecker>();
            if(mergeChecker)
               mergeChecker.StartChecked(true);
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
            object selectable = hit.collider.gameObject.GetComponent<ActorComponentBase>() == null ? 
               hit.collider.gameObject.GetComponent<ISelectable>() : 
               hit.collider.gameObject.GetComponent<ActorComponentBase>();
            if (selectable is ActorComponentBase actorComponent)
               selectable = actorComponent.GetOwner;
            if (selectable is not null) 
               return selectable;
         }
         
         return null;
      }

      private void OnRightClickHandler()
      {
         var obj = CheckClick();
         if (obj is null) return;
         if (obj is ActorBase actorBase)
         {
            CommonComponents.ElementController.DestroyActor(actorBase);
         }
            
            
      }

      public void Free()
      {
         _initialized = false;
         //Unsubscribe();
      }
   }
}
