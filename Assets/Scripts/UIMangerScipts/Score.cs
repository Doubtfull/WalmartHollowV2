using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int scores;
    [SerializeField] TMPro.TextMeshProUGUI text;

    [ContextMenu("increase coins")]
    public void addScore()
    {
        scores = scores + 1;
        text.text = scores.ToString();
    }
}
