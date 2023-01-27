using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathSound = default;
    private float jumpForce = 700f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    #region Player's componet
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    #endregion

    void Start()
    {
        // Set player's components
        playerRigid = gameObject.GetComponentMust<Rigidbody2D>();
        playerAni = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();

        GFunc.Assert(playerRigid != null || playerRigid != default);
        GFunc.Assert(playerAni != null || playerAni != default);
        GFunc.Assert(playerAudio != null || playerAudio != default);
    }

    
    void Update()
    {
        if(isDead == true) { return; }

        // Jump
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigid.velocity = Vector3.zero;
            playerRigid.AddForce(Vector2.up * jumpForce);
            playerAudio.Play();
        }   // if: player jump
        else if(Input.GetMouseButtonUp(0) && playerRigid.velocity.y > 0)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        } // player가 공중에 떠 있을 때

        playerAni.SetBool("isGrounded", isGrounded);
    }

    private void Die()
    {
        playerAni.SetTrigger("isDie");
        playerAudio.clip = deathSound;
        playerAudio.Play();
        playerRigid.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.OnPlayerDead();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("DeadZone") && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
