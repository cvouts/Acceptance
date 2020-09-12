/* SEND NUDES */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int hp;
    public bool enable;
    private int prevhp;

    public void Awake()
    {
        prevhp = hp;
    }

    public void Damage(int dmg)
    {
        hp -= dmg;
    }

    public bool isDamaged()
    {
        if (prevhp != hp)
        {
            prevhp = hp;
            return true;
        }
        return false;
    }

    public bool isDead()
    {
        if (hp<=0)
        {
            return true;
        }
        return false;
    }

    public void setEnable(bool value) {
        enable = value;
    }

    public bool isEnabled() {
        return enable;
    }
}
