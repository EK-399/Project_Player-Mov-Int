using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorUnlocked;
    bool playerInRange;
    PlayerMovement player;
    public GameObject E_0;
    //Door changes cenes
    //Door 
    //
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                if (doorUnlocked)
                {
                    gameObject.SetActive(false); //turn off the door
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerMovement>();
            playerInRange = true;
            E_0.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collison)
    {
        if(collison.CompareTag("Player"))
        {
            playerInRange = false;
            E_0.SetActive(false);
        }
    }
}
