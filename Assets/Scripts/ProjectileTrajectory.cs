using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory : MonoBehaviour
{
   public SlingShot Slingshot;
   public GameObject PointPrefab;
    public GameObject PointPrefab1;
    //private string TestDestroy;
    public int PointNumber;
   public float InitialPointSize = 0.5f;
   public List<Transform> PointsList;
    public GameObject DragHandle;
    public SphereCollider sphereCollider1;
    private Vector3 _updatedPosition = new Vector3(0, 0, 0);
    bool activeSelf;

    private bool canFade;
    private Color alphaColor;
    private float timeToFade =1.0f;

    public void CreatePoints()
   {
           PointsList = new List<Transform>();
            float k=0;
            for (k = 0;k < (PointNumber / 1.75f); k++)
            {
                //k += Time.deltaTime * timeToFade;
                 var _point = Instantiate(PointPrefab, transform.position, Quaternion.identity).transform;
                _point.localScale = new Vector3
                (
                   InitialPointSize / (k + 1) + (InitialPointSize / 2),
                   InitialPointSize / (k + 1) + (InitialPointSize / 2),
                   InitialPointSize / (k + 1) + (InitialPointSize / 2)
                );
            print(Time.deltaTime+k);
             alphaColor = _point.GetComponent<MeshRenderer>().material.color;
            _point.GetComponent<MeshRenderer>().material.color = Color.Lerp(_point.GetComponent<MeshRenderer>().material.color, Color.white,  0.1f+k/timeToFade);
            _point.transform.parent = transform;
            timeToFade=timeToFade + 1.7f;
                //Debug.Log(transform.position);
                PointsList.Add(_point);
            }
        var _point1 = Instantiate(PointPrefab1, transform.position, Quaternion.identity).transform;
        _point1.localScale = new Vector3
        (
           InitialPointSize / (k + 1) + (InitialPointSize * 1.3f / 2),
           InitialPointSize / (k + 1) + (InitialPointSize * 1.3f / 2),
           InitialPointSize / (k + 1) + (InitialPointSize * 1.3f/ 2)
        );
        _point1.GetComponent<Renderer>().material.color = Color.red;
        PointsList.Add(_point1);
    }

    public void UpdatePoints()
    {
        if (sphereCollider1.isTrigger)
        {
           //TestDestroy = other.gameObject.name;
            if (Input.GetMouseButton(0) && Slingshot.GetAngle() > 0 && Slingshot.GetAngle() <= 179.9f)
            {
                for (var i = 0; i < PointsList.Count; i++)
                {
                    _updatedPosition.x = Slingshot.ReleasePointTransform.transform.position.x + i * (Slingshot.GetDistance(Slingshot.GetVelocity()) / PointNumber);
                    _updatedPosition.y = Slingshot.ReleasePointTransform.transform.position.y + Slingshot.GetHeight(Slingshot.GetVelocity(), PointNumber, i);
                    _updatedPosition.z = 0;

                    PointsList[i].transform.position = _updatedPosition;
                    PointsList[i].gameObject.SetActive(true);

                }
            }
            else
            {
                
                for (var i = 0; i < PointsList.Count; i++)
                {
                    PointsList[i].gameObject.SetActive(false);
                }

            }
            

        }
    }

   private void Start()
   {
      CreatePoints();
      canFade = false;
        
        
    }

   private void Update()
   {
     
      UpdatePoints();
   }
}