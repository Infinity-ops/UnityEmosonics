using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public LineRenderer HandlesLineRenderer1;
    public LineRenderer HandlesLineRenderer2;
    public Transform HandleAnchorTrnsform1;
    public Transform HandleAnchorTrnsform2;
    public DragHandle DragHandle;
    public Transform ReleasePointTransform;
    public Transform ProjectileSpawnTransform;
    public Transform AimerTransform;
    public GameObject ProjectilePrefab;
    public float StartPower = 0;
    private float LineLength1;
    private float LineLength2;

    public float GetVelocity()
    {
        return Vector3.Distance(DragHandle.transform.position, ReleasePointTransform.transform.position) * 2.5f;
    }

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

    public void MakeShot()
    {
        var _projectile = Instantiate(ProjectilePrefab, ProjectileSpawnTransform.position, Quaternion.identity) as GameObject;
        _projectile.GetComponent<Rigidbody>().AddForce(GetShotDirection() * StartPower * 2.5f, ForceMode.Impulse);

        Destroy(_projectile, 4.0f);
    }

    public float GetAngle()
    {
        var angle = Vector3.Angle((ReleasePointTransform.transform.position - DragHandle.transform.position).normalized, Vector3.right);

        if (DragHandle.transform.position.y > AimerTransform.position.y)
        {
            angle = angle * -1;
        }

        return angle;
    }

    private void Start()
    {
        
        AimerTransform.position = new Vector3(0, 0.211f, 0.442f);

        HandlesLineRenderer1.SetPosition(0, HandlesLineRenderer1.transform.position);
        HandlesLineRenderer2.SetPosition(0, HandlesLineRenderer2.transform.position);
        HandlesLineRenderer1.SetPosition(1, DragHandle.transform.position);
        HandlesLineRenderer2.SetPosition(1, DragHandle.transform.position);
        HandlesLineRenderer1.startWidth = 0.02f;
        HandlesLineRenderer2.startWidth = 0.02f;
        HandlesLineRenderer1.endWidth = 0.008f;
        HandlesLineRenderer2.endWidth = 0.008f;
    }

    private void OnEnable()
    {
        DragHandle.OnDragHandleReleaseEvent += DragHandle_OnDragHandleReleaseEvent;
    }

    private void OnDisable()
    {
        DragHandle.OnDragHandleReleaseEvent -= DragHandle_OnDragHandleReleaseEvent;
    }

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

    private void UpdateAim()
    {
        var pullDirection = ReleasePointTransform.position - (DragHandle.transform.position - ReleasePointTransform.position).normalized;
        AimerTransform.position = pullDirection;
    }

    private Vector3 GetShotDirection()
    {
        return (AimerTransform.position - ReleasePointTransform.transform.position).normalized;
    }
}