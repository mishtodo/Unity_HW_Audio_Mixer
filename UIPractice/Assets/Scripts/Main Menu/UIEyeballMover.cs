using UnityEngine;

public class UIEyeballMover : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Vector2 _anchorMin;
    [SerializeField] private Vector2 _anchorMax;
    [SerializeField] private float smoothSpeed = 0.005f;

    private float _mouseXPercentage;
    private float _mouseYPercentage;
    private float _clampedX;
    private float _clampedY;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _mouseXPercentage = _inputHandler.GetMousePosition().x / Screen.width;
        _mouseYPercentage = _inputHandler.GetMousePosition().y / Screen.height;

        _clampedX = Mathf.Clamp(_mouseXPercentage, _anchorMin.x, _anchorMax.x);
        _clampedY = Mathf.Clamp(_mouseYPercentage, _anchorMin.y, _anchorMax.y);

        Vector2 targetAnchor = new Vector2(_clampedX, _clampedY);

        _rectTransform.anchorMin = Vector2.Lerp(_rectTransform.anchorMin, targetAnchor, smoothSpeed);
        _rectTransform.anchorMax = Vector2.Lerp(_rectTransform.anchorMax, targetAnchor, smoothSpeed);

        _rectTransform.anchoredPosition = Vector2.zero;
    }
}
