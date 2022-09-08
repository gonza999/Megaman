using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyDamage : MonoBehaviour
{
    public Animator animator;
    public AudioSource[] clips;

    public int life = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet") && !transform.GetComponent<Animator>().GetBool("Hit"))
        {
            life--;
            clips[0].Play();
            animator.Play("Hit");
            collision.transform.GetComponent<Animator>().SetBool("Hit",true);
            Invoke("WaitHit",0.5f);
            transform.GetComponent<Animator>().SetBool("Hit", true);
        }
        if (collision.transform.CompareTag("Bullet1") && !transform.GetComponent<Animator>().GetBool("Hit"))
        {
            life-=2;
            clips[0].Play();
            animator.Play("Hit");
            collision.transform.GetComponent<Animator>().SetBool("Hit", true);
            Invoke("WaitHit", 0.5f);
            transform.GetComponent<Animator>().SetBool("Hit", true);
        }
        if (collision.transform.CompareTag("Bullet2") && !transform.GetComponent<Animator>().GetBool("Hit"))
        {
            life-=3;
            clips[1].Play();
            animator.Play("Hit");
            collision.transform.GetComponent<Animator>().SetBool("Hit", true);
            Invoke("WaitHit", 0.5f);
            transform.GetComponent<Animator>().SetBool("Hit", true);
        }
        CalculateDamage();
    }

    private void CalculateDamage()
    {
        if (life<=0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.4f);
        }
    }
    private void WaitHit()
    {
        transform.GetComponent<Animator>().SetBool("Hit",false);
    }

  
}
