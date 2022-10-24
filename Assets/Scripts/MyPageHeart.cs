using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPageHeart : MonoBehaviour
{
    string objName = "";
    string parentName = "";
    GameObject parent;
    MyPageController mpc;

    void Start()
    {
        mpc = GameObject.Find("MyPageController").GetComponent<MyPageController>();
        objName = this.gameObject.name;
        Refresh();
    }

    public void Refresh()
    {
        
        if (PlayerPrefs.HasKey(objName))
        {
            if (PlayerPrefs.GetString(objName) == "true")
            {
                this.gameObject.SetActive(true);
            }
            else
            {

                this.gameObject.SetActive(false);
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        mpc.Count();
    }
    
    public void Refresh_Heart()
    {
        parent = this.transform.parent.gameObject;
        parentName = parent.name;
        if (PlayerPrefs.HasKey(parentName))
        {
            if (PlayerPrefs.GetString(parentName) == "true")
            {
                parent.SetActive(true);
            }
        }
        else
        {
            parent.SetActive(false);
        }
    }
}
