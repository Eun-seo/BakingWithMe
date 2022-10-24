using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailStepController : MonoBehaviour
{
    int step = 0;
    public Image stepImage;
    public Button LeftBtn;
    public Button RightBtn;

    // Start is called before the first frame update
    void Start()
    {
        LeftBtn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToLeft(string rname)
    {
        print("step : " + step);
        if (step > 0)
        {
            step--;
        }
        string path = "Image/" + rname + "/" + step;
        stepImage.sprite = Resources.Load<Sprite>(path);

        if (step == 0)
        {
            LeftBtn.interactable = false;
        }
        else
        {
            LeftBtn.interactable = true;
        }

        if(step < GetLength(rname))
        {
            RightBtn.interactable = true;
        }
    }

    public void ToRight(string rname)
    {
        print("To Right");
        int length = GetLength(rname);
        print("length : " + length);
        if (step < length - 1)
        {
            step++;
        }

        print("step : " + step);
        string path = "Image/" + rname + "/" + step;
        print("path : " + path);
        stepImage.sprite = Resources.Load<Sprite>(path);

        if(step > 0)
        {
            LeftBtn.interactable = true;
        }

        if(step == length - 1)
        {
            RightBtn.interactable = false;
        }
        else
        {
            RightBtn.interactable = true;
        }

    }

    int GetLength(string rname)
    {
        switch (rname)
        {
            case "Tiramisu":
                return 10;
            case "Icebox":
                return 7;
            case "Smore":
                return 5;
            case "Bark":
                return 13;
            case "Pongdang":
                return 13;
            case "Strawberry":
                return 12;
            case "Cloud":
                return 8;
            case "Pudding":
                return 9;
            case "Cookie":
                return 10;
            default:
                return 0;
        }
    }
}
