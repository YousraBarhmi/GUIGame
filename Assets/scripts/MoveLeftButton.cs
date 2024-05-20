using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    private bool isPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    void Update()
    {
        if (isPressed)
        {
            player.transform.Translate(Vector3.left * player.GetComponent<PlayerController>().moveSpeed * Time.deltaTime);
        }
    }
}
