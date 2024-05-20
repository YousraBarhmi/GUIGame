using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject with PlayerController attached

    public void MovePlayerLeft()
    {
        // Move the player to the left
         Debug.Log("Left button clicked");
        // player.transform.Translate(Vector3.left * player.GetComponent<PlayerController>().moveSpeed * Time.deltaTime);
        player.transform.Translate(Vector3.left * player.GetComponent<PlayerController>().moveSpeed * Time.deltaTime);
    }

    public void MovePlayerRight()
    {
        // Move the player to the right
        player.transform.Translate(Vector3.right * player.GetComponent<PlayerController>().moveSpeed * Time.deltaTime);
    }
}
