using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class VoiceBtn : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private VoiceController voiceCtrl;
   // [SerializeField] private TutorialController tutorialCtrl;

    private void OnEnable()
    {
        Debug.Log("Enable");
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
    }

    private void HandleOver()
    {
         voiceCtrl.StartListening();
        //tutorialCtrl.ToNext();
       
    }

    private void HandleOut()
    {
        voiceCtrl.StopListening();
    }

    private void HandleClick()
    {

    }
}
