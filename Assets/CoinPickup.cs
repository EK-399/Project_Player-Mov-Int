using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value; //How much am I worth?

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //Need to go into our game, amd tag our player
        {
            //Add our vaule to the player
            collision.GetComponent<PlayerMovement>().playerMoney += value;

            //Dlete the coin.
            Destroy(gameObject);
        }
    }
}
