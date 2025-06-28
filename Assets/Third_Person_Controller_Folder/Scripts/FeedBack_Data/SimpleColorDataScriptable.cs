using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Simple Colors", menuName = "Scriptables/New Simple Colors")]
public class SimpleColorDataScriptable : ScriptableObject
{
    [SerializeField] Color[] simpleColors;

    // ----- Get Color -----
    public Color GetColor(int colorindex)
    {
        return simpleColors[colorindex];
    }

    // ----- Get Total Length -----
    public int GetTotalLength()
    {
        return simpleColors.Length;
    }
}