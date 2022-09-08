using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerDamage : MonoBehaviour
{
    public Animator animator;
    public AudioSource clip;
    public float force=2;
    public float daño = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CalculateDamage();
        if (collision.transform.CompareTag("Enemy"))
        {
            LifeBar.hpActual -=daño;
            clip.Play();
            animator.Play("Damage");
            gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * force);
            Invoke("WaitHit", 0.5f);
            transform.GetComponent<Animator>().SetBool("Hit", true);
        }
    }

    private void CalculateDamage()
    {
        if (LifeBar.hpActual<=0)
        {
            Died();
         }
    }
    private void Died()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<PlayerMove>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DiedAnimation", 0.5f);
        Destroy(gameObject, 3);
    }
    private void DiedAnimation()
    {
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void WaitHit()
    {
        transform.GetComponent<Animator>().SetBool("Hit", false);
    }
}
