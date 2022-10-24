using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Assets.SimpleAndroidNotifications;
using System;

public class ObjectController : MonoBehaviour
{
    public GameObject video;
    public GameObject picture;
    public TextMesh stepText;
    public TextMesh stepNum;
    public TextMesh contentText;
    public GameObject guide;
    public GameObject object3d;
    public GameObject Timer;
    public TextMesh timerText;
    public GameObject notice;
    public TextMesh noticeText;
    public TextMesh tip;
    public TextMesh tipshadow;
    public GameObject picBackground;
    public GameObject videoBackground;
    public GameObject nextStep;
    public GameObject nextStepshadow;
    public GameObject pictureVideo;
    public List<GameObject> noticeBtn = new List<GameObject>();
    public Animator tipAnim;

    Animator pictureAnimator;
    AudioSource _audio;
    public GameObject[] object3Ds = new GameObject[2];

    int recipeCode = 8;
    int tipNum = 0;
    int step_num = 0;
    float audioLength;
    float audioLength_tip;

    float _popupData;

    string popUptext;

    void Start()
    {
        recipeCode = GameObject.Find("DataSave").GetComponent<RecipeCodeSaver>().getCode();
        pictureAnimator = pictureVideo.GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
       // StartCoroutine(SetTimer(2));
    }

    public void LoadStep(int size, int step, string content, string pictureData, string guideData, string object3dData, string timerData, float popupData, string tipData)
    {
        StopAllCoroutines();
        CancelInvoke();

        tipAnim.SetBool("isShow", false);

        popUptext = "";
        nextStep.SetActive(false);

        Debug.Log("LoadStep()");
        videoBackground.SetActive(true);

        //step
        size--;
        stepText.text = "STEP      /" + size;
        stepNum.text = step.ToString();
        //content
        contentText.text = content;
        //video
        string path = "video/"+ recipeCode + "/" + step;
        video.GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>(path);
        Invoke("VideoStop", 1);
        //narration
        string nPath = "narration/" + recipeCode + "/" + step;
        _audio.clip = Resources.Load<AudioClip>(nPath);

        if (!tipData.Contains("예열"))
        {
            step_num = step;
            _audio.Play();
            audioLength = _audio.clip.length + 1;
            Invoke("VideoPlay", audioLength);
        }

        //TipNarration
        if (tipData != "" && tipData != null)
        {
            print("tip 출력");
            tipNum++;
            if (tipData.Contains("예열"))
            {
                StartCoroutine(TipNarration2(object3dData));
            }
            else
            {
                Invoke("TipNarration", audioLength + 15);
            }
        }

        float length = (float)video.GetComponent<VideoPlayer>().clip.length;
        print(length);

        #region picture
        if(pictureData == null || pictureData == "")
        {
            picBackground.SetActive(false);
            pictureAnimator.SetBool("isPicture", false);
        }
        else
        {
            pictureAnimator.SetBool("isPicture", false);
            picBackground.SetActive(true);
            picture.SetActive(true);
            Timer.SetActive(false);
            timerText.gameObject.SetActive(false);
            path = "picture/" + recipeCode + "/" + step;
            if(recipeCode == 4 && (step == 4 || step == 5 || step == 8 || step == 9))
            {
                picture.GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>(path);
            }
            else
            {
                picture.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(path);
            }
            
            Invoke("ShowPicture", length-5);
        }
        #endregion

        #region guide
        if (guideData == null || guideData == "")
        {
            guide.SetActive(false);
        }
        else
        {
            guide.SetActive(true);
           // path = "guide/" + step;
           // guide.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
        }
        #endregion

        #region object3D
        if (object3dData == null || object3dData == "")
        {
            object3d.SetActive(false);
        }
        else
        {
            if (!tipData.Contains("예열"))
            {
                StartCoroutine(Show3D(object3dData));
            }
                

        }
        #endregion

        #region timer
        if (timerData == null || timerData == "")
        {
            Timer.SetActive(false);
        }
        else
        {
           // Timer.SetActive(true);
            timerText.text = timerData.Length == 1 ? "0" + timerData + " : 00" : timerData + " : 00";
        }
        #endregion

        #region popUp
        if(popupData != 0)
        {
            _popupData = popupData;

            
            if (popupData > 1.0)
            {
                popUptext = (int)popupData + "시간 " + (popupData - (int)popupData)*100 + "분 ";
            }
            else if (popupData == 1.0)
            {
                popUptext = (int)popupData + "시간 ";
            }
            else if (popupData < 1.0)
            {
                popUptext = popupData*100 + "분 ";
            }
            noticeText.text = popUptext + "후에\nPush 알림으로 알려드릴게요.";

            Invoke("ShowPopup", audioLength);
            
            //Push(1);
        }
        else
        {
            notice.GetComponent<Animator>().SetBool("isClick", false);
        }
        #endregion

        #region tip
        if(tipData == null || tipData == "")
        {
            //  tip.gameObject.SetActive(false);
           // tipAnim.SetBool("isShow", false);
        }
        else
        {
            //tip.gameObject.SetActive(true);
           // tipAnim.SetBool("isShow", true);
            tip.text = tipData;
            tipshadow.text = tipData;
        }
        #endregion

        if(size > step + 1)
        {
            print("nextstep");
            Invoke("NextStepNotice", length);
        }
    }

    void TipNarration()
    {
        tipAnim.SetBool("isShow", true);
        Debug.Log("팁 나레이션");
        string nPath = "narration/" + recipeCode + "/tip" + tipNum;
        _audio.clip = Resources.Load<AudioClip>(nPath);
        audioLength_tip = _audio.clip.length;
        _audio.Play();
    }

    IEnumerator TipNarration2(string Data)
    {
        yield return new WaitForSeconds(1);
        tipAnim.SetBool("isShow", true);
        Debug.Log("팁 나레이션");
        string nPath = "narration/" + recipeCode + "/tip" + tipNum;
        _audio.clip = Resources.Load<AudioClip>(nPath);
        audioLength_tip = _audio.clip.length;
        _audio.Play();

        
        yield return new WaitForSeconds(audioLength_tip + 15);
        StartCoroutine(Show3D(Data));
        nPath = "narration/" + recipeCode + "/" + (step_num + 1);

        _audio.clip = Resources.Load<AudioClip>(nPath);
        _audio.Play();
        audioLength = _audio.clip.length + 1;
        Invoke("VideoPlay", audioLength);

    }

    void VideoStop()
    {
        video.GetComponent<VideoPlayer>().Pause();
    }

    void VideoPlay()
    {
        video.GetComponent<VideoPlayer>().Play();
    }

    #region 3D 오브젝트 코루틴
    IEnumerator Show3D(string Data)
    {
        yield return new WaitForSeconds(audioLength);

        object3d.SetActive(true);
        switch (Data)
        {
            case "mixer":
                object3Ds[0].SetActive(true);
                object3Ds[1].SetActive(false);
                break;
            case "spatular":
                object3Ds[1].SetActive(true);
                object3Ds[0].SetActive(false);
                break;
            default:
                print("object3DData has wrong data format");
                object3Ds[1].SetActive(false);
                object3Ds[0].SetActive(false);
                break;
        }
        

        yield return new WaitForSeconds(15);

        object3d.SetActive(false);
    }
    #endregion

    #region 팝업 보이기 - 푸시알림으로 알려드릴게요
    void ShowPopup()
    {
      //  notice.SetActive(true);
        notice.GetComponent<Animator>().SetBool("isClick", true);
        string nPath = "narration/" + recipeCode + "/popup1";
        _audio.clip = Resources.Load<AudioClip>(nPath);
        _audio.Play();
        noticeBtn[0].SetActive(false);
        noticeBtn[1].SetActive(false);
        noticeBtn[2].SetActive(false);
        noticeBtn[3].SetActive(false);
        noticeBtn[4].SetActive(true);

        Invoke("PushYes", 15);
    }
    #endregion

    #region 푸시알림 네
    public void PushYes()
    {
        Push((int)_popupData * 60 + (_popupData - (int)_popupData) * 100);

        notice.GetComponent<Animator>().SetBool("isClick", false);
        tip.gameObject.SetActive(true);
        nextStep.SetActive(true);

        #region 타이머
        Timer.SetActive(true);
        timerText.gameObject.SetActive(true);
        picture.SetActive(false);
        ShowPicture();
        StartCoroutine(SetTimer((int)_popupData * 60 + (_popupData - (int)_popupData) * 100));
        #endregion

        tip.text = "오븐에서 " + popUptext + " 구운 후 " + GetRecipeName(recipeCode) + "을 완성해주세요.";
        tipshadow.text = "오븐에서 " + popUptext + " 구운 후 " + GetRecipeName(recipeCode) + "을 완성해주세요.";

        string nPath = "narration/" + recipeCode + "/popup_end";
        _audio.clip = Resources.Load<AudioClip>(nPath);
        _audio.Play();
        nextStep.GetComponent<TextMesh>().text = "음성명령 '종료'";
        nextStepshadow.GetComponent<TextMesh>().text = "음성명령 '종료'";
    }
    #endregion

    #region 푸시알림 아니오
    public void PushNo()
    {
        CancelInvoke();
        //   pictureAnimator.SetBool("isPicture", false);
        // picBackground.SetActive(true);
        // ShowPicture();
        notice.GetComponent<Animator>().SetBool("isClick", false);

        tip.gameObject.SetActive(true);
        nextStep.SetActive(true);
        tip.text = "오븐에서 " + popUptext + " 구운 후 " + GetRecipeName(recipeCode) + "을 완성해주세요.";
        tipshadow.text = "오븐에서 " + popUptext + " 구운 후 " + GetRecipeName(recipeCode) + "을 완성해주세요.";

        #region 타이머
        //Timer.SetActive(true);
        timerText.gameObject.SetActive(true);
        picture.SetActive(false);
        ShowPicture();
        StartCoroutine(SetTimer((int)_popupData * 60 + (_popupData - (int)_popupData) * 100));
        #endregion

        string nPath = "narration/" + recipeCode + "/popup_end";
        _audio.clip = Resources.Load<AudioClip>(nPath);
        _audio.Play();
        nextStep.GetComponent<TextMesh>().text = "음성명령 '종료'";
        nextStepshadow.GetComponent<TextMesh>().text = "음성명령 '종료'";
    }
    #endregion

    #region 타이머 시작 코루틴
    IEnumerator SetTimer(float minute)
    {
        int second = 0;
        while (minute >= 0)
        {
            timerText.text = "";
            if (minute >= 60)
            {
                timerText.text += "0" + (int)(minute / 60) + ":";
            }
            else
            {
                timerText.text += "00:";
            }
            if(minute % 60 < 10)
            {
                timerText.text += "0";
            }
            if (second < 10)
            {
                timerText.text += minute % 60 + ":0" + second;
            }
            else
            {
                timerText.text += minute % 60 + ":" + second;
            }
            
            yield return new WaitForSeconds(1.0f);
            second--;
            if (second < 0)
            {
                second = 59;
                minute--;
            }
        }
    }
    #endregion

    void ShowPicture()
    {
        pictureAnimator.SetBool("isPicture", true);
    }

    #region 음성명령 다음단계로
    void NextStepNotice()
    {
        print("nextstep show");
        nextStep.SetActive(true);
        string nPath = "narration/notice/voice_next";
        _audio.clip = Resources.Load<AudioClip>(nPath);
        _audio.Play();
    }
    #endregion

    #region 푸시알림
    void Push(float pushTime)
    {
#if UNITY_ANDROID
        NotificationManager.CancelAll();
        DateTime timeToNotify = DateTime.Now.AddMinutes(pushTime);
        TimeSpan time = timeToNotify - DateTime.Now;
        NotificationManager.SendWithAppIcon(time, "오븐이 종료되었습니다. 맛있게 드세요!","", Color.blue, NotificationIcon.Bell);
#endif
        print(pushTime);
    }
    #endregion

    #region 레시피 이름 함수
    string GetRecipeName(int recipeNum)
    {
        switch (recipeNum)
        {
            case 0:
                return "티라미수";
            case 1:
                return "아이스박스 케이크";
            case 2:
                return "스모어딥";
            case 3:
                return "바크초콜릿";
            case 4:
                return "퐁당오쇼콜라";
            case 5:
                return "딸기모찌";
            case 6:
                return "구름빵";
            case 7:
                return "커스터드푸딩";
            case 8:
                return "초코칩 쿠키";
            default:
                return "[error]";
        }
    }
    #endregion
}
