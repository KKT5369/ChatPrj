using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingleTon<InputManager>
{
    public Action move;
    
    
    private void Update()
    {
        if (move != null)
        {
            move.Invoke();
        }
    }
}

