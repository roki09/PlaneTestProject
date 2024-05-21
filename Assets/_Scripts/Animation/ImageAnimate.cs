using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImageAnimate : MonoBehaviour
{
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEvent _onComplite;

    private SpriteRenderer _renderer;
    private float _secondsPerFrame;
    private int _currentSpriteIndex;
    private float _nextFrameTime;

    private bool _isPlaying = true;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _secondsPerFrame = 1f / _frameRate;
        _nextFrameTime = Time.time + _secondsPerFrame;
    }

    private void Update()
    {
        if ((!_isPlaying || _nextFrameTime > Time.time)) return;

        if (_currentSpriteIndex >= _sprites.Length)
        {
            if (_loop)
                _currentSpriteIndex = 0;
            else
            {
                _isPlaying = false;
                _onComplite?.Invoke();
                return;
            }
        }

        _renderer.sprite = _sprites[_currentSpriteIndex];
        _nextFrameTime += _secondsPerFrame;
        _currentSpriteIndex++;
    }
}
