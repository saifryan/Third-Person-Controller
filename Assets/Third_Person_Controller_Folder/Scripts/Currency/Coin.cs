using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [Header("----- Idle Animation -----")]
    [SerializeField] private float rotateSpeed = 90f;
    [SerializeField] private float bobHeight = 0.25f;
    [SerializeField] private float bobSpeed = 2f;

    [Header("----- Coin Settings -----")]
    [SerializeField] private int coinValue = 1;

    private Vector3 startPosition;
    private float bobOffset;

    private void Start()
    {
        startPosition = transform.position;
        bobOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        // Idle rotate + bobbing
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        float bob = Mathf.Sin(Time.time * bobSpeed + bobOffset) * bobHeight;
        transform.position = startPosition + new Vector3(0f, bob, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Trigger collection logic
        DelegatesData.ShowFeedbackWithColorIndex(transform.position, 2, "+1");
        PoolingManager.Instance.GetCoinCollectParticle().transform.position = transform.position;
        DelegatesData.CoinAdd(coinValue);
        SoundManager.Instance?.PlaySound(SoundManager.Instance.CoinCollect);

        // Disable coin
        gameObject.SetActive(false);
    }
}
