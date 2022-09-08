using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Intro : MonoBehaviour
{
    public GameObject megaman;
    private void Start()
    {
        megaman.GetComponent<PlayerMove>().enabled = false;
    }
}
