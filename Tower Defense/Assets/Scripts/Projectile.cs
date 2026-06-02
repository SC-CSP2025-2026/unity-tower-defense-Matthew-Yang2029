using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 2;
    [field: SerializeField]
    public float Damage { get; private set; } = 1;
    [field: SerializeField]
    public Transform Target { get; set; }

    void Update()
    {
        if (Target == null)
        {
            Object.Destroy(gameObject);
            return;
        }

        Vector3 direction = Target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        float distance = (Target.position - transform.position).magnitude;

        if (distance <= Mathf.Epsilon)
        {
            Health healthComponent = Target.GetComponentInParent<Health>();
            if (healthComponent != null)
            {
                healthComponent.ApplyHit(this);
            }
            Object.Destroy(gameObject);
            return;
        }
    }
}
