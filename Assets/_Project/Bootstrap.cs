using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private EnemyDirectionController controller;
    private void Awake()
    {
        Enemy enemy = Instantiate(Resources.Load<Enemy>("Enemy"));
        controller = new EnemyDirectionController(enemy, 2f);
    }

    private void Update()
    {
        controller.Update(Time.deltaTime);
    }
}
