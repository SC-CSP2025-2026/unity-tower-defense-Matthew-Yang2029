using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [field: SerializeField]
    public float RotationSpeed { get; private set; } = 90f;

    void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }
}
