using UnityEngine;

public class DelegatesData
{
    // ----- Coin Update -----
    public delegate void coinUpdate();
    public static coinUpdate CoinUpdate;
    // ----- Coin Add -----
    public delegate void coinAdd(int amount);
    public static coinAdd CoinAdd;

    // ----- Camera Area -----
    public delegate Camera getCamera();
    public static getCamera GetCamera;

    // ----- Show FeedBack With Random Color -----
    public delegate void showFeedbackWithColorIndex(Vector3 startTarget, int colorindex, string message);
    public static showFeedbackWithColorIndex ShowFeedbackWithColorIndex;

    // ----- Press E Object Status -----
    public delegate void pressEObjectStatus(bool status);
    public static pressEObjectStatus PressEObjectStatus;
}