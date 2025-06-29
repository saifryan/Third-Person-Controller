using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisable : MonoBehaviour
{
    // Variables
    [SerializeField] float DisableTime = 5f;

    // Object Disable Function
    public IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(DisableTime);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(TimeDelay());
    }
}
