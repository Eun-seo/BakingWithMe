using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngridientController : MonoBehaviour
{
    RecipeCodeSaver Codesaver;
    public GameObject parent;
    Transform[] childObj;
    string result = "";
    string rname = "";

    public List<GameObject> RecipeList;
    public Animator anim;
    public Animator contentAnim;

    public Image detail;
    public Sprite[] details = new Sprite[9];

    int length_i = 0;
    string savedResult = "";

    MyPageController mpc;

    public CupGuideController cgc;

    // Start is called before the first frame update
    void Start()
    {
        mpc = GameObject.Find("MyPageController").GetComponent<MyPageController>();
        childObj = parent.transform.GetComponentsInChildren<Transform>();
        Codesaver = GameObject.Find("DataSave").GetComponent<RecipeCodeSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Apply()
    {
        result = "";
        for(int i=1; i< length_i+1; i++)
        {
            if (childObj[i].gameObject.activeSelf)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
        }

        PlayerPrefs.SetString(rname + "_I", result);
        //contentAnim.SetBool("isDetail", false);
    }

    public void Delete(string r_name)
    {
        rname = r_name;
        anim.SetBool("isShow", true);
    }

    public void DeleteOK()
    {
        PlayerPrefs.SetString(rname + "_I", "false");
        RecipeList[GetRecipeNum(rname)].SetActive(false);
        anim.SetBool("isShow", false);
        anim.SetTrigger("ShowNotice");
        mpc.Count_I();
    }

    public void Cancel()
    {
        rname = "";
        anim.SetBool("isShow", false);
    }

    public void ShowDetail(string r_name)
    {
        contentAnim.enabled = true;
        contentAnim.SetBool("isDetail", true);
        rname = r_name;
        detail.sprite = details[GetRecipeNum(r_name)];
        length_i = GetLength(r_name);



        if(r_name == "Tiramisu")
        {
            childObj[2].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 288.9f);
            childObj[3].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 196.9f);
            childObj[4].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 92.8f);
            childObj[5].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -11.6f);
            childObj[6].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -102.7f);

            childObj[10].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 288.9f);
            childObj[11].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 196.9f);
            childObj[12].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 92.8f);
            childObj[13].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -11.6f);
            childObj[14].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -102.7f);
        }
        else if(r_name == "Pudding")
        {
            childObj[5].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 17.06f);
            childObj[13].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 17.06f);
        }
        else
        {
            childObj[1].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 394);
            childObj[2].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 302.7f);
            childObj[3].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 211.4f);
            childObj[4].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 120.1f);
            childObj[5].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 30.5f);
            childObj[6].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -61);
            childObj[7].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -150.6f);
            childObj[8].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -242.2f);

            childObj[9].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 394);
            childObj[10].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 302.7f);
            childObj[11].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 211.4f);
            childObj[12].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 120.1f);
            childObj[13].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, 30.5f);
            childObj[14].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -61);
            childObj[15].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -150.6f);
            childObj[16].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-282.7f, -242.2f);
        }

        for (int i = 1; i < 17; i++)
        {
            childObj[i].gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetString(r_name + "_I") == "true")
        {
            //버튼 오브젝트 재료 갯수 맞춰 활성화
            for(int i = 9; i<length_i + 9; i++)
            {
                print("length = " + i);
                childObj[i].gameObject.SetActive(true);
            }
            for (int i = length_i+9; i < 17; i++)
            {
                childObj[i].gameObject.SetActive(false);
            }

        }
        else if (PlayerPrefs.GetString(r_name + "_I") == "false" || !PlayerPrefs.HasKey(r_name + "_I"))
        {
            print("playerPrefs 데이터 없음 리스트 로드 오류");
        }
        else
        {
            savedResult = PlayerPrefs.GetString(r_name + "_I");
            print("result : " + savedResult);

            //버튼 오브젝트 재료 갯수 맞춰 활성화
            for (int i = 9; i < length_i + 9; i++)
            {
                print("length = " + i);
                childObj[i].gameObject.SetActive(true);
            }
            for (int i = length_i + 9; i < 17; i++)
            {
                childObj[i].gameObject.SetActive(false);
            }

            for (int i = 1; i < length_i + 1; i++)
            {
                if (savedResult[i-1].Equals('0'))
                {
                    childObj[i].gameObject.SetActive(false);
                }
                else if (savedResult[i-1].Equals('1'))
                {
                    childObj[i].gameObject.SetActive(true);
                }
                else
                {
                    print("재료리스트 불러오기 오류, result : " + savedResult);
                    print("result " + (i-1) + " = " + savedResult[i-1]);
                }
            }
        }

        
    }

    public void CupGuide()
    {
        cgc.LoadImage(GetRecipeNum(rname));
    }

    public void GoDetail()
    {
        Codesaver.SetCode(GetRecipeNum(rname));
        SceneManager.LoadScene("DetailScene");
    }

    public void HideDetail()
    {
        contentAnim.SetBool("isDetail", false);
    }

    int GetRecipeNum(string r_name)
    {
        switch (r_name)
        {
            case "Tiramisu":
                return 0;
            case "Icebox":
                return 1;
            case "Smore":
                return 2;
            case "Bark":
                return 3;
            case "Pongdang":
                return 4;
            case "Strawberry":
                return 5;
            case "Cloud":
                return 6;
            case "Pudding":
                return 7;
            case "Cookie":
                return 8;
            default:
                return 100;
        }
    }

    int GetLength(string r_name)
    {
        switch (r_name)
        {
            case "Tiramisu":
                return 6;
            case "Icebox":
                return 4;
            case "Smore":
                return 3;
            case "Bark":
                return 3;
            case "Pongdang":
                return 8;
            case "Strawberry":
                return 7;
            case "Cloud":
                return 3;
            case "Pudding":
                return 5;
            case "Cookie":
                return 8;
            default:
                return 100;
        }
    }

    public void OnOff(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
    }
}
