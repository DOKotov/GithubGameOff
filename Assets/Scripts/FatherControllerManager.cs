using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherControllerManager : MonoBehaviour
{

    public GameObject _FirstCollider;
    public GameObject _SeccondCillider;
    
    void Start()
    {
        if (SoundManager.instance.startTimeCount)
        {
            _FirstCollider.SetActive(false);
            _SeccondCillider.SetActive(true);
        }
        else
        {
            _FirstCollider.SetActive(true);
            _SeccondCillider.SetActive(false);
        }
    }
}
