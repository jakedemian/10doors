using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData {
    public bool wasGracefulExit;

    public SaveData(bool gracefulExit) {
        wasGracefulExit = gracefulExit;
    }
}