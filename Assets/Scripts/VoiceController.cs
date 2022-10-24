using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "ko-KR";

    public TextMesh uiText;
    public TextMesh textResult;

    public GameObject voiceCmd; //명령어

    TutorialController tutoCtrl;

    private void Start()
    {

        tutoCtrl = GetComponent<TutorialController>();
        Setup(LANG_CODE);

        TextSpeech.SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextSpeech.TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextSpeech.TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        CheckPermission();

    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }
#endif
    #region Text to Speech

    public void StartSpeaking(string message)
    {
        TextSpeech.TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking(string message)
    {
        TextSpeech.TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart()
    {
        Debug.Log("Talking started...");
    }

    void OnSpeakStop()
    {
        Debug.Log("Talking stopped");
    }
    #endregion

    #region Speech to Text

    public void StartListening()
    {
        TextSpeech.SpeechToText.instance.StartRecording();
        uiText.text = "듣는중...";
    }

    public void StopListening()
    {
        TextSpeech.SpeechToText.instance.StopRecording();
        uiText.text = "음성인식버튼";
    }

    void OnFinalSpeechResult(string result)
    {
        textResult.text = result;
        uiText.text = "인식완료";
        VoiceOrder(result);
    }
    #endregion

    void VoiceOrder(string result)
    {
        if (result == "다음으로" || result == "다음 단계로" || result == "다음 단계")
        {
            tutoCtrl.ToNext();
        }

        if (result == "이전으로" || result == "이전 단계로" || result == "이전 단계")
        {
            tutoCtrl.ToPrev();
        }

        if (result == "끝내기" || result == "종료" || result == "나가기")
        {
            SceneManager.LoadScene("DetailScene");
        }
    }

    void Setup(string code)
    {
        TextSpeech.TextToSpeech.instance.Setting(code, 1, 1);
        TextSpeech.SpeechToText.instance.Setting(code);
    }


    #region 명령어
    public void ShowCommand()
    {
        voiceCmd.GetComponent<Animator>().SetBool("isClick", true);
       // uiText.text = "명령어 클릭됨";
    }

    public void HideCommand()
    {
        voiceCmd.GetComponent<Animator>().SetBool("isClick", false);
    }
    #endregion
}
