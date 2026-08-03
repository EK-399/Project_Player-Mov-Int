using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Vector3 startPosition;
    public Transform recentCheckpoint;
    void Start()
    {
        startPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Die();
        }

        if (collision.CompareTag("Checkpoint"))
        {
            recentCheckpoint = collision.gameObject.transform;
            collision.gameObject.GetComponent<Animator>().Play("Hit");
        }
    }

    public void Die()
    {
        if (recentCheckpoint == null)
        {
            transform.position = startPosition; //
        }
        else
        {
            transform.position = recentCheckpoint.position;
        }

  
    }
}
