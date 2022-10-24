using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupGuide : MonoBehaviour
{
    public RectTransform line;
    public Text lineText;

    bool isShow;

    private float yVelocity = 2.0f;
    private float xVelocity = 2.0f;

    float measure;

    void Start()
    {
        
    }


    void Update()
    {
        if (isShow)
        {
            line.gameObject.SetActive(true);
            float newPositionX = Mathf.SmoothDamp(line.anchoredPosition.x, 0, ref xVelocity, 0.1f);
            float newPositionY = Mathf.SmoothDamp(line.anchoredPosition.y, -371 + (126.86f * (measure % 10)), ref yVelocity, 0.1f);
            line.anchoredPosition = new Vector2(newPositionX, newPositionY);
        }
        else
        {
            line.gameObject.SetActive(false);
        }
    }

    public void MoveLine(float m)
    {
        measure = m;
        
        lineText.text = ((int)(measure) / 10).ToString() + "g";
        line.anchoredPosition = new Vector2(0, -371);

        isShow = true;
    }
}
