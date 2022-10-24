using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchController : MonoBehaviour
{
    TouchScreenKeyboard keyboard;
    string text = "";
    public Text searchText;
    public GameObject Hint;
    public GameObject searchBack;
    public Text searchText2;
    public GameObject content;
    public Transform[] contentList = new Transform[8];
    public RectTransform scroll;
    public Animator searchTabAnim;
    FilterController filter;

    public GameObject recommend;
    public GameObject searchContent;
    public GameObject[] searchList;

    public GameObject[] end_Check;

    int contentnum = 0;

    string text2 = "";

    bool isSearch = false;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<FilterController>();

        for(int i=0; i < 9; i++)
        {
            if (PlayerPrefs.HasKey(i + "_end"))
            {
                if(PlayerPrefs.GetInt(i + "_end") == 1)
                {
                    end_Check[i].SetActive(true);
                }
                else
                {
                    end_Check[i].SetActive(false);
                }
            }
            else
            {
                end_Check[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        text2 = searchText.text;
#if UNITY_ANDROID
        //     searchText.text = keyboard.text;
#endif
        /////////////////////일단 오류나서 주석처리////////////////////////////////
        //if (searchText.text == "")
        //{
        //    //Hint.SetActive(true);
        //    searchBack.SetActive(false);
        //}
        //else
        //{
        //  //  Hint.SetActive(false);
        //    searchBack.SetActive(true);
        //}
        /////////////////////////////////////////////////////////////////////////////
        ///

        //#if UNITY_ANDROID
        //        if(keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
        //        {
        //            if(isSearch == true)
        //            {
        //               // TouchScreenKeyboard.hideInput = false;
        //                text = keyboard.text;
        //                searchText2.text = text;
        //                searchTabAnim.SetBool("isShow", false);
        //                SearchText(text);
        //                isSearch = false;
        //            }
        //        }
        //#endif
    }

    public void SearchList()
    {

        
        searchContent.SetActive(true);
        recommend.SetActive(false);
        print("text : " + text2);
        #region 검색어리스트
        if ("티라미수".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "초간단레시피" || text.Replace(" ", "") == "노오븐"
        || text.Replace(" ", "") == "마스카포네치즈" || text.Replace(" ", "") == "마스카포네" || text.Replace(" ", "") == "연유" || text.Replace(" ", "") == "레이디핑거쿠키"
        || text.Replace(" ", "") == "레이디핑거" || text.Replace(" ", "") == "인스턴트커피" || text.Replace(" ", "") == "따뜻한물"
        || text.Replace(" ", "") == "물" || text.Replace(" ", "") == "코코아파우더")
        {
            searchList[0].SetActive(true);
        }
        else
        {
            searchList[0].SetActive(false);
        }

        if ("아이스박스".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "케이크" || text.Replace(" ", "") == "오레오" || text.Replace(" ", "") == "노오븐"
        || text.Replace(" ", "") == "크림치즈" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "생크림")
        {
            searchList[1].SetActive(true);
        }
        else
        {
            searchList[1].SetActive(false);
        }

        if ("스모어딥".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "초코" || text.Replace(" ", "") == "오븐"
       || text.Replace(" ", "") == "마시멜로" || text.Replace(" ", "") == "누텔라" || text.Replace(" ", "") == "비스킷")
        {
            searchList[2].SetActive(true);
        }
        else
        {
            searchList[2].SetActive(false);
        }

        if ("바크초콜릿".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "발렌타인데이" || text.Replace(" ", "") == "초코" || text.Replace(" ", "") == "노오븐"
        || text.Replace(" ", "") == "화이트코팅초콜릿" || text.Replace(" ", "") == "초콜릿"
        || text.Replace(" ", "") == "동결건조딸기" || text.Replace(" ", "") == "딸기" || text.Replace(" ", "") == "오레오")
        {
            searchList[3].SetActive(true);
        }
        else
        {
            searchList[3].SetActive(false);
        }

        if ("퐁당오쇼콜라".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "초코" || text.Replace(" ", "") == "오븐"
        || text.Replace(" ", "") == "다크초콜릿" || text.Replace(" ", "") == "초콜릿" || text.Replace(" ", "") == "무염버터"
        || text.Replace(" ", "") == "계란" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "바닐라익스트랙"
        || text.Replace(" ", "") == "박력분" || text.Replace(" ", "") == "코코아파우더" || text.Replace(" ", "") == "슈가파우더")
        {
            searchList[4].SetActive(true);
        }
        else
        {
            searchList[4].SetActive(false);
        }

        if ("딸기모찌".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "찹쌀떡" || text.Replace(" ", "") == "노오븐" || text.Replace(" ", "") == "전자레인지"
        || text.Replace(" ", "") == "딸기" || text.Replace(" ", "") == "앙금" || text.Replace(" ", "") == "찹쌀가루"
        || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "소금" || text.Replace(" ", "") == "뜨거운물" || text.Replace(" ", "") == "물" || text.Replace(" ", "") == "전분")
        {
            searchList[5].SetActive(true);
        }
        else
        {
            searchList[5].SetActive(false);
        }

        if ("구름빵".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "머랭" || text.Replace(" ", "") == "오븐"
       || text.Replace(" ", "") == "계란" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "옥수수전분")
        {
            searchList[6].SetActive(true);
        }
        else
        {
            searchList[6].SetActive(false);
        }

        if ("커스터드푸딩".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "전자레인지" || text.Replace(" ", "") == "노오븐"
        || text.Replace(" ", "") == "계란" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "물"
        || text.Replace(" ", "") == "바닐라오일" || text.Replace(" ", "") == "우유")
        {
            searchList[7].SetActive(true);
        }
        else
        {
            searchList[7].SetActive(false);
        }

        if ("초코칩쿠키".Contains(text2.Replace(" ", "")) || text.Replace(" ", "") == "오븐" || text.Replace(" ", "") == "버터"
        || text.Replace(" ", "") == "박력분" || text.Replace(" ", "") == "흑설탕" || text.Replace(" ", "") == "계란"
        || text.Replace(" ", "") == "바닐라익스트랙" || text.Replace(" ", "") == "베이킹소다" || text.Replace(" ", "") == "소금" || text.Replace(" ", "") == "초코칩")
        {
            searchList[8].SetActive(true);
        }
        else
        {
            searchList[8].SetActive(false);
        }
        #endregion
    }

    public void SearchItem()
    {
      //  if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
       // {
            text = searchText.text;
            searchText2.text = text;
            searchTabAnim.SetBool("isShow", false);
            SearchText(text);
            isSearch = false;
     //   }
        //else
        //{
        //    searchText2.text = "";
        //    searchText.text = "";
        //}
    }

    public void Search()
    {
        scroll.anchoredPosition = new Vector2(0, 0);
#if UNITY_ANDROID
        keyboard = TouchScreenKeyboard.Open(text, TouchScreenKeyboardType.Default);
        keyboard.text = "";
#endif
        isSearch = true;
        //TouchScreenKeyboard.hideInput = true;
    }

    public void ShowTab()
    {
        searchTabAnim.SetBool("isShow", true);
        searchContent.SetActive(false);
        recommend.SetActive(true);
#if UNITY_ANDROID
        // keyboard.text = "";
#endif
        //searchText.text = "";
        //searchText2.text = "";
    }

    public void Cancel()
    {
        isSearch = false;
        searchTabAnim.SetBool("isShow", false);
        SearchText("");
        searchText.text = "";
        searchText2.text = "";
        keyboard.text = "";
    }

    //private void OnGUI()
    //{
    //    TouchScreenKeyboard.hideInput = true;
    //}

#region 검색 함수
    public void SearchText(string text)
    {
        isSearch = false;
        contentnum = 0;
        for(int i = 0; i<9; i++)
        {
            contentList[i].gameObject.SetActive(false);
        }

        if ("티라미수".Contains(text.Replace(" ","")) || text.Replace(" ", "") == "초간단레시피" || text.Replace(" ", "") == "노오븐" 
            || text.Replace(" ", "") == "마스카포네치즈" || text.Replace(" ", "") == "마스카포네" || text.Replace(" ", "") == "연유" || text.Replace(" ", "") == "레이디핑거쿠키"
            || text.Replace(" ", "") == "레이디핑거" || text.Replace(" ", "") == "인스턴트커피" || text.Replace(" ", "") == "따뜻한물"
            || text.Replace(" ", "") == "물" || text.Replace(" ", "") == "코코아파우더")
        {
            if ((filter.isDftyAll || filter.isDftyLow) && (filter.isToolAll) && filter.runTime >= 10)
            {
                contentList[0].gameObject.SetActive(true);
                contentnum++;
            }

        }
        if ("아이스박스".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "케이크" || text.Replace(" ", "") == "오레오" || text.Replace(" ", "") == "노오븐"
            || text.Replace(" ", "") == "크림치즈" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "생크림")
        {
            if ((filter.isDftyAll || filter.isDftyLow) && (filter.isToolAll) && filter.runTime >= 60)
            {
                contentList[1].gameObject.SetActive(true);
                contentnum++;
            }
                
        }
        if ("스모어딥".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "초코" || text.Replace(" ", "") == "오븐"
            || text.Replace(" ", "") == "마시멜로" || text.Replace(" ", "") == "누텔라" || text.Replace(" ", "") == "비스킷")
        {
            if ((filter.isDftyAll || filter.isDftyLow) && (filter.isToolAll || filter.isToolOven) && filter.runTime >= 15)
            {
                contentList[2].gameObject.SetActive(true);
                contentnum++;
            }
               
        }
        if ("바크초콜릿".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "발렌타인데이" || text.Replace(" ", "") == "초코" || text.Replace(" ", "") == "노오븐"
            || text.Replace(" ", "") == "화이트코팅초콜릿" || text.Replace(" ", "") == "초콜릿" 
            || text.Replace(" ", "") == "동결건조딸기" || text.Replace(" ", "") == "딸기" || text.Replace(" ", "") == "오레오")
        {
            if ((filter.isDftyAll || filter.isDftyLow) && (filter.isToolAll) && filter.runTime >= 25)
            {
                contentList[3].gameObject.SetActive(true);
                contentnum++;
            }
        }
        if ("퐁당오쇼콜라".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "초코" || text.Replace(" ", "") == "오븐"
            || text.Replace(" ", "") == "다크초콜릿" || text.Replace(" ", "") == "초콜릿" || text.Replace(" ", "") == "무염버터" 
            || text.Replace(" ", "") == "계란" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "바닐라익스트랙" 
            || text.Replace(" ", "") == "박력분" || text.Replace(" ", "") == "코코아파우더" || text.Replace(" ", "") == "슈가파우더")
        {

            if ((filter.isDftyAll || filter.isDftyNormal) && (filter.isToolAll || filter.isToolOven) && filter.runTime >= 60)
            {
                contentList[4].gameObject.SetActive(true);
                contentnum++;
            }
        }
        if ("딸기모찌".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "찹쌀떡" || text.Replace(" ", "") == "노오븐" || text.Replace(" ", "") == "전자레인지"
            || text.Replace(" ", "") == "딸기" || text.Replace(" ", "") == "앙금" || text.Replace(" ", "") == "찹쌀가루"
            || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "소금" || text.Replace(" ", "") == "뜨거운물" || text.Replace(" ", "") == "물" || text.Replace(" ", "") == "전분")
        {
            if ((filter.isDftyAll || filter.isDftyNormal) && (filter.isToolAll || filter.isToolMicrowave) && filter.runTime >= 30)
            {
                contentList[5].gameObject.SetActive(true);
                contentnum++;
            }
        }
        if ("구름빵".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "머랭" || text.Replace(" ", "") == "오븐"
            || text.Replace(" ", "") == "계란" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "옥수수전분")
        {
            if ((filter.isDftyAll || filter.isDftyNormal) && (filter.isToolAll || filter.isToolOven) && filter.runTime >= 45)
            {
                contentList[6].gameObject.SetActive(true);
                contentnum++;
            }
        }
        if ("커스터드푸딩".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "전자레인지" || text.Replace(" ", "") == "노오븐"
            || text.Replace(" ", "") == "계란" || text.Replace(" ", "") == "설탕" || text.Replace(" ", "") == "물"
            || text.Replace(" ", "") == "바닐라오일" || text.Replace(" ", "") == "우유")
        {
            if ((filter.isDftyAll || filter.isDftyNormal) && (filter.isToolAll || filter.isToolMicrowave) && filter.runTime >= 20)
            {
                contentList[7].gameObject.SetActive(true);
                contentnum++;
            }
        }
        if ("초코칩쿠키".Contains(text.Replace(" ", "")) || text.Replace(" ", "") == "오븐" || text.Replace(" ", "") == "버터"
            || text.Replace(" ", "") == "박력분" || text.Replace(" ", "") == "흑설탕" || text.Replace(" ", "") == "계란"
            || text.Replace(" ", "") == "바닐라익스트랙" || text.Replace(" ", "") == "베이킹소다" || text.Replace(" ", "") == "소금" || text.Replace(" ", "") == "초코칩")
        {
            if ((filter.isDftyAll || filter.isDftyHigh) && (filter.isToolAll || filter.isToolOven) && filter.runTime >= 60)
            {
                contentList[8].gameObject.SetActive(true);
                contentnum++;
            }
        }

        if (contentnum <= 5)
        {
            scroll.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
        }
        else
        {
            scroll.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2309);
        }
    }
#endregion


#region 검색어 추천
    public void Rcmd_Cake()
    {
        searchText2.text = "케이크";
        searchText.text = "케이크";
        searchTabAnim.SetBool("isShow", false);
        SearchText("케이크");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }

    public void Rcmd_Cookie()
    {
        searchText2.text = "쿠키";
        searchText.text = "쿠키";
        searchTabAnim.SetBool("isShow", false);
        SearchText("쿠키");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }

    public void Rcmd_Pudding()
    {
        searchText.text = "푸딩";
        searchText2.text = "푸딩";
        searchTabAnim.SetBool("isShow", false);
        SearchText("푸딩");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }

    public void Rcmd_Tiramisu()
    {
        searchText.text = "티라미수";
        searchText2.text = "티라미수";
        searchTabAnim.SetBool("isShow", false);
        SearchText("티라미수");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }

    public void Rcmd_Cheese()
    {
        searchText.text = "크림치즈";
        searchText2.text = "크림치즈";
        searchTabAnim.SetBool("isShow", false);
        SearchText("크림치즈");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }

    public void Rcmd_Chocolate()
    {
        searchText2.text = "초콜릿";
        searchTabAnim.SetBool("isShow", false);
        SearchText("초콜릿");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }

    public void Rcmd_Cream()
    {
        searchText.text = "생크림";
        searchText2.text = "생크림";
        searchTabAnim.SetBool("isShow", false);
        SearchText("생크림");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }

    public void Rcmd_Oreo()
    {
        searchText.text = "오레오";
        searchText2.text = "오레오";
        searchTabAnim.SetBool("isShow", false);
        SearchText("오레오");
        isSearch = false;
        Hint.SetActive(false);
        searchBack.SetActive(true);
    }
#endregion

    public void AutoSearch(string stext)
    {
        searchText2.text = stext;
        searchTabAnim.SetBool("isShow", false);
        SearchText(stext);
        isSearch = false;
    }
}
