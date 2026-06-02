using UnityEngine;
using UnityEngine.Events;

public class TowerController : MonoBehaviour
{
    [field: SerializeField]
    public float BaseHealth { get; private set; } = 5;
    [field: SerializeField]
    public float Damage { get; private set; } = 0;
    [field: SerializeField]
    public UnityEvent<TowerController> OnDestroyed { get; private set; }

    public void ApplyHit(EnemyAttack attack)
    {
        Damage += attack.Damage;
        Object.Destroy(attack.gameObject);
        if (Damage >= BaseHealth)
        {
            OnDestroyed.Invoke(this);
            Object.Destroy(gameObject);
        }
    }
}
