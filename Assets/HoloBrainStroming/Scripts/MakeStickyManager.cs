using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using UnityEngine.UI;

public class MakeStickyManager : Singleton<MakeStickyManager>
{
    public DictationRecognizer m_DictationRecognizer;
    public GameObject HoloSticky;
    public GameObject FukidashiUI;
    public Transform MyStickyHolder;
    private List<GameObject> stickyList = new List<GameObject>();
    public bool canInput = false;
    public bool isSelectingSticky = false;
    public GameObject SelectingSticky;
    // Use this for initialization
    void Start () {
        MyStickyHolder.position = Camera.main.transform.TransformPoint(new Vector3(0f, 0f, 1f));
        m_DictationRecognizer = new DictationRecognizer();
        m_DictationRecognizer.InitialSilenceTimeoutSeconds = 30f;
        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            if (canInput)
            {
                MakeSticky(text);
            }
            
        };
        
    }

    public void MakeSticky(string text)
    {
        GameObject Sticky = GameObject.Instantiate(HoloSticky);
        Sticky.transform.transform.Find("HoloStickyUI").transform.transform.Find("Image").transform.transform.Find("Text").GetComponent<Text>().text = text;
        stickyList.Add(Sticky);
        Sticky.transform.position = Camera.main.transform.TransformPoint(new Vector3(0f, 0f, 1f));
        Sticky.transform.rotation = Quaternion.LookRotation(Sticky.transform.position - Camera.main.transform.position);
        //Sticky.transform.localScale = new Vector3(0.148f, 0.148f, 0.148f);


    }

    // Update is called once per frame
    void Update () {

    }
}
