using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class oscillate : MonoBehaviour
{
    private Vector3 InitialPosition;
    private float speed =2f ;
    private Vector3 target; 
    public  Vector3 center = Vector3.zero;

    
    void Start()
    {
        InitialPosition = transform.position;
        target = center; 

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            if (target == center)
            {
                target = InitialPosition;
            }
            else
            {
                target = center;
            }
        }
        transform.LookAt(target);


    }
}
