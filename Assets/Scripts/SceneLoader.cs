using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public string _LoadSceneName;
	public CanvasGroup _CanvasGroup;
	public float fadeDuration;

	public UnityEvent _BeforeFadeEvent;
	public UnityEvent _AfterFadeEvent;
	

	private void Awake()
	{
		StartCoroutine(AwakeEnumerator());
	}

	public void LoadScene()
	{
		StartCoroutine(FadeAndSwitch());
	}

	private IEnumerator AwakeEnumerator()
	{
		_BeforeFadeEvent.Invoke();
		yield return Fade(0);
		_AfterFadeEvent.Invoke();
	}

	private IEnumerator FadeAndSwitch()
	{
		yield return Fade(1);
		SceneManager.LoadScene(_LoadSceneName);
	}

	private IEnumerator Fade (float finalAlpha)
	{
		yield return new WaitUntil(() => _CanvasGroup != null);
		_CanvasGroup.blocksRaycasts = true;

		var fadeSpeed = Mathf.Abs (_CanvasGroup.alpha - finalAlpha) / fadeDuration;

		while (!Mathf.Approximately (_CanvasGroup.alpha, finalAlpha))
		{
			_CanvasGroup.alpha = Mathf.MoveTowards (_CanvasGroup.alpha, finalAlpha,
				fadeSpeed * Time.deltaTime);

		   yield return null;
		}

		_CanvasGroup.blocksRaycasts = false;
	}
}
