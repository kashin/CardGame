using UnityEngine;
using System.Collections;

public class ActionStats : MonoBehaviour
{
//------------------------------------ DAMAGE ------------------------------------------//
    [SerializeField] int damage = 10;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

//------------------------------------ Action Points ------------------------------------------//
    [SerializeField] int actionPoints = 1;
    public int ActionPoints
    {
        get
        {
            return actionPoints;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            actionPoints = value;
        }
    }
}
