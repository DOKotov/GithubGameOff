using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour 
{
	public GameObject soundManager;			//SoundManager prefab to instantiate.

	void Awake (){
		if (SoundManager.instance == null)
			Instantiate(soundManager);
	}
}