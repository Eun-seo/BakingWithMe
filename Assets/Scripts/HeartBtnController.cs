using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBtnController : MonoBehaviour
{
    public GameObject[] Hearts = new GameObject[9];
    public Animator NoticeAnim;

    private void Start()
    {
        if(PlayerPrefs.GetString("Tiramisu") == "true")
        {
            Hearts[0].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Tiramisu") == "false" || !PlayerPrefs.HasKey("Tiramisu"))
        {
            Hearts[0].SetActive(false);
        }

        if (PlayerPrefs.GetString("Icebox") == "true")
        {
            Hearts[1].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Icebox") == "false" || !PlayerPrefs.HasKey("Icebox"))
        {
            Hearts[1].SetActive(false);
        }

        if (PlayerPrefs.GetString("Smore") == "true")
        {
            Hearts[2].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Smore") == "false" || !PlayerPrefs.HasKey("Smore"))
        {
            Hearts[2].SetActive(false);
        }

        if (PlayerPrefs.GetString("Bark") == "true")
        {
            Hearts[3].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Bark") == "false" || !PlayerPrefs.HasKey("Bark"))
        {
            Hearts[3].SetActive(false);
        }

        if (PlayerPrefs.GetString("Pongdang") == "true")
        {
            Hearts[4].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Pongdang") == "false" || !PlayerPrefs.HasKey("Pongdang"))
        {
            Hearts[4].SetActive(false);
        }

        if (PlayerPrefs.GetString("Strawberry") == "true")
        {
            Hearts[5].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Strawberry") == "false" || !PlayerPrefs.HasKey("Strawberry"))
        {
            Hearts[5].SetActive(false);
        }

        if (PlayerPrefs.GetString("Cloud") == "true")
        {
            Hearts[6].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Cloud") == "false" || !PlayerPrefs.HasKey("Cloud"))
        {
            Hearts[6].SetActive(false);
        }

        if (PlayerPrefs.GetString("Pudding") == "true")
        {
            Hearts[7].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Pudding") == "false" || !PlayerPrefs.HasKey("Pudding"))
        {
            Hearts[7].SetActive(false);
        }

        if (PlayerPrefs.GetString("Cookie") == "true")
        {
            Hearts[8].SetActive(true);
        }
        else if (PlayerPrefs.GetString("Cookie") == "false" || !PlayerPrefs.HasKey("Cookie"))
        {
            Hearts[8].SetActive(false);
        }

    }

    public void Heart1()
    {
        if (Hearts[0].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[0].SetActive(false);
            PlayerPrefs.SetString("Tiramisu", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[0].SetActive(true);
            PlayerPrefs.SetString("Tiramisu", "true");
        }
    }

    public void Heart2()
    {
        if (Hearts[1].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[1].SetActive(false);
            PlayerPrefs.SetString("Icebox", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[1].SetActive(true);
            PlayerPrefs.SetString("Icebox", "true");
        }
    }

    public void Heart3()
    {
        if (Hearts[2].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[2].SetActive(false);
            PlayerPrefs.SetString("Smore", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[2].SetActive(true);
            PlayerPrefs.SetString("Smore", "true");
        }
    }

    public void Heart4()
    {
        if (Hearts[3].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[3].SetActive(false);
            PlayerPrefs.SetString("Bark", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[3].SetActive(true);
            PlayerPrefs.SetString("Bark", "true");
        }
    }

    public void Heart5()
    {
        if (Hearts[4].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[4].SetActive(false);
            PlayerPrefs.SetString("Pongdang", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[4].SetActive(true);
            PlayerPrefs.SetString("Pongdang", "true");
        }
    }

    public void Heart6()
    {
        if (Hearts[5].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[5].SetActive(false);
            PlayerPrefs.SetString("Strawberry", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[5].SetActive(true);
            PlayerPrefs.SetString("Strawberry", "true");
        }
    }

    public void Heart7()
    {
        if (Hearts[6].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[6].SetActive(false);
            PlayerPrefs.SetString("Cloud", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[6].SetActive(true);
            PlayerPrefs.SetString("Cloud", "true");
        }
    }

    public void Heart8()
    {
        if (Hearts[7].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[7].SetActive(false);
            PlayerPrefs.SetString("Pudding", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[7].SetActive(true);
            PlayerPrefs.SetString("Pudding", "true");
        }
    }

    public void Heart9()
    {
        if (Hearts[8].activeSelf)
        {
            NoticeAnim.SetTrigger("DelHeart");
            Hearts[8].SetActive(false);
            PlayerPrefs.SetString("Cookie", "false");
        }
        else
        {
            NoticeAnim.SetTrigger("AddHeart");
            Hearts[8].SetActive(true);
            PlayerPrefs.SetString("Cookie", "true");
        }
    }
}
