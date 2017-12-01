using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadwoNPC : MonoBehaviour
{
    [Range(0, 1)] public float fadeDuration;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector2 startPos;
    private Vector2 startScale;

    void OnEnable()
    {
        startPos = transform.position;
        startScale = transform.localScale;
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();
        StopAllCoroutines();
        StartCoroutine(ShowGhost());
    }

    public void DisableObject()
    {
        StopAllCoroutines();
        StartCoroutine(HideGhost());
    }

    IEnumerator HideGhost()
    {
        var finalAlpha = 0.0f;
        var fadeSpeed = Mathf.Abs(_spriteRenderer.color.a - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(_spriteRenderer.color.a, finalAlpha))
        {
            var alpha = Mathf.MoveTowards(_spriteRenderer.color.a, finalAlpha,
                fadeSpeed * Time.deltaTime);

            Color newColor = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b,
                alpha);
            _spriteRenderer.color = newColor;
            yield return null;
        }
        transform.position = startPos;
        transform.localScale = startScale;
        gameObject.SetActive(false);
    }

    IEnumerator ShowGhost()
    {
        var finalAlpha = 1.0f;
        var fadeSpeed = Mathf.Abs(_spriteRenderer.color.a - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(_spriteRenderer.color.a, finalAlpha))
        {
            var alpha = Mathf.MoveTowards(_spriteRenderer.color.a, finalAlpha,
                fadeSpeed * Time.deltaTime);

            Color newColor = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b,
                alpha);
            _spriteRenderer.color = newColor;
            yield return null;
        }
    }
}