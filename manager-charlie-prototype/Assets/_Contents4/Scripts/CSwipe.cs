﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomDebug;

public class CSwipe : MonoBehaviour {

    public float InputTime = 0.0f;
    public float Distance = 0.0f;
    public Vector3 InputPosition = Vector3.zero;
    public Vector3 OutPutPosition = Vector3.zero;
    public Vector3 Direction = Vector3.zero;
    public bool IsSwipe = false;

    private void Awake()
    {


        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseDown()
    {
      
        //CDebug.Log("땅맞아?");
        //CDebug.LogFormat("이게뭐지?{0}",InputTime);
       
        InputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //CDebug.Log(InputPosition);
    }

    private void OnMouseDrag()
    {
        InputTime++;
    }

    private void OnMouseUp()
    {
        //CDebug.Log("땠나?");
        //CDebug.LogFormat("몇인데?{0}", InputTime);
        InputTime = 0;
        OutPutPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //CDebug.Log(OutPutPosition);
        Direction = OutPutPosition - InputPosition;
        Distance = Direction.y;
        CDebug.LogFormat("어디로감?{0}", Distance);

        if (Distance != 0)
        {
            IsSwipe = true;
        }
    }

}
