﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Data;

namespace Contents
{
    public abstract class ContentsBase<T, U> : FiniteStateMachine<T, U>
    {
      
        private IDataContainer mContainer = null;

        protected IDataContainer Container
        {
            get
            {
                if(mContainer == null)
                {
                    mContainer = GetDataContainer();
                }
                return mContainer;
            }
        }
        protected virtual IDataContainer GetDataContainer()
        {
            return new MocContainer();
        }

    }
}
