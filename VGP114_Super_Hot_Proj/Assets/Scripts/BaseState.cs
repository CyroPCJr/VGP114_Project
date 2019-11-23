using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected GameObject mGameObject;
    protected Transform mTransform;

    public BaseState(GameObject gameObject)
    {
        mGameObject = gameObject;
        mTransform = gameObject.transform;
    }

}