using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupGuideController : MonoBehaviour
{
    public GameObject[] Recipes;
    public Animator cupAnim;
    public Text unit;

    public RectTransform line;
    public Text lineUnit;

    public GameObject cupImage_full;
    public GameObject cupImage;

    public Sprite[] cups;

    public GameObject cup;
    public GameObject teaspoon;
    public GameObject teaspoonIcon;

    float[,] cupMeasure = new float[9,8];
    string[,] actualMeasure = new string[9, 8];
    int recipeNum;

    bool isShow = false;
    float measure = 0;

    private float yVelocity = 2.0f;
    private float xVelocity = 2.0f;

    void Start()
    {
        for(int i = 0; i<8; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                cupMeasure[i, j] = 0;
                actualMeasure[i, j] = "";
            }
        }

        cupMeasure[0, 0] = 3;
        cupMeasure[0, 1] = 1.5f;
        cupMeasure[0, 2] = 1;
        cupMeasure[1, 0] = 2;
        cupMeasure[1, 1] = 12f;
        cupMeasure[4, 0] = 2.5f;
        cupMeasure[4, 1] = 1.5f;
        cupMeasure[4, 2] = 1;
        cupMeasure[4, 3] = 4;
        cupMeasure[4, 4] = 2.5f;
        cupMeasure[5, 0] = 13.5f;
        cupMeasure[5, 1] = 15;
        cupMeasure[5, 2] = 1;
        cupMeasure[5, 3] = 0;
        cupMeasure[5, 4] = 12;
        cupMeasure[6, 0] = 1.5f;
        cupMeasure[6, 1] = 1;
        cupMeasure[7, 0] = 3;
        cupMeasure[7, 1] = 1;
        cupMeasure[7, 2] = 6;
        cupMeasure[8, 0] = 5;
        cupMeasure[8, 1] = 23;
        cupMeasure[8, 2] = 5.5f;
        cupMeasure[8, 3] = 1;
        cupMeasure[8, 4] = 0;
        cupMeasure[8, 5] = 0;
        cupMeasure[8, 6] = 14.5f;

        actualMeasure[0, 0] = "75g";
        actualMeasure[0, 1] = "4g";
        actualMeasure[0, 2] = "24ml";
        actualMeasure[1, 0] = "40g";
        actualMeasure[1, 1] = "220g";
        actualMeasure[4, 0] = "50g";
        actualMeasure[4, 1] = "20g";
        actualMeasure[4, 2] = "4ml";
        actualMeasure[4, 3] = "50g";
        actualMeasure[4, 4] = "15g";
        actualMeasure[5, 0] = "300g";
        actualMeasure[5, 1] = "200g";
        actualMeasure[5, 2] = "20g";
        actualMeasure[5, 3] = "1g";
        actualMeasure[5, 4] = "200ml";
        actualMeasure[6, 0] = "30g";
        actualMeasure[6, 1] = "10g";
        actualMeasure[7, 0] = "60g";
        actualMeasure[7, 1] = "15ml";
        actualMeasure[7, 2] = "150ml";
        actualMeasure[8, 0] = "110g";
        actualMeasure[8, 1] = "220g";
        actualMeasure[8, 2] = "110g";
        actualMeasure[8, 3] = "5ml";
        actualMeasure[8, 4] = "2g";
        actualMeasure[8, 5] = "1g";
        actualMeasure[8, 6] = "200g";
    }

    
    void Update()
    {
        if (isShow)
        {
            line.gameObject.SetActive(true);
            float newPositionX = Mathf.SmoothDamp(line.anchoredPosition.x, 0, ref xVelocity, 0.1f);
            float newPositionY = Mathf.SmoothDamp(line.anchoredPosition.y, -1046 + (143.86f * (measure % 10)), ref yVelocity, 0.1f);
            line.anchoredPosition = new Vector2(newPositionX, newPositionY);
            //line.anchoredPosition = Vector2.Lerp(new Vector2(0, -967),new Vector2(0,-967 + (161.33f * (measure % 10))),0.1f );
        }
        else
        {
            line.gameObject.SetActive(false);
        }
    }

    public void LoadImage(int rNum)
    {
        unit.text = "";
        cup.SetActive(true);
        teaspoon.SetActive(false);
        teaspoonIcon.SetActive(false);

        cupImage.SetActive(false);
        cupImage_full.SetActive(false);
        isShow = false;
        cupAnim.SetBool("isShow", true);
        recipeNum = rNum;

        for (int i = 0; i< 9; i++)
        {
            Recipes[i].SetActive(false);
        }
        //if(rNum == 8)
        //{
        //    unit.GetComponent<RectTransform>().anchoredPosition = new Vector2(-234, 251);
        //}
        //else
        //{
        //    unit.GetComponent<RectTransform>().anchoredPosition = new Vector2(-234, 299.7f);
        //}

        Recipes[rNum].SetActive(true);
    }

    public void GetIngredient(int iNum)
    {
        lineUnit.text = actualMeasure[recipeNum, iNum];
        unit.text = "";
        if ((recipeNum == 8 && (iNum == 4 || iNum == 5)) || (recipeNum == 5 && iNum == 3))
        {
            isShow = false;
            cup.SetActive(false);
            teaspoon.SetActive(true);
            teaspoonIcon.SetActive(true);

            cupImage.SetActive(false);
            cupImage_full.SetActive(false);
            line.gameObject.SetActive(false);

            //if(recipeNum == 8)
            //{
            //    teaspoonIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-105,241);
            //}
            //else
            //{
            //    teaspoonIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-105, 292);
            //}

            unit.text = "1 / 2 티스푼";
        }
        else
        {
            line.gameObject.SetActive(true);
            cup.SetActive(true);
            teaspoon.SetActive(false);
            teaspoonIcon.SetActive(false);

            measure = cupMeasure[recipeNum, iNum];
            
            line.anchoredPosition = new Vector2(0, -1046);
            float cupPosition = -341.9f;

            cupImage.SetActive(true);
            cupImage_full.SetActive(false);

            cupImage.GetComponent<Image>().sprite = cups[(int)(measure % 10 - 1)];
            if (measure != (int)measure)
            {
                cupPosition += 45;
            }
            if (measure > 10)
            {
                unit.text = "1 컵 + ";
                cupImage_full.SetActive(true);
                cupPosition += 149;

                cupImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition + 55.9f, 173);
                cupImage_full.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition, 173);

                //if (recipeNum == 8)
                //{
                //    cupImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition + 95, 243);
                //    cupImage_full.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition, 243);
                //}
                //else
                //{
                //    cupImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition + 95, 294);
                //    cupImage_full.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition, 294);
                //}
                
            }
            else
            {
                cupImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition, 173);

                //if (recipeNum == 8)
                //{
                //    cupImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition, 243);
                //}
                //else
                //{
                //    cupImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(cupPosition, 294);
                //}
                
            }



            unit.text += (measure % 10) + " / 7 컵";

            isShow = true;
        }
        

        
    }

    public void Cancel()
    {
        cupAnim.SetBool("isShow", false);
        print("/" + GetRecipeName(recipeNum) + "/Ing");
    }

    #region 레시피 이름 함수
    string GetRecipeName(int recipeNum)
    {
        switch (recipeNum)
        {
            case 0:
                return "Tiramisu";
            case 1:
                return "Icebox";
            case 2:
                return "Smore";
            case 3:
                return "Bark";
            case 4:
                return "Pongdang";
            case 5:
                return "Strawberry";
            case 6:
                return "Cloud";
            case 7:
                return "Pudding";
            case 8:
                return "Cookie";
            default:
                return "[error]";
        }
    }
    #endregion
}
