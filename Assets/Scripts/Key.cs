using UnityEngine;

public class Key : MonoBehaviour
{
    public Door doorToUnlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorToUnlock.doorUnlocked = true;
            Destroy(gameObject);
        }
    }
}
