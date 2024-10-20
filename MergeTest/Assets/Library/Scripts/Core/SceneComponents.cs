using Library.Scripts.Modules.ObjectMergeManager;
using Library.Scripts.Modules.SpawnManager;
using UnityEngine;

namespace Library.Scripts.Core
{
    public class SceneComponents : MonoBehaviour
    {
        [SerializeField] private ObjectMergeManager _objectMergeManager;
        [SerializeField] private SpawnManager _spawnManager;

        public ObjectMergeManager ObjectMergeManager => _objectMergeManager;
        public SpawnManager SpawnManager => _spawnManager;
        
        public void Init()
        {
            _objectMergeManager?.Init();
            _spawnManager?.Init();
        }

        public void Destruct()
        {
            _objectMergeManager?.Free();
            _spawnManager?.Free();
        }
    }
}
