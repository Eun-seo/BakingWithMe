﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class ExitBtn : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private TutorialController tutorialCtrl;

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
        tutorialCtrl.ExitYes();
    }

    private void HandleOut()
    {
        tutorialCtrl.ExitYesOff();
    }

    private void HandleClick()
    {

    }
}
