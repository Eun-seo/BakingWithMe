using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPageIngredient : MonoBehaviour
{
    string objName = "";
    MyPageController mpc;
    // Start is called before the first frame update
    void Start()
    {
       mpc = GameObject.Find("MyPageController").GetComponent<MyPageController>();
        objName = this.gameObject.name;
        Refresh_Ingridient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh_Ingridient()
    {
        print("Refresh");
        if(!PlayerPrefs.HasKey(objName + "_I") || PlayerPrefs.GetString(objName + "_I") == "false")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        mpc.Count_I();
    }
}
