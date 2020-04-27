using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    public InteractableObject interactObj;
    
    public bool locked = true;
    public bool open = false;

    private HingeJoint hinge;

    void Start() {
        hinge = GetComponent<HingeJoint>();
        interactObj.interactMethod = TryOpen;
    }
    
    public void TryOpen() {
        Debug.Log("trying to open door!");
        if (locked) {
            OpenFailed();
        }
        else {
            OpenSuccess();
        }
    }

    private void OpenFailed() {
        Debug.Log("LOCKED!!");
        AudioManager.Instance.Play("doorLocked");
    }

    private void OpenSuccess() {
        open = true;
        hinge.useMotor = true;
        AudioManager.Instance.Play("doorOpen");
        
        // shouldnt be interactable anymore
        gameObject.GetComponent<InteractableObject>().enabled = false; 
    }

    public void Unlock() {
        Debug.Log("Door unlocked!");
        AudioManager.Instance.Play("doorUnlock");
        locked = false;
    }
}