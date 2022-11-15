using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    // Filtering which layer of colliders will block the player
    public ContactFilter2D movementFilter;
    // The colliders which get by the player (or by Cast() function)
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    // Movement-Smoothing amount
    public float collisionOffset = 0.05f;

    // Animators
    public Animator bodyAnimator;
    public Animator armAnimator;
    public Animator hairAnimator;

    // Joystick
    public Joystick joystick;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        // Animations
        // Body
        bodyAnimator.SetFloat("Horizontal", movement.x);
        bodyAnimator.SetFloat("Vertical", movement.y);
        bodyAnimator.SetFloat("Speed", movement.sqrMagnitude);
        // Arm
        armAnimator.SetFloat("Horizontal", movement.x);
        armAnimator.SetFloat("Vertical", movement.y);
        armAnimator.SetFloat("Speed", movement.sqrMagnitude);
        // Hair
        hairAnimator.SetFloat("Horizontal", movement.x);
        hairAnimator.SetFloat("Vertical", movement.y);
        hairAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // FixedUpdate is called once per physics update (50 times per second)
    void FixedUpdate()
    {
        bool success = MovePlayer(movement);
        if (!success)
        {
            // If the player can't move, try to move in the horizontal direction
            success = MovePlayer(new Vector2(movement.x, 0));
            if (!success)
            {
                // If the player can't move in the horizontal direction, try to move in the vertical direction
                success = MovePlayer(new Vector2(0, movement.y));
            }
        }
    }

    public bool MovePlayer(Vector2 direction)
    {
        int count = rb.Cast(
            direction, 
            movementFilter, 
            castCollisions, 
            (moveSpeed * Time.fixedDeltaTime + collisionOffset));
        
        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else return false;
    }
}
