using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutAsteroid : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cut")
        {
            Destroy(this.gameObject);
        }
    }
}