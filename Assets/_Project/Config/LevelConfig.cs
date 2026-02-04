using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Level", fileName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public int TotalEnemies { get; private set; }
    [field: SerializeField] public float EnemySpawnRate { get; private set; }
    [field: SerializeField] public int MaxAliveEnemies { get; private set; }
    [field: SerializeField] public int KillQuota { get; private set; }
    [field: SerializeField] public float TimeToSurvive { get; private set; }
    [field: SerializeField] public TypeGameRules WinCondition { get; private set; }
    [field: SerializeField] public TypeGameRules LoseCondition { get; private set; }
}
