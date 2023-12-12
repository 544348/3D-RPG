using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    //variables
    public Transform targetObj;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 10 * Time.deltaTime);
    }
}
