using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineActivator : MonoBehaviour
{

	public PlayableDirector _Director;
	public KeyCode _Key;

	private bool playOnce = true;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(_Key) && playOnce)
		{
			_Director.Play();
			playOnce = false;
		}
	}
}
