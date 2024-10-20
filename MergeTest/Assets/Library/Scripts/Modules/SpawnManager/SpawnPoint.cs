using UnityEditor;
using UnityEngine;

namespace Library.Scripts.Modules.SpawnManager
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private bool _showGizmo;
        [SerializeField] private Vector2 _spawnSize;

        public void Init()
        {
            
        }

        public void Spawn()
        {
            
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
