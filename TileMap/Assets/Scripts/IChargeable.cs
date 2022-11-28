using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface, defines method to charge or uncharge any object 
public interface IChargeable
{
    void recharge(float amount);
    float decharge(float amount);
}
