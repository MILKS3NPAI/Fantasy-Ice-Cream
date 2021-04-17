using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bx : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
