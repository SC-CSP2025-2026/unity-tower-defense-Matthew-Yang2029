using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 1f;

    public float BaseSpeed { get; private set; }

    void Awake()
    {
        BaseSpeed = Speed;
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    public void ResetSpeed()
    {
        Speed = BaseSpeed;
    }

    [field: SerializeField]
    public Waypoint Target { get; set; }
   
    void Start()
    {
        if (Target == null) { return; }
        transform.position = Target.transform.position;
    }

    void Update()
    {
        if (Target == null) { return; }
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Speed);
        transform.LookAt(Target.transform.position);
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance <= 0.1f)
        {
            Target = Target.Next;
        }
    }
}
