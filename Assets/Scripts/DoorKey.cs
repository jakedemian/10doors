using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour {
    public GameObject door; // not prefab, but the actual door it will unlock
    public InteractableObject interactObj;

    private DoorController doorController;

    void Start() {
        doorController = door.GetComponent<DoorController>();
        interactObj.interactMethod = KeyPickup;
    }

    public void KeyPickup() {
        doorController.Unlock();
        AudioManager.Instance.Play("keyPickup");
        Destroy(gameObject);
    }
}