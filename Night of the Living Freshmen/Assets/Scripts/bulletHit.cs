using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    //Sets controls in unity editor for how much HP an object will have,
    //and how much damage an attack will do, defaults to 100HP, and 25 damage
    [Header("Properties")]
    public int HP = 100;
    public int damage = 25;
    private Animator enemyAnimator;
    private BoxCollider enemyBoxCollider;
    private Rigidbody enemyRB;
    private bool dead = false;

    //Get the animator for the attached object
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyBoxCollider = GetComponent<BoxCollider>();
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            dead = true;
            enemyAnimator.SetTrigger("Fall");
            enemyBoxCollider.enabled = false;
            enemyRB.useGravity = false;
            enemyRB.constraints = RigidbodyConstraints.None;
            enemyRB.constraints = RigidbodyConstraints.FreezeRotationZ;
            enemyRB.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= damage;                                       // Lose health
            Destroy(collision.gameObject);                      // Delete the bullet after the enemy is hit by it
        }
    }

    // This will be called in the enemy's fall animation
    // Remove the enemy after animation
    private void RemovedEnemy()
    {
        Destroy(gameObject);
    }

    // Used for EnemyMovement script
    public bool Death()
    {
        if (dead)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
