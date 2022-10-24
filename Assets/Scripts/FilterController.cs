using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterController : MonoBehaviour
{
    public Animator FilterAnim;
    public Button exceptRecipe;
    public Button DftyAll;
    public Button DftyLow;
    public Button DftyNormal;
    public Button DftyHigh;
    public Button ToolAll;
    public Button ToolOven;
    public Button ToolMicrowave;

    public Text searchText;

    public Slider runTimeSlider;

    public bool isExcept = false;
    public bool isDftyAll = true;
    public bool isDftyLow = false;
    public bool isDftyNormal = false;
    public bool isDftyHigh = false;
    public bool isToolAll = true;
    public bool isToolOven = false;
    public bool isToolMicrowave = false;

    public int runTime = 60;

    public Sprite[] unselected = new Sprite[8];
    public Sprite[] selected = new Sprite[8];

    SearchController SearchCtrl;


    // Start is called before the first frame update
    void Start()
    {
        isExcept = false;
        isDftyAll = true;
        isDftyLow = false;
        isDftyNormal = false;
        isDftyHigh = false;
        isToolAll = true;
        isToolOven = false;
        isToolMicrowave = false;
        runTime = 60;

        SearchCtrl = GetComponent<SearchController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowFilter()
    {
        FilterAnim.SetBool("isShow", true);
    }

    public void HideFilter()
    {
        FilterAnim.SetBool("isShow", false);
    }

    public void ExceptRecipe()
    {
        if (isExcept)
        {
            exceptRecipe.image.sprite = unselected[0];
            isExcept = false;
        }
        else
        {
            exceptRecipe.image.sprite = selected[0];
            isExcept = true;
        }
    }

    public void DifficultyAll()
    {
        if (isDftyAll)
        {
            //DftyAll.image.sprite = unselected[1];
            //isDftyAll = false;
        }
        else
        {
            DftyAll.image.sprite = selected[1];
            DftyHigh.image.sprite = unselected[2];
            DftyNormal.image.sprite = unselected[3];
            DftyLow.image.sprite = unselected[4];
            isDftyAll = true;
            isDftyHigh = false;
            isDftyNormal = false;
            isDftyLow = false;
        }
    }

    public void DifficultyHigh()
    {
        if (isDftyHigh)
        {
            DftyHigh.image.sprite = unselected[2];
            isDftyHigh = false;
        }
        else
        {
            if (isDftyNormal && isDftyLow)
            {
                DftyNormal.image.sprite = unselected[3];
                DftyAll.image.sprite = selected[1];
                DftyHigh.image.sprite = unselected[2];
                DftyLow.image.sprite = unselected[4];

                isDftyAll = true;
                isDftyNormal = false;
                isDftyHigh = false;
                isDftyLow = false;
            }
            else
            {
                DftyHigh.image.sprite = selected[2];
                DftyAll.image.sprite = unselected[1];
                isDftyAll = false;
                isDftyHigh = true;
            }

        }
    }

    public void DifficultyNormal()
    {
        if (isDftyNormal)
        {
            DftyNormal.image.sprite = unselected[3];
            isDftyNormal = false;
        }
        else
        {
            if (isDftyHigh && isDftyLow)
            {
                DftyNormal.image.sprite = unselected[3];
                DftyAll.image.sprite = selected[1];
                DftyHigh.image.sprite = unselected[2];
                DftyLow.image.sprite = unselected[4];

                isDftyAll = true;
                isDftyNormal = false;
                isDftyHigh = false;
                isDftyLow = false;
            }
            else
            {
                DftyNormal.image.sprite = selected[3];
                DftyAll.image.sprite = unselected[1];
                isDftyAll = false;
                isDftyNormal = true;
            }
        }
    }

    public void DifficultyLow()
    {
        if (isDftyLow)
        {
            DftyLow.image.sprite = unselected[4];
            isDftyLow = false;
        }
        else
        {
            if (isDftyNormal && isDftyHigh)
            {
                DftyNormal.image.sprite = unselected[3];
                DftyAll.image.sprite = selected[1];
                DftyHigh.image.sprite = unselected[2];
                DftyLow.image.sprite = unselected[4];

                isDftyAll = true;
                isDftyNormal = false;
                isDftyHigh = false;
                isDftyLow = false;
            }
            else
            {
                DftyLow.image.sprite = selected[4];
                DftyAll.image.sprite = unselected[1];
                isDftyAll = false;
                isDftyLow = true;
            }

        }
    }

    public void Tool_All()
    {
        if (isToolAll)
        {
            //ToolAll.image.sprite = unselected[5];
            //isToolAll = false;
        }
        else
        {
            ToolAll.image.sprite = selected[5];
            ToolOven.image.sprite = unselected[6];
            ToolMicrowave.image.sprite = unselected[7];
            isToolAll = true;
            isToolOven = false;
            isToolMicrowave = false;
        }
    }

    public void Tool_Oven()
    {
        if (isToolOven)
        {
            ToolOven.image.sprite = unselected[6];
            isToolOven = false;
        }
        else
        {
            if (isToolMicrowave)
            {
                ToolAll.image.sprite = selected[5];
                ToolOven.image.sprite = unselected[6];
                ToolMicrowave.image.sprite = unselected[7];
                isToolAll = true;
                isToolOven = false;
                isToolMicrowave = false;
            }
            else
            {
                ToolAll.image.sprite = unselected[5];
                ToolOven.image.sprite = selected[6];
                isToolAll = false;
                isToolOven = true;
            }

        }
    }

    public void Tool_Microwave()
    {
        if (isToolMicrowave)
        {
            ToolMicrowave.image.sprite = unselected[7];
            isToolMicrowave = false;
        }
        else
        {
            if (isToolOven)
            {
                ToolAll.image.sprite = selected[5];
                ToolOven.image.sprite = unselected[6];
                ToolMicrowave.image.sprite = unselected[7];
                isToolAll = true;
                isToolOven = false;
                isToolMicrowave = false;
            }
            else
            {
                ToolAll.image.sprite = unselected[5];
                ToolMicrowave.image.sprite = selected[7];
                isToolAll = false;
                isToolMicrowave = true;
            }

        }
    }

    public void Cancel()
    {
        isExcept = false;
        exceptRecipe.image.sprite = unselected[0];

        isDftyAll = true;
        DftyAll.image.sprite = selected[1];

        isDftyLow = false;
        DftyLow.image.sprite = unselected[4];

        isDftyNormal = false;
        DftyNormal.image.sprite = unselected[3];

        isDftyHigh = false;
        DftyHigh.image.sprite = unselected[2];

        isToolAll = true;
        ToolAll.image.sprite = selected[5];

        isToolOven = false;
        ToolOven.image.sprite = unselected[6];

        isToolMicrowave = false;
        ToolMicrowave.image.sprite = unselected[7];

        runTimeSlider.value = 1;
        runTime = (int)(runTimeSlider.value * 50 + 10);

        SearchCtrl.SearchText(searchText.text);
    }

    public void Apply()
    {
        runTime = (int)(runTimeSlider.value * 50 + 10);
        SearchCtrl.SearchText(searchText.text);
    }

    public void Slider()
    {
        float num = (runTimeSlider.value * 10) % 2;
        if (num <= 1)
        {
            runTimeSlider.value -= num/10.0f;
        }
        else
        {
            runTimeSlider.value += num/10.0f - 0.1f;
        }
    }
}
