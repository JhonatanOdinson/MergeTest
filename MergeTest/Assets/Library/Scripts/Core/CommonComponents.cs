using System.Threading.Tasks;
using Library.Scripts.Modules.ElementController;
using Library.Scripts.Modules.Input;
using Library.Scripts.Modules.Ui;
using UnityEngine;

namespace Library.Scripts.Core
{
    public class CommonComponents : MonoBehaviour
    {
        #region Instance

        private static CommonComponents _instance;

        public static CommonComponents Instance {
            get {
                if (_instance == null) {
                    _instance = Instantiate(GameDirector.GetGameConfig.GetCommonComponents,Vector3.zero, Quaternion.identity)
                        .GetComponent<CommonComponents>();
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }

            set { _instance = value; }
        }

        #endregion

        [SerializeField] private UiCanvas _uiCanvas;
        [SerializeField] private InputController _inputController;
        [SerializeField] private ElementController _elementController;

        public static InputController InputController => _instance._inputController;
        public static UiCanvas UiCanvas => _instance._uiCanvas;
        public static ElementController ElementController => _instance._elementController;

        public async Task Init(EnterPoint enterPoint)
        {
            Debug.Log($"Init");
            _uiCanvas.Init(enterPoint.LoadWindowList);
        }

        public async Task LoadData() {
            await Task.WhenAll(
                _elementController.LoadData()
            );
        }
        
        public void InitGlobal()
        {
              Debug.Log($"Init Global");
            _inputController.Init();
            _elementController.Init();
        }

        public void FreeControllers()
        {
            _uiCanvas.Destruct();
           _inputController.Free();
           _elementController.Free();
        }
    }
}
