using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeCount : MonoBehaviour
{
	public UnityEvent winEvent;
	
	public float timeToWin;
	
	void Start ()
	{
		if (SoundManager.instance.startTimeCount)
			StartCoroutine(EndGame());
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(timeToWin);
		winEvent.Invoke();
	}
}
