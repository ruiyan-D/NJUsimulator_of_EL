using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    public int Points;
    public List<Tasks> tasks;
    void Awake()
    {
        if(instance==null)
            instance = this;
        else
        {
            if(instance!=this)
                Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
}
