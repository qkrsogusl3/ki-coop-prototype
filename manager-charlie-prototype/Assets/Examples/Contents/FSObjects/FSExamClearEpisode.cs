﻿using UnityEngine;
using CustomDebug;
using Util;
using Contents;
namespace Examples
{
    public class FSExamClearEpisode : QnAFiniteState
    {
        public override QnAContentsBase.State StateID
        {
            get
            {
                return QnAContentsBase.State.Clear;
            }
        }

        public override void Initialize()
        {

        }
        public override void Enter()
        {
            CDebug.Log("[FSM] Clear Episode");
            Entity.UI.ClearEpisode();
            Entity.ChangeState(QnAContentsBase.State.None);
        }
        public override void Excute()
        {
        }
        public override void Exit()
        {

        }
    }
}