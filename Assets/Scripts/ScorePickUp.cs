using UnityEngine;

public class ScorePickUp : MonoBehaviour
{
    [SerializeField] int points = 10;

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.AddScore(points);
            Destroy(gameObject);
        }
    }
}