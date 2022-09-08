using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    public float speed = 2;

    public bool left;

    public float lifeTime = 2;
    public AudioSource clip;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        if (!transform.GetComponent<Animator>().GetBool("Hit"))
        {
            if (left)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else
        {
            transform.GetComponent<Animator>().Play("Hit");
            Destroy(gameObject, 0.1f);
        }
    }

}
