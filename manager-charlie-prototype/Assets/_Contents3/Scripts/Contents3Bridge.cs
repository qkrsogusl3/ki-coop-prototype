﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Contents;
using Contents3;
using CustomDebug;



public class Contents3Bridge : MonoBehaviour {

    protected QnAContentsBase.State mState;
    protected SceneContents3 mContents3 = null;

	void Start () {

        mContents3 = new SceneContents3();
        mState = mContents3.GetState();

	}
	

	void Update () {
		
	}
}
