using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCodeSaver : MonoBehaviour
{
    static int RecipeCode;
    static string MyPageState;
    static public int clipNum = 0;


    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetCode(int code)
    {
        RecipeCode = code;
    }

    public int getCode()
    {
        return RecipeCode;
    }

    public void SetMyPage(string state)
    {
        MyPageState = state;
    }

    public string getMyPage()
    {
        return MyPageState;
    }
}
