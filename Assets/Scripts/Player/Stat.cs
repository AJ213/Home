﻿using UnityEngine;

public class Stat : MonoBehaviour
{
    public float MaxStat { get { return maxStat; } 
        set 
        {
            maxStat = value;
            UpdateMaxStat();
        } 
    }
    [SerializeField] protected float maxStat = default;
    public float RegenAmount { get { return regenAmount; } set { regenAmount = value; } }
    [SerializeField] protected float regenAmount = default;
    [SerializeField] protected float currentStat = default;

    protected virtual void Start()
    {
        UpdateMaxStat();
    }

    protected void UpdateMaxStat()
    {
        if (maxStat < 1)
            maxStat = 1;
        CurrrentStat = maxStat;

    }

    protected virtual void Update()
    {
        if (currentStat < maxStat)
        {
            CurrrentStat += regenAmount * Time.deltaTime;
        }
    }

    public virtual float CurrrentStat
    {
        get
        {
            return currentStat;
        }
        set
        {
            currentStat = value;
            if (currentStat <= 0)
            {
                //Debug.Log("Stat empty " + gameObject.name);
            }
            else if (currentStat > maxStat)
            {
                currentStat = maxStat;
            }

        }
    }
}


