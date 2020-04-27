using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    public delegate void InteractMethod();
    public InteractMethod interactMethod;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact() {
        if (interactMethod != null) {
            interactMethod();
        }
        else {
            Debug.LogError("Interact delegate method for " + gameObject.name + " is not set.");
        }
    }
}
