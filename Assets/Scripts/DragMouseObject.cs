using UnityEngine;

public class DragMouseObject : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mZCord;
    [SerializeField] private bool CanBeTouched = true;

    private void OnMouseDown()
    {
        mZCord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if(CanBeTouched == true)
        {
            transform.position = GetMouseWorldPos() + mouseOffset;
        }
    }

    #region OnActionEvents
    public void CancelTouch()
    {
        CanBeTouched = false;
    }
    #endregion
}
