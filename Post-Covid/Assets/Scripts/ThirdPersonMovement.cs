using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float jumpSpeed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float ySpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Gravity
        ySpeed += Physics.gravity.y * Time.deltaTime;

        // If character is grounded
        if (controller.isGrounded) {

            // This would be 0, but something with isGrounded is weird and it is fixed by this.
            // Source: https://www.youtube.com/watch?v=ynh7b-AUSPE
            // Note: source used 0.5f, but it did not remove the problem entirely - I think it's
            // down to how big the character is. Changing jumpSpeed did not appear to break this.
            ySpeed = -0.8f;

            // If jump button pressed (and control is allowed)
            if ( Input.GetKeyDown(KeyCode.Space) && (GameState.GetCurrentState() == GAMESTATE.PLAYING) ) {
                ySpeed = jumpSpeed;
            }

        }

        // If there is control input (and control is allowed)
        if ( direction.magnitude >= 0.1f && (GameState.GetCurrentState() == GAMESTATE.PLAYING) ) {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            Vector3 moveDirScaled = moveDir.normalized * speed;

            // Add y component
            moveDirScaled.y = ySpeed;

            controller.Move(moveDirScaled * Time.deltaTime);
        } else {

            // Only yspeed
            controller.Move(new Vector3(0f, ySpeed, 0f) * Time.deltaTime);
        }

    }

    private void OnApplicationFocus(bool focus) {

        if (focus) {
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
