using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//original
public class DragHandle : MonoBehaviour
{
    public static int testPass1;
    public static int testPass2; //To Destroy attempt Ball
    private Vector3 _offset;
   
    private Vector3 _defaulPos;

   private Vector3 _currentPosition;

   public event OnDragHandleReleaseDelegate OnDragHandleReleaseEvent;

    public SphereCollider sphereCollider;
  
   private void Start()
   {
       sphereCollider.radius = 5.0f;
      _defaulPos = new Vector3(0,-3 ,0);
      transform.position = _defaulPos;
       
    }

    private void Update()
    {
       sphereCollider.radius = 5.0f;
    }
    private void OnMouseDown()
    {
        Debug.Log("???///////////////>>>>>>>>>>>>>><<<<<<<<<<<<<?????????");
        sphereCollider.radius = 5.0f;
            _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint
          (
             new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)
          );

            Cursor.visible = true;
       
    }

    private void OnMouseDrag()
    {
        
        testPass2 = 1;
          sphereCollider.isTrigger = true;
          //pt = gameObject.AddComponent<ProjectileTrajectory>();
          sphereCollider.radius = 5.0f;
          var currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
          //Debug.Log("off" +_offset);
          // Debug.Log("cscreepo" +currentScreenPoint);
          _currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + _offset;
          //  Debug.Log("cpos" +_currentPosition);

          transform.position = _currentPosition;
          //errorImage.enabled = false;

    }

    private void OnMouseUp()
    {
        testPass1 = 1;
        Cursor.visible = true;

            if (OnDragHandleReleaseEvent != null)
            {
                OnDragHandleReleaseEvent.Invoke();
                sphereCollider.radius = 0.5f;
            }
            Debug.Log("???????????????????????????");
            transform.position = _defaulPos;
            sphereCollider.radius = 0.5f;
        

    }
     
   
}