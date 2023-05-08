using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth == null) return;
        otherHealth.Die();

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}