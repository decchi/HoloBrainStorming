using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine.UI;

public class ShareSticky : MonoBehaviour, IInputClickHandler
{
    public GameObject Sticky;
    public bool isShared;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!isShared)
        {
            isShared = true;
            float randamX = UnityEngine.Random.Range(-1.5f, 1.5f);
            float randamY = UnityEngine.Random.Range(0.3f, 1.3f);
            float randamZ = UnityEngine.Random.Range(-1.5f, 1.5f);
            Vector3 MoveToPos = new Vector3(MakeStickyManager.Instance.MyStickyHolder.position.x + randamX, MakeStickyManager.Instance.MyStickyHolder.position.y + randamY, MakeStickyManager.Instance.MyStickyHolder.position.z + randamZ);
            iTween.MoveTo(Sticky, MoveToPos, 7f);
        }
        else
        {
            MakeStickyManager.Instance.SelectingSticky = Sticky;
        }
        

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
