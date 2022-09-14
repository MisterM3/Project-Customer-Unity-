using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteract
{

    public event EventHandler onObjectSelect;
    public event EventHandler onObjectDeSelect;
    public void Activate();
    
}
