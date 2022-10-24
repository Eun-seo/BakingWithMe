using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPageController : MonoBehaviour
{
    string state = "";
    public RectTransform SelectBar;
    public RectTransform Content;
    public Animator anim;

    public Button ClipBtn;
    public Button IngredientBtn;

    public GameObject back;
    public GameObject back_I;

    public int clipNum = 0;
    public int clipNum_I = 0;

    public Transform[] ChildrenObj;
    public Transform[] ChildrenObj_I;

    private void Awake()
    { 

        state = GameObject.Find("DataSave").GetComponent<RecipeCodeSaver>().getMyPage();
        if (state == "Clip")
        {
            print("찜한레시피 화면");
            SelectBar.anchoredPosition = new Vector2(0, 0);
            Content.anchoredPosition = new Vector2(0, -661);
            ClipBtn.interactable = false;
        }
        else if (state == "Ingredient")
        {
            print("재료리스트 화면");
            SelectBar.anchoredPosition = new Vector2(398.2f,0);
            Content.anchoredPosition = new Vector2(-796, -661);
            IngredientBtn.interactable = false;
        }
        else
        {
            print("마이페이지 오류");
        }
    }

    public void ToClip()
    {
        anim.enabled = true;
        anim.SetInteger("State", -1);

        IngredientBtn.interactable = true;
        ClipBtn.interactable = false;
    }

    public void ToIngredient()
    {
        anim.enabled = true;
        anim.SetInteger("State", 1);
        
        IngredientBtn.interactable = false;
        ClipBtn.interactable = true;
    }

    private void Update()
    {
        if(clipNum <= 0)
        {
            back.SetActive(true);
        }
        else
        {
            back.SetActive(false);
        }

        if (clipNum_I <= 0)
        {
            back_I.SetActive(true);
        }
        else
        {
            back_I.SetActive(false);
        }
    }

    public void Count()
    {
        clipNum = 0;
        for (int i = 0; i < ChildrenObj.Length; i++)
        {
            if (ChildrenObj[i].gameObject.activeSelf)
            {
                clipNum++;
            }
        }
    }

    public void Count_I()
    {
        clipNum_I = 0;
        for (int i = 0; i < ChildrenObj_I.Length; i++)
        {
            if (ChildrenObj_I[i].gameObject.activeSelf)
            {
                print(clipNum_I);
                clipNum_I++;
            }
        }
    }
}
