using System.Collections.Generic;
using UnityEngine;

public class SlowBuilding : MonoBehaviour
{
    [field: SerializeField]
    public AreaOfEngagement AoE { get; private set; }
    [field: SerializeField]
    public float SlowMultiplier { get; private set; } = 0.5f;

    private List<EnemyMovement> _slowedEnemies = new();

    void Update()
    {
        if (AoE == null) { return; }
        List<EnemyMovement> currentEnemies = new();
        foreach (Health target in AoE.Targets)
        {
            if (target == null) { continue; }
            EnemyMovement enemy = target.GetComponent<EnemyMovement>();
            if (enemy == null) { continue; }
            currentEnemies.Add(enemy);
            enemy.SetSpeed(enemy.BaseSpeed * SlowMultiplier);
        }

        foreach (EnemyMovement enemy in _slowedEnemies)
        {
            if (!currentEnemies.Contains(enemy))
            {
                enemy.ResetSpeed();
            }
        }

        _slowedEnemies = currentEnemies;
    }
}
