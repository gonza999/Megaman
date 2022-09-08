using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAtack : MonoBehaviour
{
    public GameObject player;
    public float speed = 1;
    public static float wait=0;
    public static bool atack = false;
    public Animator Animator;
    public Transform waypoint;
   
    private void Update()
    {
        if (atack && wait==0)
        {
            Animator.SetBool("Atack",true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, speed * Time.deltaTime);
        }
        if (transform.position==waypoint.position)
        {
            wait = 0;
            Animator.SetBool("Atack", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            atack = false;
            wait = 2;
        }
    }
}
