﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class PushNoBtn : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private ObjectController objectCtrl;
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
        objectCtrl.PushNo();
    }

    private void HandleOut()
    {

    }

    private void HandleClick()
    {

    }
}
