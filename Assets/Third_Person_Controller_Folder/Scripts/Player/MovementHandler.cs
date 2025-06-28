using UnityEngine;

public class MovementHandler
{
    private readonly PlayerController controller;
    private readonly Rigidbody rb;

    public Vector3 MoveInput { get; private set; }

    public MovementHandler(PlayerController controller, Rigidbody rb)
    {
        this.controller = controller;
        this.rb = rb;
    }

    public void ReadInput()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 camForward = controller.cameraTransform.forward;
        Vector3 camRight = controller.cameraTransform.right;
        camForward.y = camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        MoveInput = (camForward * inputZ + camRight * inputX).normalized;
    }

    public void MoveCharacter(Vector3 moveInput, float speed)
    {
        Vector3 horizontalVelocity = moveInput * speed;
        horizontalVelocity.y = rb.velocity.y;
        rb.velocity = horizontalVelocity;

        if (moveInput.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}
