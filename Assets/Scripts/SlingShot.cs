using UnityEngine;
                                                                                                                                                //Original
public class SlingShot : MonoBehaviour
{
    public LineRenderer HandlesLineRenderer1;  /**< Left catapult LineRenderer  */
    public LineRenderer HandlesLineRenderer2;  /**< Right catapult LineRenderer  */
    public Transform HandleAnchorTrnsform1;
    public Transform HandleAnchorTrnsform2;
    public DragHandle DragHandle;
    public Transform ReleasePointTransform;     /**< to update release point transform position  */
    public Transform ProjectileSpawnTransform;  /**< to update transform position that projectile starts to spawn  */
    public Transform AimerTransform;            /**< to update release point transform position  */
    public GameObject ProjectilePrefab;
    public float StartPower = 0;
    private float LineLength1;
    private float LineLength2;

    /**
     * To get the velocity of the ball that dragged
     */
    public float GetVelocity()
    {
        return Vector3.Distance(DragHandle.transform.position, ReleasePointTransform.transform.position) * 2.5f *4;
    }

    /**
     * To get the distance of the ball that dragged from target
     */

    public float GetDistance(float Vinit)
    {
        var g = Physics.gravity.y;
        var Vvert = Vinit * (Mathf.Sin(GetAngle() * Mathf.Deg2Rad));
        var Vhor = Vinit * (Mathf.Cos(GetAngle() * Mathf.Deg2Rad));
        var Tvert = (0 - Vvert) / g;
        var Thor = 2 * Tvert;
        var distance = Vhor * Thor;
        return distance;
    }

    /**
     * To get the height of the target from the position of ball to calculate the projectile height
     */

    public float GetHeight(float Vinit, int amountPoints, int pointIndex)
    {
        var g = Physics.gravity.y;
        var Vvert = Vinit * (Mathf.Sin(GetAngle() * Mathf.Deg2Rad));
        var Vhor = Vinit * (Mathf.Cos(GetAngle() * Mathf.Deg2Rad));
        var Tvert = (0 - Vvert) / g;
        var Thor = 2 * Tvert;
        var Dtot = Vhor * Thor;
        var Dp = (Dtot / (amountPoints)) * pointIndex;
        var T2 = Dp / Vhor;
        var height = ((Vvert * Dp) / Vhor) + 0.5f * g * Mathf.Pow(T2, 2);
        return height;
    }

    /**
     * It instantiates the projectile prefab in order to make shot to target
     */
     
    public void MakeShot()
    {
        var _projectile = Instantiate(ProjectilePrefab, ProjectileSpawnTransform.position, Quaternion.identity) as GameObject;
        _projectile.GetComponent<Rigidbody>().AddForce(GetShotDirection() * StartPower * 2.5f*4.2f, ForceMode.Impulse);

        Destroy(_projectile, 4.0f);
    }

    /**
     * To get the angle of the target from the position of ball to calculate the projectile angle
     */

    public float GetAngle()
    {
        var angle = Vector3.Angle((ReleasePointTransform.transform.position - DragHandle.transform.position).normalized, Vector3.right);

        if (DragHandle.transform.position.y> AimerTransform.position.y)
        {
            angle = angle * -1;
        }

        return angle ;
    }

    private void Start()
    {
        
        AimerTransform.position = new Vector3(0,1,0);

        HandlesLineRenderer1.SetPosition(0, HandlesLineRenderer1.transform.position);
        HandlesLineRenderer2.SetPosition(0, HandlesLineRenderer2.transform.position);
        HandlesLineRenderer1.SetPosition(1, DragHandle.transform.position);
        HandlesLineRenderer2.SetPosition(1, DragHandle.transform.position);
        HandlesLineRenderer1.startWidth = 0.02f;
        HandlesLineRenderer2.startWidth = 0.02f;
        HandlesLineRenderer1.endWidth = 0.008f;
        HandlesLineRenderer2.endWidth = 0.008f;
    }

    /**
     * This enables the drag handle release event
     */

    private void OnEnable()
    {
        DragHandle.OnDragHandleReleaseEvent += DragHandle_OnDragHandleReleaseEvent;
    }

    /**
     * This disables the drag handle release event
     */

    private void OnDisable()
    {
        DragHandle.OnDragHandleReleaseEvent -= DragHandle_OnDragHandleReleaseEvent;
    }

    /**
     * This destroys the drag handle release event
     */

    private void OnDestroy()
    {
        DragHandle.OnDragHandleReleaseEvent -= DragHandle_OnDragHandleReleaseEvent;
    }

    private void DragHandle_OnDragHandleReleaseEvent()
    {
        MakeShot();
    }

    private void Update()
    {
        UpdateLines();
        UpdateAim();
        GetHeight(GetVelocity(), 3, 1);
        StartPower = Vector3.Distance(DragHandle.transform.position, ReleasePointTransform.transform.position);
    }

    /**
     * This is to update the lines from the catapult to dragged position
     */

    private void UpdateLines()
    {
        
            HandlesLineRenderer1.SetPosition(1, DragHandle.transform.position);
            HandlesLineRenderer2.SetPosition(1, DragHandle.transform.position);
            HandlesLineRenderer1.SetPosition(0, HandlesLineRenderer1.transform.position);
            HandlesLineRenderer2.SetPosition(0, HandlesLineRenderer2.transform.position);

            HandlesLineRenderer1.GetComponent<LineRenderer>().startWidth = 0.15f / LineLength1;
            HandlesLineRenderer2.GetComponent<LineRenderer>().startWidth = 0.15f / LineLength2;
            HandlesLineRenderer1.GetComponent<LineRenderer>().endWidth = 0.05f / LineLength1;
            HandlesLineRenderer2.GetComponent<LineRenderer>().endWidth = 0.05f / LineLength2;

            LineLength1 = Vector3.Distance(DragHandle.transform.position, HandleAnchorTrnsform1.position);
            LineLength2 = Vector3.Distance(DragHandle.transform.position, HandleAnchorTrnsform2.position);

            if (LineLength1 <= 0.65f)
            {
                LineLength1 = 0.65f;
            }
            if (LineLength2 <= 0.65f)
            {
                LineLength2 = 0.65f;
            }
        
    }

    /**
     * This is to update the aimer position from the catapult to target position
     */

    private void UpdateAim()
    {
        var pullDirection = ReleasePointTransform.position - (DragHandle.transform.position - ReleasePointTransform.position).normalized;
        AimerTransform.position = pullDirection;
    }

    /**
     * This is to get the shot direction from the ball position to target position
     */

    private Vector3 GetShotDirection()
    {
        return (AimerTransform.position - ReleasePointTransform.transform.position).normalized;
    }
}