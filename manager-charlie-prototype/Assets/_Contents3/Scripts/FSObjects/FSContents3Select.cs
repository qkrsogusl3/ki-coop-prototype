﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Contents.QnA;
using Util;
using CustomDebug;

namespace Contents3
{
    public class FSContents3Select : QnAFiniteState
    {

        public override QnAContentsBase.State StateID
        {
            get
            {
                return QnAContentsBase.State.Select;
            }
        }

        private SimpleTimer Timer = SimpleTimer.Create();
        private float mSelectingDuration = 10.0f;

        public override void Initialize()
        {

        }
        public override void Enter()
        {
            CDebug.Log("Select");
        }
        public override void Excute()
        {
            //CDebug.Log("Checking");
            Timer.Update();
            if (Timer.Check(mSelectingDuration))
            {
                CDebug.Log("haven't answered");
                
                //Entity.ChangeState(QnAContentsBase.State.Select);
            }
        }
        public override void Exit()
        {

        }

    }
}
