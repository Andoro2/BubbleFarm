using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{

    public int score;
    private TextMeshProUGUI text_;
    void Start()
    {
        score = 0;
        text_ = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text_.text = "Score: " + score;
    }
}
