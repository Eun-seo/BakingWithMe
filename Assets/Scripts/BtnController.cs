using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class BtnController : MonoBehaviour
{
    RecipeCodeSaver Codesaver;
    public Animator MenuAnim;
    public Animator NoticeAnim;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private void Start()
    {
        Codesaver = GameObject.Find("DataSave").GetComponent<RecipeCodeSaver>();
       // XRSettings.enabled = false;
        //Screen.orientation = ScreenOrientation.Portrait;
    }

    public void ChooseRecipe1()
    {
        print("실행");
        Codesaver.SetCode(0);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe2()
    {
        print("실행");
        Codesaver.SetCode(1);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe3()
    {
        print("실행");
        Codesaver.SetCode(2);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe4()
    {
        print("실행");
        Codesaver.SetCode(3);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe5()
    {
        print("실행");
        Codesaver.SetCode(4);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe6()
    {
        Codesaver.SetCode(5);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe7()
    {
        Codesaver.SetCode(6);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe8()
    {
        Codesaver.SetCode(7);
        SceneManager.LoadScene("DetailScene");
    }

    public void ChooseRecipe9()
    {
        Codesaver.SetCode(8);
        SceneManager.LoadScene("DetailScene");
    }

    public void GoMR()
    {
      //  XRSettings.LoadDeviceByName("CardBoard");
       // XRSettings.enabled = true;
        SceneManager.LoadScene("MR_AR");
        
    }

    public void goList()
    {
        SceneManager.LoadScene("ListScene");
    }

    public void ShowMenu()
    {
        MenuAnim.SetBool("isShow", true);
    }

    public void HideMenu()
    {
        MenuAnim.SetBool("isShow", false);
    }

    public void GoClip()
    {
        Debug.Log("실행?");
        Codesaver.SetMyPage("Clip");
        SceneManager.LoadScene("MyPage01");
    }

    public void GoIngredient()
    {
        Debug.Log("실행?");
        Codesaver.SetMyPage("Ingredient");
        Debug.Log("listview mypage : " + Codesaver.getMyPage());
        SceneManager.LoadScene("MyPage01");
    }

    public void AddIngredient(string r_name)
    {
        NoticeAnim.SetTrigger("ShowNotice");
        if(!PlayerPrefs.HasKey(r_name + "_I") || PlayerPrefs.GetString(r_name + "_I") == "false")
        {
            PlayerPrefs.SetString(r_name + "_I", "true");
        }
    }

    public void GoSBTGuide()
    {
        SceneManager.LoadScene("MRGuide");
    }

    public void GoCupGuide()
    {
        SceneManager.LoadScene("CupGuide");
    }
}

