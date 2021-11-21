using UnityEngine;

public class DragMouseObject : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float _worldZCordinate;

    private void OnMouseDown()
    {
        _worldZCordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPosition();
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _worldZCordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mouseOffset;
    }
}