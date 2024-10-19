using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Library.Scripts.Core {
  public class EnterPoint : MonoBehaviour {
    private static bool _isInitGC = false;
    private bool _initProcess = false;
    private bool _destructProcess;
    //[SerializeField] private List<WindowData> _loadWindowList = new List<WindowData>();
    [SerializeField] private SceneComponents _sceneComponents;
    public Action OnEnterPointInited;

    public SceneComponents SceneComponentsRef => _sceneComponents;
    // public IEnumerable<WindowData> LoadWindowList => _loadWindowList;
   public bool DestructProcess => _destructProcess;

    async void Start() {
      if(_isInitGC) return;
      await Init();
    }

    private void Update() {
      if (!_isInitGC) return;
      //GameDirector.GetGameConfig.InputController.Update();
    }

    public async Task Init() {
      if(_initProcess) return;
      _initProcess = true;
      GameDirector.SetEnterPoint(this);
      if (!_isInitGC)
        await InitGlobalControllers();
      await CommonComponents.Instance.Init(this);
      _sceneComponents.Init();
     OnEnterPointInited?.Invoke();
      //SceneLoader.Instance.OnLoadStart += Destruct;
    }

    private async Task InitGlobalControllers() {
      //CommonComponents.LoadInstance();
      //await CommonComponents.Instance.LoadData();
      CommonComponents.Instance.InitGlobal();
      //GameDirector.GetGameConfig.InputController.Init();
      _isInitGC = true;
    }
    
    //when game unfocus - show uiExitMenuWindow
    public void OnApplicationFocus(bool hasFocus) {
      /*if (!hasFocus && GameDirector.GetGameConfig.OptionsSettings.RunInBackground && !Application.isEditor &&
          !CommonComponents.WindowsController.GetActiveInteractableWindows().Any()) { 
        UiExitMenuWindow uiExitMenu = CommonComponents.WindowsController.GetWindow<UiExitMenuWindow>();
        if (uiExitMenu != null) {
          UiExitMenuProvider uiExitMenuProvider = (UiExitMenuProvider) uiExitMenu.GetProvider();
          uiExitMenuProvider.ShowWindow(null);
        }
      }*/
    }

    public void OnApplicationQuit() {
      if(!Application.isEditor) return;
      Destruct(); //call unsubscribe
    }

    private void Destruct() {
      if(_destructProcess) return;
      _destructProcess = true;
      //PlayMakerFSM.BroadcastEvent(GlobalEvents.EnterPointDestructEvent);
      StopAllCoroutines();
      //CommonComponents.Instance.FreeControllers();
      SceneComponentsRef.Destruct();
    }
  }
}
