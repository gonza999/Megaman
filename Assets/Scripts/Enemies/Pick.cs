using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    public float speed = 1;

    public float lifeTime = 10;
    public float wait = 0.5f;
    public bool left = true;

    private void Start()
    {
        System.Random random = new System.Random();
        Destroy(gameObject, lifeTime);
        float tiempo = random.Next(1,5);
        tiempo = tiempo * 0.1f;
        wait = tiempo;
    }

    private void Update()
    {
        wait -= Time.deltaTime;
        if (left)
        {
            if (wait >= 0)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
        else
        {
            if (wait >= 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
    }
}
