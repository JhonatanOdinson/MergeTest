using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Library.Scripts.Modules.SpawnManager
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints = new();

        public List<SpawnPoint> SpawnPoints => _spawnPoints;
        
        public void Init()
        {
            _spawnPoints = gameObject.GetComponents<SpawnPoint>().ToList();
            _spawnPoints.ForEach(e => e.Init());
        }

        public void Free()
        {
            
        }
    }
}
