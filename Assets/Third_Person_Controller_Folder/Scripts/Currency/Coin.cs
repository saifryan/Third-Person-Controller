using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [Header("----- Idle Animation -----")]
    [SerializeField] private float rotateSpeed = 90f;
    [SerializeField] private float bobHeight = 0.25f;
    [SerializeField] private float bobSpeed = 2f;

    [Header("----- Collect Animation -----")]
    [SerializeField] private float collectMoveHeight = 1.5f;
    [SerializeField] private float collectDuration = 0.4f;
    [SerializeField] private float collectRotateSpeed = 360f;
    [SerializeField] private int coinValue = 1;

    // Temp Variables
    private bool isCollected = false;
    private float collectTimer = 0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 startScale;
    private float bobOffset;

    private void Start()
    {
        startPosition = transform.position;
        startScale = transform.localScale;
        bobOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        if (isCollected)
        {
            collectTimer += Time.deltaTime;
            float t = collectTimer / collectDuration;

            // ----- Move up -----
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            // ----- Rotate faster -----
            transform.Rotate(Vector3.up, collectRotateSpeed * Time.deltaTime, Space.World);
            // ----- Scale down -----
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);

            if (t >= 1f)
                Destroy(gameObject);

            return;
        }

        // ----- Idle Animation (rotate + bob) -----
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        float bob = Mathf.Sin(Time.time * bobSpeed + bobOffset) * bobHeight;
        transform.position = startPosition + new Vector3(0f, bob, 0f);
    }

    // ----- On Trigger Enter -----
    private void OnTriggerEnter(Collider other)
    {
        if (isCollected || !other.CompareTag("Player"))
            return;

        isCollected = true;
        collectTimer = 0f;
        DelegatesData.ShowFeedbackWithColorIndex(transform.position, 2, "+1");
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.up * collectMoveHeight;
        startScale = transform.localScale;

        GetComponent<Collider>().enabled = false;

        DelegatesData.CoinAdd(coinValue);
        SoundManager.Instance?.PlaySound(SoundManager.Instance.CoinCollect);
    }
}
