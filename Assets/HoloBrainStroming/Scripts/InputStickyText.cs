using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class InputStickyText : MonoBehaviour ,IFocusable{

    public Text statusText;
    public GameObject XPic;
    public void OnFocusEnter()
    {
        if (MakeStickyManager.Instance.m_DictationRecognizer.Status == SpeechSystemStatus.Running)
        {
            statusText.text = "Running";
        }
        else if (MakeStickyManager.Instance.m_DictationRecognizer.Status == SpeechSystemStatus.Stopped)
        {
            statusText.text = "Stopped";
        }
        else
        {
            statusText.text = "Failed";
        }
            
        StartCoroutine(StartDictation());
        
    }

    public void OnFocusExit()
    {
        statusText.text = "";
        MakeStickyManager.Instance.canInput = false;
        XPic.SetActive(true);
    }

    IEnumerator StartDictation()
    {
        if (MakeStickyManager.Instance.m_DictationRecognizer.Status == SpeechSystemStatus.Running)
        {
            MakeStickyManager.Instance.canInput = true;
            XPic.SetActive(false);
            yield return null;
        }
        else
        {
            MakeStickyManager.Instance.m_DictationRecognizer.Start();
            while (MakeStickyManager.Instance.m_DictationRecognizer.Status != SpeechSystemStatus.Running)
            {
                yield return new WaitForSeconds(0.5f);
            }

            statusText.text = "Running";
            MakeStickyManager.Instance.canInput = true;
            XPic.SetActive(false);
        }
        

    }

    // Use this for initialization
    void Start () {
        statusText.text = "";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
