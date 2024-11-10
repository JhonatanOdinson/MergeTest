using Library.Scripts.Core;
using Library.Scripts.Modules.Actor;
using Library.Scripts.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Library.Scripts.Modules.SpawnManager
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private bool _showGizmo;
        [SerializeField] private Vector2 _spawnSize;
        private ElementController.ElementController _elementController;

        public void Init()
        {
            _elementController = CommonComponents.ElementController;
        }

        public ActorBase Spawn(ElementData elementData)
        {
            return _elementController.CreateElement(elementData,
                new Vector3(Random.Range(-_spawnSize.x / 2, _spawnSize.x / 2), 0,
                    Random.Range(-_spawnSize.y / 2, _spawnSize.y / 2)), Quaternion.identity);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos() {
            if (!_showGizmo) return;
            Handles.color = Color.red;
            Handles.DrawWireCube(transform.position, new Vector3(_spawnSize.x,0,_spawnSize.y));
        }
#endif
    }
}
