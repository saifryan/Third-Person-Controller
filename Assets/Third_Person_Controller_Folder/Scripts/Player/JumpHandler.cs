using UnityEngine;

public class JumpHandler
{
    private readonly PlayerController controller;
    private readonly Rigidbody rb;

    public JumpHandler(PlayerController controller, Rigidbody rb)
    {
        this.controller = controller;
        this.rb = rb;
    }

    public bool HandleJump(bool jumpQueued, bool isGrounded)
    {
        if (jumpQueued && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // reset y
            rb.AddForce(Vector3.up * controller.jumpForce, ForceMode.Impulse);
            return true;
        }
        return false;
    }
}