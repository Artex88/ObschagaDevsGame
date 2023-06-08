using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("item")|| collision.gameObject.CompareTag("line"))
        {
            Destroy(collision.gameObject);
        }
    }
}
