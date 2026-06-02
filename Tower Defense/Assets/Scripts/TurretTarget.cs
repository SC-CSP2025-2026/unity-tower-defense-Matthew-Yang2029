using UnityEngine;

public class TurretTarget : MonoBehaviour
{
    [field: SerializeField]
    public AreaOfEngagement AoE { get; private set; }
    [field: SerializeField]
    public GameObject Model { get; private set; }

    void Update()
    {
        if (AoE.Targets.Count > 0 && AoE.Targets[0] != null)
        {
            Model.transform.LookAt(AoE.Targets[0].transform);
        }
    }
}
