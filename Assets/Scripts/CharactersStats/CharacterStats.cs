using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour
{
//------------------------------------ HEALTH ------------------------------------------//
    [SerializeField] private int health = 100;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            health = value;
        }
    }

    public void applyHealthChange(int value)
    {
        Health += value;
    }

//------------------------------------ MANA ------------------------------------------//
    [SerializeField] private int mana = 100;
    public int Mana
    {
        get
        {
            return mana;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            mana = value;
        }
    }

    public void applyManaChange(int value)
    {
        Mana += value;
    }
}
