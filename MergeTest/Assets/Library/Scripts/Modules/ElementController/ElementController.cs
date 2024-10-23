using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Library.Scripts.Modules.ElementController
{
    public class ElementController : MonoBehaviour
    {
        [SerializeField] private List<ElementData> _elementDatas = new();
        [SerializeField] private List<CombinationData> _combinationDatas = new();

        public void Init()
        {
            
        }

        public async Task LoadData() {
            await Addressables
                .LoadAssetsAsync<ElementData>("ElementData", callback: elementData => { _elementDatas.Add(elementData); })
                .Task;
            await Addressables
                .LoadAssetsAsync<CombinationData>("CombinationData", callback: combinationData => { _combinationDatas.Add(combinationData); })
                .Task;
        }

        public void Free()
        {
            
        }
    }
}
