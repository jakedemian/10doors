using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    //public SaveManager saveManager;
    public SaveData saveData;
    public static GameController Instance;
    public GameObject gracefulExitDoor;
    public GameObject inputField;

    void Awake() {
        Instance = this;
        saveData = SaveManager.Load();
        Debug.Log(saveData.wasGracefulExit);
        SaveManager.PostLoadSetGracefulExitFalse();
    }

    public delegate void KeypadEntrySubmit();

    public KeypadEntrySubmit keypadEntrySubmit;

    private void Start() {
        if (!saveData.wasGracefulExit) {
            gracefulExitDoor.GetComponent<DoorController>().Unlock();
        }
    }

    public void DoKeypadSubmit() {
        keypadEntrySubmit();
    }

    public void DoSave() {
        // gather data

        // write data to Save.txt
        SaveManager.Save(true);
    }
}