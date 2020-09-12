using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject head;
    private bool attacking = false;

    private float attackTimer = 0f;
    private float attackCoolDown = 0.3f;

    private float originOffset = 0.5f;
    public float raycastMaxDistance;

    private int dmg = 1;
    private bool canAttack = false;

    // Launch a raycast in the forward direction from where the player is facing.
    private Vector2 direction = new Vector2(1, 0);

    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && !attacking)
        {
            RaycastHit2D hit = CheckRaycast(direction);
            if (hit.collider)
            {
                Transform objectHit = hit.transform;
                AI ai = objectHit.GetComponent<AI>();
                if (ai.isEnabled()) {
                    attacking = true;
                    attackTimer = attackCoolDown;
                   // Debug.Log("Hit the collidable object " + objectHit.name);
                    hit.collider.SendMessageUpwards("Damage", dmg);
                } else {
                   // Debug.Log("is not enabled.");
                }
            }
        }

        if (attacking)
        {
            if (attackTimer >= 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }

        animator.SetBool("attack", attacking);
    }

    /// <summary>
    /// Raycasts out from the player and returns the targets hit.
    /// </summary>
    /// <param name="direction"></param>
    public RaycastHit2D CheckRaycast(Vector2 direction)
    {
        LayerMask mask = LayerMask.GetMask("Enemy");
        Vector2 startingPosition = new Vector2(head.transform.position.x, head.transform.position.y + 0.7f);

        return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, mask);
    }
}
