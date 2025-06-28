using UnityEngine;

public class GroundDetect
{
    float GroundedOffset = -0.22f;
    float GroundRadius = 0.28f;
    LayerMask GroundMask;
    Transform PlayerTransform;

    public GroundDetect(Transform playerTransform, float groundedOffset, float groundRadius, LayerMask groundMask)
    {
        PlayerTransform = playerTransform;
        GroundedOffset = groundedOffset;
        GroundRadius = groundRadius;
        GroundMask = groundMask;
    }

    public bool IsGrounded()
    {
        var position = PlayerTransform.position;
        Vector3 spherePosition = new Vector3(position.x, position.y + GroundedOffset,
            position.z);
        return Physics.CheckSphere(spherePosition, GroundRadius, GroundMask);
    }
}