using UnityEngine;

namespace Library.Scripts.ScriptableObjects.GameConfig
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableData/Core/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private GameObject _commonComponentsPrefab;

        public GameObject GetCommonComponents => _commonComponentsPrefab;
    }
}
