using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

namespace Library.Scripts.Modules.Actor
{
    public class ActorComponents : MonoBehaviour
    {
        [SerializeField] private List<ActorComponentBase> _actorComponents = new ();
        private ActorBase _actorBase;
        public void Init(ActorBase actorBase)
        {
            FindComponents();
            _actorBase = actorBase;
            _actorComponents.ForEach(e => e.Init(actorBase));
        }

        private void FindComponents()
        {
            _actorComponents =  GetComponentsInChildren<ActorComponentBase>().ToList();
        }

        public T FetchComponent<T>() where T: ActorComponentBase
        {
            ActorComponentBase componentBase = _actorComponents.Find(e => e.GetType() == typeof(T));
            return (T)Convert.ChangeType(componentBase, typeof(T));
        }

        public void Destruct()
        {
            _actorComponents.ForEach(e=>e.Destruct());
        }
    }
}
