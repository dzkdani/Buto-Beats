using UnityEngine;
using System.Collections;

public class BoundaryBox : MonoBehaviour
{

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
            Destroy(other.gameObject);
    }
}
