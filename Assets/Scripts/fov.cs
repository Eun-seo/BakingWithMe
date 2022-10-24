using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fov : MonoBehaviour
{
    public Camera leftCam;
    public Camera rightCam;
    public Text text;
    float leftnum = 0.5f;
    float rightnum = 0.5f;

    private void Start()
    {
        StartCoroutine(SetCamera());
        
    }

    IEnumerator SetCamera()
    {
        yield return new WaitForSeconds(1);
        rightCam.rect = new Rect(0.31f, 0, 1.15f, 1);
    }
    private void Update()
    {
        //leftCam.rect = new Rect(0,0,leftnum,1);
        //rightCam.rect = new Rect(0.5f, 0, rightnum, 1);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Left();
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Right();
        //}

        //text.text = leftnum.ToString();
    }

    public void Left()
    {
        rightnum -= 0.01f;
        leftnum += 0.01f;
        print("left");
    }

    public void Right()
    {
        rightnum += 0.01f;
        leftnum -= 0.01f;
        print("right");
    }
}
