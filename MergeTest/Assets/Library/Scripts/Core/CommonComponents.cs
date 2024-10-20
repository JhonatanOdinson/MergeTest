using System.Threading.Tasks;
using Library.Scripts.Modules.Input;
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

        [SerializeField] private InputController _inputController;

        public static InputController InputController => _instance._inputController;

        public async Task Init(EnterPoint enterPoint) {
            
        }

        public void InitGlobal()
        {
            _inputController.Init();
        }

        public void FreeControllers()
        {
           _inputController.Free();
        }
    }
}
