using System.Diagnostics;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.Save();
            UnityEngine.Debug.Log("Game saved at save point!");
        }
    }
}