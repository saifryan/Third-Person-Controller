using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] CoinSpanwPoints;
    private List<GameObject> CoinStore = new List<GameObject>();

    private void Start()
    {
        int totalLength = CoinSpanwPoints.Length;
        for (int i = 0; i < totalLength; i++)
        {
            GameObject coin = PoolingManager.Instance.GetCoin();
            coin.transform.position = CoinSpanwPoints[i].position;
            CoinStore.Add(coin);
        }
    }


    private void OnDisable()
    {
        foreach (GameObject coin in CoinStore)
        {
            if (coin != null)
            {
                coin.SetActive(false);
            }
        }
    }
}
