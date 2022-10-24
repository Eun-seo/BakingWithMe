using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailStep : MonoBehaviour
{
    public List<TextAsset> jsonFile;
    private Recipe[] jData;
    RecipeCodeSaver Codesaver;

    int recipeCode = 1;
    int step = 0;
    // Start is called before the first frame update
    void Start()
    {
        Codesaver = GameObject.Find("DataSave").GetComponent<RecipeCodeSaver>();
        recipeCode = GameObject.Find("DataSave").GetComponent<RecipeCodeSaver>().getCode();

        LoadJsonData_FromAsset(jsonFile[recipeCode]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadJsonData_FromAsset(TextAsset pAsset)
    {
        if (pAsset == null)
        {
            Debug.LogError("파일 없음");
            return;
        }

        LoadRecipe(pAsset.text);
    }
    void LoadRecipe(string jsonData)
    {
        jsonData = "{\"Items\":" + jsonData + "}";
        jData = JsonHelper.FromJson<Recipe>(jsonData);
    }

    void SetStep()
    {
       // jData[step].content
    }
}
