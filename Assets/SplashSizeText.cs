using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SplashSizeText : MonoBehaviour
{
    public LevelManagerScriptableObject levelManager;

    private void Update()
    {
        var text = GetComponent<TextMeshProUGUI>();
        int sizePercent = Mathf.CeilToInt(levelManager.splashSizeMultiplier * 100f) - 100;
        text.text = "Jato +" + sizePercent + "%";
    }
}
