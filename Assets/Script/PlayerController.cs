using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float gravityModifier;
    public bool isGround = true;
    public bool GameOver = false;
    private Animator playAnim;
    public ParticleSystem explosionEffect;
    public ParticleSystem dirtEffect;
    public AudioSource jumpSound;
    public AudioSource crashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && GameOver != true)
        {
            playAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * 700, ForceMode.Impulse);
            isGround = false;
            dirtEffect.Stop();
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            dirtEffect.Play();
            isGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            explosionEffect.Play();
            dirtEffect.Stop();
            GameOver = true;
            playAnim.SetBool("Death_b", true);
            playAnim.SetInteger("DeathType_int", 1);
            crashSound.Play();
        }
    }
}
