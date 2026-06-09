using NUnit.Framework;
using System.Collections;
using UnityEngine;
using RangeAttribute = UnityEngine.RangeAttribute;

public class TransparentObject : MonoBehaviour
{

    [Range(0f, 1f)]
    private float transparencyValue = 0.7f;
    private float transparencyFadeTime = .4f;

    private SpriteRenderer _sprRender;

    void Awake()
    {
        _sprRender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(FadeTree(_sprRender,transparencyFadeTime,_sprRender.color.a,transparencyValue));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(FadeTree(_sprRender, transparencyFadeTime, _sprRender.color.a, 1f));
        }
    }

    private IEnumerator FadeTree(SpriteRenderer _sprite, float _fadeTime, float _startValue, float _targetTransparency)
    {
        float _timeElapsed = 0;
        while(_timeElapsed < _fadeTime)
        {
            _timeElapsed += Time.deltaTime;
            float _newAlpha =Mathf.Lerp(_startValue,_targetTransparency,_timeElapsed / _fadeTime);
            _sprite.color = new Color(_sprite.color.r,_sprite.color.g,_sprite.color.b,_newAlpha);
            yield return null;
        }
    }

}
