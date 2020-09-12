using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7;
    public bool examine;
    [HideInInspector] public bool isFacingRight;
    private bool disableMovement;
    private bool isIndoors;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private ParticleSystem particles;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip[] stepSounds;
    [SerializeField] private AudioClip[] attackSounds;
    
    void Awake()
    {  
    	isFacingRight = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
        
        //Start this level on the right end side looking left
        if(SceneManager.GetActiveScene().name == "Denial_House")
        {
        	Flip();
        }

        //Check if the current scene is an indoors scene
        string currentSceneType = SceneManager.GetActiveScene().path.Substring(14,6);
        if(currentSceneType == "Indoor")
        {
            isIndoors = true;
        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (!disableMovement)
        {
            move.x = Input.GetAxis("Horizontal");
            if(isIndoors == true)
            {
                move.y = Input.GetAxis("Vertical");
            }
        }

        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(velocity.x > 0.01f && !isFacingRight)
        {
            Flip();
        }
        if(velocity.x < -0.01f && isFacingRight)
        {
            Flip();
        }


        if (Input.GetButton("Examine"))
        {
            examine = true;
        }
        else
        {
            examine = false;
        }

        if(move.x != 0 || move.y != 0)
        {
        	animator.SetBool("isMoving", true);
        }
        else
        {
        	animator.SetBool("isMoving", false);
        }

        targetVelocity = move * maxSpeed;
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;

        isFacingRight = !isFacingRight;
   
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool getExamine() {
        return examine;
    }

    void Footstep()
    {
        if (audio)
        {
            audio.PlayOneShot(stepSounds[Random.Range(0, stepSounds.Length)]);
        }
    }

    void Particles()
    {    
       particles.Emit(10); 
    }

    public void setMovementDisable(bool value) {
        disableMovement = value;
    }
}