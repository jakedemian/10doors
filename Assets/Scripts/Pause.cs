using UnityEngine;

public class Pause : MonoBehaviour {
    public static Pause Instance;
    public GameObject pauseMenu;

    public enum PauseState {
        NONE,
        PAUSED,
        INPUT
    };

    [HideInInspector] public PauseState pauseState = PauseState.NONE;

    private void Awake() {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Keypad0)) {
            if (pauseState == PauseState.NONE) {
                pauseState = PauseState.PAUSED;
            }
            else {
                pauseState = PauseState.NONE;
            }
        }
        
        if (pauseState == PauseState.PAUSED && !pauseMenu.activeInHierarchy) {
            Debug.Log("pausing");
            pauseMenu.SetActive(true);
        }
        else if(pauseState == PauseState.NONE && pauseMenu.activeInHierarchy) {
            Debug.Log("unpausing");
            pauseMenu.SetActive(false);
        }
    }

    public bool IsPaused() {
        return pauseState != PauseState.NONE;
    }

    public void OpenInput() {
        pauseState = PauseState.INPUT;
    }

    public void CloseInput() {
        pauseState = PauseState.NONE;
    }

    public void Resume() {
        pauseState = PauseState.NONE;
    }

    public void Save() {
        Debug.Log("Saving...");
        GameController.Instance.DoSave();
    }

    public void SaveAndQuit() {
        Save();
        
        Debug.Log("... and quitting...");
#if UNITY_EDITOR
        Debug.Log("unity editor quit");
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Debug.Log("Application.Quit");
         Application.Quit();
#endif
    }
}
