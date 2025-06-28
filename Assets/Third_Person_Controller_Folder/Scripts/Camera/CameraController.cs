using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("----- Follow Target -----")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform target;
    [SerializeField] private float cameraDistance = -2.4f;

    [Header("----- Orbit Settings -----")]
    [SerializeField] private float minRotationX = -60f;
    [SerializeField] private float maxRotationX = 50f;
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private bool smoothDamp = false;
    [SerializeField] private float smoothTime = 0.1f;

    // ----- Temp Variables -----
    private Vector3 rotation;
    private Vector3 currentVelocity;
    private float pitch;
    private float yaw;

    private void Start()
    {
        if (target == null)
        {
            enabled = false;
            return;
        }

        rotation = transform.eulerAngles;
    }

    // ----- Late Update -----
    private void LateUpdate()
    {
        if (PopupController.AnyPanelOpen) return;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minRotationX, maxRotationX);
        Vector3 targetRotation = new Vector3(pitch, yaw, 0f);
        if (smoothDamp)
        {
            rotation = Vector3.SmoothDamp(rotation, targetRotation, ref currentVelocity, smoothTime);
        }
        else
        {
            rotation = targetRotation;
        }
        transform.rotation = Quaternion.Euler(rotation);
        transform.position = target.position;
        if (playerCamera != null)
        {
            playerCamera.transform.localPosition = Vector3.forward * cameraDistance;
            playerCamera.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    // ----- OnEnable and OnDisable
    private void OnEnable()
    {
        DelegatesData.GetCamera += () => playerCamera;
    }

    private void OnDisable()
    {
        DelegatesData.GetCamera -= () => playerCamera;
    }
}