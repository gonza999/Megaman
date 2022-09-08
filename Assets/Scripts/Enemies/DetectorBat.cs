using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (BatAtack.wait==0)
            {
                BatAtack.atack = true;
            }
        }
    }
}
