using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    // Animators
    public Animator bodyAnimator;
    public Animator armAnimator;
    public Animator hairAnimator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
