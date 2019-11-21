using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public void SetScoreText(int score)
    {
        _scoreText.SetText("Score: " + score);
    }
}
