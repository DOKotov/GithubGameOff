using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkTrigger : MonoBehaviour
{
    public GameObject _target;

    public bool invert;

    private BoxCollider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(invert)
            _collider2D.enabled = !_target.activeInHierarchy;
        
        _collider2D.enabled = _target.activeInHierarchy;
    }
}
