using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarecrowController : MonoBehaviour
{
    private AI ai;
    private ParticleSystem particles;
    public Collider2D collider;
    private Animator animator;
    private Collider2D trigercollider;
    public GameObject examine; 
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip[] woodcreakSounds;
    [SerializeField] private AudioClip[] punchSounds;
    private bool isDead;
    private bool canHit;

    public PhaseControl phaseControl;
    public GameObject scarecrowFightPhase;

    void Start()
    {
        ai = GetComponent<AI>();
        particles = GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        trigercollider = GetComponent<Collider2D>();
        particles.Stop();
    }

    void OnTriggerStay2D()
    {
        if(phaseControl.GetCurrentPhase() == scarecrowFightPhase && canHit == false)
        {
             ai.setEnable(true);
             canHit = true;
        }
        if (ai.isDead() && isDead == false)
        {
            animator.SetBool("isBroken", true);
            collider.enabled = false;
            isDead = true;
            ai.setEnable(false);
            trigercollider.enabled = false;
            examine.SetActive(false);
        }
        if (ai.isDamaged())
        {
            animator.SetBool("gotHit", true);
        }
    }

    void WoodCreekSound()
    {
        if (audio)
        {
            audio.PlayOneShot(woodcreakSounds[Random.Range(0, woodcreakSounds.Length)]);
        }
    }

    void PunchSound()
    {
        if (audio)
        {
            audio.PlayOneShot(punchSounds[Random.Range(0, punchSounds.Length)]);
        }
    }
    void ScarecrowParticles()
    {
        particles.Emit(40);
        animator.SetBool("gotHit", false);
    }
}
