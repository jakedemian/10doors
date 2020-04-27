using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeypadController : MonoBehaviour {
    public InteractableObject intObj;
    public GameObject uiKeypad;
    public int keypadId = 0; // MUST BE UNIQUE PER KEYPAD!!
    public int characterLimit = 8;
    public GameObject connectedDoor;
    public string correctCode;
    
    private TMP_InputField uiKeypadInput;
    private DoorController connectedDoorController;

    public static KeypadController Instance;

    private void Awake() {
        Instance = this;
    }


    void Start() {
        intObj.interactMethod = UseKeypad;
        uiKeypadInput = uiKeypad.GetComponent<TMP_InputField>();
        uiKeypadInput.characterLimit = characterLimit;
        connectedDoorController = connectedDoor.GetComponent<DoorController>();
    }

    public void UseKeypad() {
        Debug.Log("use keypad");
        uiKeypadInput.text = "";
        uiKeypad.SetActive(true);
        Pause.Instance.OpenInput();
        GameController.Instance.keypadEntrySubmit = KeypadSubmit;
        FocusInput();
    }

    private void FocusInput() {
        EventSystem.current.SetSelectedGameObject(uiKeypad, null);
    }

    public void KeypadSubmit() {
        uiKeypad.SetActive(false);
        Pause.Instance.CloseInput();
        if (uiKeypadInput.text.Equals(correctCode)) {
            connectedDoorController.Unlock();
        }
        else {
            KeypadSubmitIncorrect();
        }
    }

    private void KeypadSubmitIncorrect() {
        Debug.Log("wrong keypad code!");
    }
    
}
