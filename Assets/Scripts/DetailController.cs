using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailController : MonoBehaviour
{
    RecipeCodeSaver Codesaver;
    public GameObject[] Recipes = new GameObject[9];
    public Animator anim;

    void Start()
    {
        Codesaver = GameObject.Find("DataSave").GetComponent<RecipeCodeSaver>();
        for(int i = 0; i < 9; i++)
        {
            Recipes[i].SetActive(false);
        }
        SetRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetRecipe()
    {
        Recipes[Codesaver.getCode()].SetActive(true);
    }

    public void AddHeart(string r_name)
    {
        PlayerPrefs.SetString(r_name, "true");
        anim.SetTrigger("AddHeart");
    }

    public void DelHeart(string r_name)
    {
        PlayerPrefs.SetString(r_name, "false");
        anim.SetTrigger("DelHeart");
    }
}
