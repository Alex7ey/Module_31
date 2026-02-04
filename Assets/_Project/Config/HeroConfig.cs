using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Hero", fileName = "HeroConfig")]
public class HeroConfig : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public Hero Prefab { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public Vector3 SpawnPosition { get; private set; }


    [ContextMenu("UpdateStartPosition")]
    private void UpdateStartPosition() => SpawnPosition = GameObject.FindGameObjectWithTag("StartHeroPosition").transform.position;
}
