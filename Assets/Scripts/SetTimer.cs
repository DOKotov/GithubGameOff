using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimer : MonoBehaviour {

    private void Awake()
    {
        SoundManager.instance.startTimeCount = true;
    }
}
