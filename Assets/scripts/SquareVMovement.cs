using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareVMovement : MonoBehaviour
{
    public float speed = 1.5f; // Vitesse de déplacement
    public float range = 13f; // Plage de déplacement en degrés

    private float initialPositionY; // Position initiale en y

    void Start()
    {
        initialPositionY = transform.position.y; // Enregistrer la position initiale
    }

    void Update()
    {
        // Calculer la position x en fonction du temps
        float offsetY = Mathf.Sin(Time.time * speed) * range;

        // Déplacer l'objet
        transform.position = new Vector3( transform.position.x, initialPositionY + offsetY, transform.position.z);
    }
}
