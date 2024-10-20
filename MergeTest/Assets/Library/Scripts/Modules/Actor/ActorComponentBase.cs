using UnityEngine;

namespace Library.Scripts.Modules.Actor
{
    public class ActorComponentBase : MonoBehaviour
    {
        protected ActorBase _owner;

        public ActorBase GetOwner => _owner;
        
        public virtual void Init(ActorBase owner)
        {
            _owner = owner;
        }
        
        public virtual void Destruct()
        {
        }
        
    }
}
