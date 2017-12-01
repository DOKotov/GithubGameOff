using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(Rigidbody2D))]
public class TriggerInvoker : MonoBehaviour
{
    public float specialDelayTime;
    
	public Collider2D interactableCollider;
	
	public UnityEvent onTriggerEnter;
	public UnityEvent OnTriggerExit;
	public UnityEvent onTriggerStay;

	public void EnableGameObject(GameObject _target)
	{
		StartCoroutine(ChangeState(true, _target));
	}

	public void DisableGameObject(GameObject _target)
	{
		StartCoroutine(ChangeState(false, _target));
	}

	IEnumerator ChangeState(bool value, GameObject _gameObject)
	{
		yield return new WaitForSeconds(specialDelayTime);
		_gameObject.SetActive(value);
	}

	private void Awake()
	{
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<BoxCollider2D>().isTrigger = true;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
			if (other == interactableCollider)
			{
				onTriggerEnter.Invoke();
			}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
			if (other == interactableCollider)
			{
				OnTriggerExit.Invoke();
			}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
			if (other == interactableCollider)
			{
				onTriggerStay.Invoke();
			}
	}

}
