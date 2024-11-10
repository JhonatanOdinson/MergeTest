using System.Collections.Generic;
using System.Linq;
using Library.Scripts.Modules.Actor;
using Library.Scripts.ScriptableObjects;
using UnityEngine;

namespace Library.Scripts.Modules.SpawnManager
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints = new();

        public List<SpawnPoint> SpawnPoints => _spawnPoints;
        
        public void Init()
        {
            _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>().ToList();
            _spawnPoints.ForEach(e => e.Init());
        }

        public ActorBase SpawnActor(ElementData elementData)
        {
           return _spawnPoints[Random.Range(0,_spawnPoints.Count)].Spawn(elementData);
        }
        
        public void Free()
        {
            
        }
    }
}
