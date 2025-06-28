using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("----- References -----")]
    [SerializeField] Rigidbody rb;
    public Transform cameraTransform;
    public Animator animator;
    [SerializeField] private PushDetector pushDetector;
    [SerializeField] private GroundDetect groundDetect;

    [Header("----- Movement -----")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float pushSpeed = 2f;
    public float jumpForce = 7f;
    [Header("----- Ground Detect -----")]
    [SerializeField] float GroundedOffset = -0.22f;
    [SerializeField] float GroundRadius = 0.28f;
    [SerializeField] LayerMask GroundMask;

    
    private Vector3 moveInput;
    private bool jumpQueued;
    private bool isPushingObject;
    AudioSource PushAudioSource = null;

    private MovementHandler movementHandler;
    private JumpHandler jumpHandler;
    private AnimationHandler animationHandler;

    public bool IsRunning => Input.GetKey(KeyCode.LeftShift) && !isPushingObject;

    private void Start()
    {
        NewCharacterShow(animator);
        // Init Data
        movementHandler = new MovementHandler(this, rb);
        jumpHandler = new JumpHandler(this, rb);
        groundDetect = new GroundDetect(transform, GroundedOffset, GroundRadius, GroundMask);

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    public void NewCharacterShow(Animator anim)
    {
        animator = anim;
        animator.gameObject.AddComponent<FootStep>();
        animationHandler = new AnimationHandler(animator);
    }

    private void Update()
    {
        if (PopupController.AnyPanelOpen) return;
        movementHandler.ReadInput();
        moveInput = movementHandler.MoveInput;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isPushingObject)
        {
            jumpQueued = true;
        }
    }

    private void FixedUpdate()
    {
        if (PopupController.AnyPanelOpen) return;
        isPushingObject = pushDetector != null && pushDetector.isTouchingPushable;

        float currentSpeed = isPushingObject ? pushSpeed : (IsRunning ? runSpeed : walkSpeed);
        movementHandler.MoveCharacter(moveInput, currentSpeed);

        if (jumpHandler.HandleJump(jumpQueued, IsGrounded()))
        {
            animationHandler.TriggerJump();
        }
        jumpQueued = false;

        float animatorSpeed = 0f;
        if (moveInput.magnitude > 0.1f)
        {
            if (isPushingObject)
            {
                animatorSpeed = 0.3f;
                PushSoundPlay();
            }
            else if (IsRunning)
            {
                animatorSpeed = 1f;
                PushSoundStop();
            }
            else
            {
                animatorSpeed = 0.5f;
                PushSoundStop();
            }
        }
        else
        {
            PushSoundStop();
        }

        animationHandler.UpdateAnimations(animatorSpeed, IsGrounded(), rb);


    }

    private bool IsGrounded()
    {
        return groundDetect != null && groundDetect.IsGrounded();
    }

    void PushSoundPlay()
    {
        if (PushAudioSource == null)
            PushAudioSource = SoundManager.Instance.PlaySoundLoop(SoundManager.Instance.StonePush);
    }

    void PushSoundStop()
    {
        if (PushAudioSource != null)
        {
            PushAudioSource.Stop();
            PushAudioSource = null;
        }
    }
}