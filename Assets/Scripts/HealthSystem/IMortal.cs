using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMortal 
{

    void Damage(int amount);

    void Heal(int amount);

    bool isDead();
}
