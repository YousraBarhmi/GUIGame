using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject firePrefab; // Prefab du feu à instancier
    public float fireForce = 10f; // Force du feu
    public RectTransform playerPanelRect; // Rect Transform du panel du joueur

    void Update()
    {
        // Vérifie si le bouton gauche de la souris est enfoncé
        if (Input.GetMouseButtonDown(0))
        {
            // Obtient la position du clic de la souris dans l'espace du monde
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Vérifie si la position du clic est à l'intérieur du rect transform du panel du joueur
            if (IsMouseInsidePlayerPanel(mouseWorldPosition))
            {
                // Instantie le feu à la position du joueur
                GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);

                // Trouve la position du clic dans le monde (avec la même coordonnée Z que le panel du joueur)
                Vector3 targetPosition = GetMouseWorldPosition(playerPanelRect.position.z);

                // Calcule la direction du feu
                Vector3 fireDirection = (targetPosition - transform.position).normalized;

                // Applique une force au feu dans la direction calculée
                fire.GetComponent<Rigidbody2D>().AddForce(fireDirection * fireForce, ForceMode2D.Impulse);

                // Désactive le feu s'il entre en collision
                Destroy(fire, 5f); // Le feu sera détruit après 5 secondes (vous pouvez ajuster ce temps selon vos besoins)
            }
        }
    }

    // Vérifie si la position du clic de la souris est à l'intérieur du rect transform du panel du joueur
    bool IsMouseInsidePlayerPanel(Vector3 mouseWorldPosition)
    {
        // Convertit la position du clic en position dans l'espace du panel du joueur
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(playerPanelRect, Input.mousePosition, Camera.main, out localPoint);

        // Vérifie si la position locale est à l'intérieur des dimensions du panel
        return playerPanelRect.rect.Contains(localPoint);
    }

    // Récupère la position du clic de la souris dans le monde avec une coordonnée Z fixe
    Vector3 GetMouseWorldPosition(float z)
    {
        // Récupère la position de la souris dans l'espace de l'écran
        Vector3 mousePosition = Input.mousePosition;

        // Fixe la coordonnée Z à la valeur spécifiée
        mousePosition.z = z;

        // Convertit la position de la souris en position dans le monde
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
