using UnityEngine;

namespace Library.Scripts.Modules.Ui.Window
{
   public class WindowBase : MonoBehaviour
   {
      public virtual void Init(){}
   
      public virtual void Show() { }

      public virtual void Hide() { }

      public virtual void Destruct() {}
   }
}
