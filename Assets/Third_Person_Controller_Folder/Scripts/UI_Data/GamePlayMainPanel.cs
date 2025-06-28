using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayMainPanel : MonoBehaviour
{
    [SerializeField] GameObject PressEObject;

    public void RetryButtonPress()
    {
        PopupController.AlertPanelOpen("Retry", "Are you sure? \n You went to retry", 4, true);
    }

    public void HomeButtonPress()
    {
        PopupController.AlertPanelOpen("Home", "Are you sure? \n You went to go home", 4, true);
    }

    // Press E Object Status
    void PressEObjectStatusFunction(bool status)
    {
        PressEObject.SetActive(status);
    }


    private void OnEnable()
    {
        // Press E Object Status
        DelegatesData.PressEObjectStatus += PressEObjectStatusFunction;
    }

    void OnDisable()
    {
        // Press E Object Status
        DelegatesData.PressEObjectStatus -= PressEObjectStatusFunction;
    }
}
