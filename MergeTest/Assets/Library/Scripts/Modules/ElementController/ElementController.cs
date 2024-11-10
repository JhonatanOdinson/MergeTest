using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Scripts.Core;
using Library.Scripts.Modules.Actor;
using Library.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Library.Scripts.Modules.ElementController
{
    public class ElementController : MonoBehaviour
    {
        [SerializeField] private List<ActorBase> _actorDataList = new();
        [SerializeField] private List<ElementData> _elementDatas = new();
        [SerializeField] private List<CombinationData> _combinationDatas = new();
        [SerializeField] private GameObject _elementRef;

        public event Action<ActorBase> OnCreateActor;
        public event Action<ActorBase> OnDestroyActor;

        public List<ElementData> ElementDatas => _elementDatas;
        public List<CombinationData> CombinationDatas => _combinationDatas;
        public List<ActorBase> GetActors => _actorDataList;
        
        public void Init()
        {
            
        }

        public CombinationData CheckCombination(List<ElementDataEx> elementDataExes)
        {
            foreach (var combination in _combinationDatas)
            {
                if (combination.CheckFormula(elementDataExes))
                    return combination;
            }
            return null;
        }

        public async Task LoadData() {
            await Addressables
                .LoadAssetsAsync<ElementData>("ElementData", callback: elementData => { _elementDatas.Add(elementData); })
                .Task;
            await Addressables
                .LoadAssetsAsync<CombinationData>("CombinationData", callback: combinationData => { _combinationDatas.Add(combinationData); })
                .Task;
        }

        public ActorBase CreateElement(ElementData data, Vector3 spawnPos, Quaternion rotation)
        {
            var element = Instantiate(_elementRef,GameDirector.GetEnterPoint.ActorContainer);
            element.transform.SetPositionAndRotation(spawnPos,rotation);
            var actorBase = element.GetComponent<ActorBase>();
            actorBase.Init();
            actorBase.SetBaseData(new ElementDataEx(data));
            _actorDataList.Add(actorBase);
            OnCreateActor?.Invoke(actorBase);
            return actorBase;
        }

        public void DestroyActor(ActorBase actorBase)
        {
            OnDestroyActor?.Invoke(actorBase);
            _actorDataList.Remove(actorBase);
            actorBase.Destruct();
        }

        public void Free()
        {
            
        }
    }
}
