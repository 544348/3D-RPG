using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    void awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if(objs.Length > 1)
        {
            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
