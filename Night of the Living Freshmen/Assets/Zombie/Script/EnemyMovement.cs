using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;              // Create a GameObject reference
    private Animator enemyAnimator;         // Reference to enemy's animations
    public float speed = 0.5f;              // Enemy's movement speed
    private bool walking = false;           // Walking state
    private bool attack = false;            // Attack state

    // Start is called before the first frame update
    void Start()
    {
        // Locate where player is in the game
        player = GameObject.Find("PlayerCapsule");
        // Get the enemy's animations
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Compute the distance between the zombie and player
        float distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
        float distanceZ = Mathf.Abs(player.transform.position.z - transform.position.z);
        // If enemy is not dead, then continue, else stop all movement/animations
        // If the distance is too far, then have zombie walk towards the player.
        // If enemy is close to player, then attack
        if (!gameObject.GetComponent<bulletHit>().Death())
        {
            if (distanceX > 1 || distanceZ > 1)
            {
                walking = true;
                attack = false;
                Walk();
            }
            else
            {
                walking = false;
                attack = true;
            }
        }
        else
        {
            walking = false;
            attack = false;
        }


        enemyAnimator.SetBool("Attack", attack);
        enemyAnimator.SetBool("Walk", walking);
    }

    // Enemy's movement function
    private void Walk()
    {
        transform.LookAt(player.transform);                                 // Look at player
        transform.Translate(Vector3.forward * speed * Time.deltaTime);      // Move towards the player
    }
}
