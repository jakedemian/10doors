using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {
    public Camera cam;
    public float interactDistance;
    public GameObject uiInteractIcon;
    public GameObject uiInteractText;
    
    private bool canInteract = false;
    private GameObject interactableObject = null;

    void Start() {
    }

    void Update() {
        if (Pause.Instance.IsPaused()) return;
        
        CheckForInteractions();
        ShowInteractUI(canInteract);

        if (canInteract && Input.GetButtonDown("Interact")) {
            DoInteract();
        }
    }

    private void ShowInteractUI(bool show) {
        
        if (show) {
            Color a = new Color(1, 1, 1, 0.5f);
            Color b = new Color(1,1,1, 1);
            uiInteractIcon.GetComponent<Image>().color = a;
            uiInteractText.GetComponent<TextMeshProUGUI>().color = b;
        }
        else {
            Color a = new Color(1, 1, 1, 0);
            Color b = new Color(1,1,1, 0);
            uiInteractIcon.GetComponent<Image>().color = a;
            uiInteractText.GetComponent<TextMeshProUGUI>().color = b;
        }
    }

    void CheckForInteractions() {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance)) {
            GameObject go = hit.collider.gameObject;
            // TODO maybe replace with a tag check?
            InteractableObject intObjScript = go.GetComponent<InteractableObject>();
            if (intObjScript != null && intObjScript.enabled) {
                interactableObject = go;
                canInteract = true;
            }
            else {
                canInteract = false;
            }
        }
        else {
            canInteract = false;
        }
    }

    public bool CanInteract() {
        return canInteract;
    }

    void DoInteract() {
        interactableObject.GetComponent<InteractableObject>().Interact();
    }
}