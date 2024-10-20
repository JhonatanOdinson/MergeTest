using System;
using UnityEngine;

namespace Library.Scripts.Modules.Actor
{
    public class ActorBase : MonoBehaviour
    {
        [SerializeField] private ActorComponents _actorComponents;

        public ActorComponents ActorComponents => _actorComponents;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _actorComponents.Init(this);
        }
    }
}
