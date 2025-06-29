using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager PoolingManagerInstance;
    [Header("----- Sound Manager -----")]
    public SoundManager soundManager;
    [Header("----- Particle Data -----")]
    // ----- Coin Collect Particle -----
    [SerializeField] GameObject Coin;
    [SerializeField] Transform CoinParent;
    List<GameObject> TempCoinStore = new List<GameObject>();
    // ----- Coin Collect Particle -----
    [SerializeField] GameObject CoinCollectParticle;
    [SerializeField] Transform CoinCollectParticleParent;
    List<GameObject> TempCoinCollectParticleStore = new List<GameObject>();
    // ----- Foot Step Particle -----
    [SerializeField] GameObject FootStepParticle;
    [SerializeField] Transform FootStepParticleParent;
    List<GameObject> TempFootStepParticleStore = new List<GameObject>();

    #region Instance
    public static PoolingManager Instance
    {
        get
        {
            if (PoolingManagerInstance == null)
            {
                PoolingManager sceneLoader = (PoolingManager)FindObjectOfType(typeof(PoolingManager));
                if (sceneLoader != null)
                {
                    PoolingManagerInstance = sceneLoader;
                }
                else
                {
                    GameObject SceneLoaderPrefab = Resources.Load<GameObject>("PoolingManager");
                    PoolingManagerInstance = (Instantiate(SceneLoaderPrefab)).GetComponent<PoolingManager>();
                }
            }
            return PoolingManagerInstance;
        }
    }
    #endregion

    #region Awake and Start
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // Get rid of any old SceneLoaders
        if (PoolingManagerInstance != null && PoolingManagerInstance != this)
        {
            Destroy(PoolingManagerInstance.gameObject);
            PoolingManagerInstance = this;
        }
    }
    #endregion

    #region Get Coin
    // Get Coin Collect Particle Spawn
    void CoinSpawn()
    {
        GameObject item = Instantiate(Coin, CoinParent);
        TempCoinStore.Add(item);
        item.gameObject.SetActive(false);
    }

    // Get Get Coin Collect Particle
    public GameObject GetCoin()
    {
        GameObject item = null;
        item = TempCoinStore.FirstOrDefault(item => !item.gameObject.activeSelf);

        if (item == null)
        {
            CoinSpawn();
            item = TempCoinStore.FirstOrDefault(item => !item.gameObject.activeSelf);
        }
        item.SetActive(true);
        return item;
    }
    #endregion

    #region Get Coin Collect Particle
    // Get Coin Collect Particle Spawn
    void CoinCollectParticleSpawn()
    {
        GameObject item = Instantiate(CoinCollectParticle, CoinCollectParticleParent);
        TempCoinCollectParticleStore.Add(item);
        item.gameObject.SetActive(false);
    }

    // Get Get Coin Collect Particle
    public GameObject GetCoinCollectParticle()
    {
        GameObject item = null;
        item = TempCoinCollectParticleStore.FirstOrDefault(item => !item.gameObject.activeSelf);

        if (item == null)
        {
            CoinCollectParticleSpawn();
            item = TempCoinCollectParticleStore.FirstOrDefault(item => !item.gameObject.activeSelf);
        }
        item.SetActive(true);
        return item;
    }
    #endregion

    #region Get Foot Step Particle
    // Get Coin Collect Particle Spawn
    void FootStepParticleSpawn()
    {
        GameObject item = Instantiate(FootStepParticle, FootStepParticleParent);
        TempFootStepParticleStore.Add(item);
        item.gameObject.SetActive(false);
    }

    // Get Get Coin Collect Particle
    public GameObject GetFootStepParticle()
    {
        GameObject item = null;
        item = TempFootStepParticleStore.FirstOrDefault(item => !item.gameObject.activeSelf);

        if (item == null)
        {
            FootStepParticleSpawn();
            item = TempFootStepParticleStore.FirstOrDefault(item => !item.gameObject.activeSelf);
        }
        item.SetActive(true);
        return item;
    }
    #endregion
}