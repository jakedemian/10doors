using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour {
    private bool cursorLocked = true;

    private void Start() {
        UpdateLockState();
    }

    private void Update() {
        if (Pause.Instance.IsPaused() && cursorLocked) {
            cursorLocked = false;
        } else if (!Pause.Instance.IsPaused() && !cursorLocked) {
            cursorLocked = true;
        }

        UpdateLockState();
    }

    private void UpdateLockState() {
        if (cursorLocked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
