using UnityEngine;
                                                                                                                                                                    //original
public class DragHandle : MonoBehaviour
{
   private Vector3 _offset;

   private Vector3 _defaulPos;

   private Vector3 _currentPosition;

   public event OnDragHandleReleaseDelegate OnDragHandleReleaseEvent;

   private void Start()
   {
      _defaulPos = new Vector3(0,-3 ,0);
      transform.position = _defaulPos;
   }

   private void OnMouseDown()
   {
      _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint
      (
         new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)
      );
       
      Cursor.visible = true;
   }

   private void OnMouseDrag()
   {
    
      var currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
       //Debug.Log("off" +_offset);
    // Debug.Log("cscreepo" +currentScreenPoint);
        _currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + _offset;
     //  Debug.Log("cpos" +_currentPosition);

        transform.position = _currentPosition;
   }

   private void OnMouseUp()
   {
      Cursor.visible = true;

      if (OnDragHandleReleaseEvent != null)
      {
         OnDragHandleReleaseEvent.Invoke();
      }

      transform.position = _defaulPos;
   }
}