using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorInsectoVolador : MonoBehaviour
{
    public GameObject insecto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            insecto.GetComponent<AIBasic>().enabled = true;
            insecto.GetComponent<MineAtack>().enabled = true;
        }
    }
}
