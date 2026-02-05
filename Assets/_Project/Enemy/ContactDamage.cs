using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Hero character))
        {
            character.TakeDamage(_damage);
        }
    }
}
