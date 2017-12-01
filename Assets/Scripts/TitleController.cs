using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    public float _SwitchTime;

    public GameObject _Title2;

    void OnEnable()
    {
        StartCoroutine(SwitchTitle());
    }

    IEnumerator SwitchTitle()
    {
        yield return new WaitForSeconds(_SwitchTime);
        _Title2.SetActive(true);
    }

}
