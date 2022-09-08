using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpForce = 2;

    public Rigidbody2D rigidbody2D;

    public SpriteRenderer spriteRenderer;
    public int timeJump =0;
    public int limitJump=10;
    public GameObject bulletPrefabRight;
    public GameObject bulletPrefabLeft;
    public GameObject bulletMediumPrefabRight;
    public GameObject bulletMediumPrefabLeft;
    public GameObject bulletHighPrefabRight;
    public GameObject bulletHighPrefabLeft;
    public Animator animator;
    public Transform launchSpawnPointRight;
    public Transform launchSpawnPointLeft;
    public Transform launchSpawnDownPointLeft;
    public Transform launchSpawnDownPointRight;
    public GameObject charge;
    public GameObject charge1;
    public float timeCharge=0;
    public bool chargeAtack = false;
    public AudioSource[] clips;

    private void Update()
    {
        if (chargeAtack)
        {
            timeCharge += Time.deltaTime;
        }
        else
        {
            timeCharge = 0;
        }
        VerificarCharge();
        
        if (Input.GetKey(KeyCode.A))
        {
            clips[1].Play();
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.A) )
        {
            Caer();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Down();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Up();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Shoot", true);
            Shoot();
            chargeAtack = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            chargeAtack = false;
            charge.SetActive(false);
            charge1.SetActive(false);
            AtackWithCharge();
        }

        if (CheckGround.isGrounded)
        {
            clips[0].Play();
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);
            timeJump = 0;

        }
        else
        {
            timeJump++;
        }

        if (rigidbody2D.velocity.y < 0)
        {
            if (!CheckGround.isGrounded)
            {
                animator.SetBool("Falling", true);
            }

        }
        else if (rigidbody2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);

        }

        if (!Input.anyKey && CheckGround.isGrounded)
        {
            animator.SetBool("Shoot", false);

        }
    }

    private void AtackWithCharge()
    {
        if (timeCharge > 1 && timeCharge<3)
        {
            animator.SetBool("Shoot", true);
            LaunchBulletMedium();
        }
        if (timeCharge > 3)
        {
            animator.SetBool("Shoot", true);
            LaunchBulletHigh();
        }
    }

   
    private void VerificarCharge()
    {
        if (timeCharge>1)
        {
            charge.SetActive(true);
        }
        if (timeCharge>3)
        {
            charge1.SetActive(true);
        }
    }

    private void Up()
    {
        animator.SetBool("Down", false);

    }

    private void Down()
    {
        if (CheckGround.isGrounded)
        {
            animator.SetBool("Down", true);
        }
    }

    private void Caer()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Falling", true);
    }

    private void Jump()
    {
        if (!animator.GetBool("Falling")&& timeJump<limitJump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            animator.SetBool("Jump", true);
        }
    }
    public void Shoot()
    {
          LaunchBullet();
    }
    private void LaunchBulletHigh()
    {
        GameObject newBullet;
        if (!animator.GetBool("Down"))
        {
            if (!spriteRenderer.flipX)
            {
                newBullet = Instantiate(bulletHighPrefabRight, launchSpawnPointRight.position, launchSpawnPointRight.rotation);
            }
            else
            {
                newBullet = Instantiate(bulletHighPrefabLeft, launchSpawnPointLeft.position, launchSpawnPointLeft.rotation);
            }
        }
        else if (animator.GetBool("Down"))
        {
            if (!spriteRenderer.flipX)
            {
                newBullet = Instantiate(bulletHighPrefabRight, launchSpawnDownPointRight.position, launchSpawnDownPointRight.rotation);
            }
            else
            {
                newBullet = Instantiate(bulletHighPrefabLeft, launchSpawnDownPointLeft.position, launchSpawnDownPointLeft.rotation);

            }
        }
    }


    private void LaunchBulletMedium()
    {
        GameObject newBullet;
        if (!animator.GetBool("Down"))
        {
            if (!spriteRenderer.flipX)
            {
                newBullet = Instantiate(bulletMediumPrefabRight, launchSpawnPointRight.position, launchSpawnPointRight.rotation);
            }
            else
            {
                newBullet = Instantiate(bulletMediumPrefabLeft, launchSpawnPointLeft.position, launchSpawnPointLeft.rotation);
            }
        }
        else if (animator.GetBool("Down"))
        {
            if (!spriteRenderer.flipX)
            {
                newBullet = Instantiate(bulletMediumPrefabRight, launchSpawnDownPointRight.position, launchSpawnDownPointRight.rotation);
            }
            else
            {
                newBullet = Instantiate(bulletMediumPrefabLeft, launchSpawnDownPointLeft.position, launchSpawnDownPointLeft.rotation);
       
            }
        }
    }
    public void LaunchBullet()
    {
        GameObject newBullet;
        if (!animator.GetBool("Down"))
        {
            if (!spriteRenderer.flipX)
            {
                newBullet = Instantiate(bulletPrefabRight, launchSpawnPointRight.position, launchSpawnPointRight.rotation);            }
            else
            {
                newBullet = Instantiate(bulletPrefabLeft, launchSpawnPointLeft.position, launchSpawnPointLeft.rotation);
            }
        }
        else if(animator.GetBool("Down"))
        {
            if (!spriteRenderer.flipX)
            {
                newBullet = Instantiate(bulletPrefabRight, launchSpawnDownPointRight.position, launchSpawnDownPointRight.rotation);
            }
            else
            {
                newBullet = Instantiate(bulletPrefabLeft, launchSpawnDownPointLeft.position, launchSpawnDownPointLeft.rotation);
            }
        }
    }
    void FixedUpdate()
    {
      
        if (Input.GetKey(KeyCode.LeftArrow) && !animator.GetBool("Down"))
        {
            if (animator.GetBool("Falling"))
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -jumpForce);
                rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
            }
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            if (!animator.GetBool("Jump"))
            {
                animator.SetBool("Shoot", false);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !animator.GetBool("Down"))
        {
            if (animator.GetBool("Falling"))
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -jumpForce);
                rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
            }
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
            if (!animator.GetBool("Jump"))
            {
                animator.SetBool("Shoot", false);
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            animator.SetBool("Run", false);
        }
       
    }
}
