using UnityEngine;

public class SquareHMovement : MonoBehaviour
{
    public float speed = 2f; // Vitesse de déplacement
    public float range = 60f; // Plage de déplacement en degrés

    private float initialPositionX; // Position initiale en x

    void Start()
    {
        initialPositionX = transform.position.x; // Enregistrer la position initiale
    }

    void Update()
    {
        // Calculer la position x en fonction du temps
        float offsetX = Mathf.Sin(Time.time * speed) * range;

        // Déplacer l'objet
        transform.position = new Vector3(initialPositionX + offsetX, transform.position.y, transform.position.z);
    }
}
