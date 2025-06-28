using UnityEngine;

public class AnimationHandler
{
    private readonly Animator animator;

    private static readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
    private static readonly int FreeFallHash = Animator.StringToHash("FreeFall");
    private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");
    private static readonly int JumpHash = Animator.StringToHash("JumpTrigger");

    public AnimationHandler(Animator animator)
    {
        this.animator = animator;
    }

    public void UpdateAnimations(float moveSpeed, bool isGrounded, Rigidbody rb)
    {
        animator.SetFloat(MoveSpeedHash, moveSpeed);
        animator.SetBool(IsGroundedHash, isGrounded);
        animator.SetBool(FreeFallHash, !isGrounded && rb.velocity.y < -0.1f);
    }

    public void TriggerJump()
    {
        animator.SetTrigger(JumpHash);
    }
}