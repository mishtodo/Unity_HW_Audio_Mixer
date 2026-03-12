using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Vector3 _mousePosition;

    private void Update()
    {
        _mousePosition = Input.mousePosition;
    }

    public Vector3 GetMousePosition()
    {
        return _mousePosition;
    }
}
