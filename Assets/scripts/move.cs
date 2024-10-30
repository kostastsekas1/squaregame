using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 2f;
    private bool isRotating = false;
    private int x = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isRotating)
        {
           
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                StartCoroutine(RotateAndWait(90.0f));
                x++;
                Debug.Log(x);

                if (x % 2 == 0) {
                    transform.position += new Vector3(2f,-0.5f, 0);
                    x = 0;
                   
                }
                else {
                    transform.position += new Vector3(1f,0.5f, 0);
                    
                }
                //CharacterController. += transform.localScale.z;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                StartCoroutine(RotateAndWait(-90.0f));
                x++;
                Debug.Log(x);

                if (x % 2 == 0)
                {
                    transform.position += new Vector3(-2, -0.5f, 0);
                    x = 0;
                }
                else
                {
                    transform.position += new Vector3(-1,0.5f, 0);

                }
            }
            
        }


    }


    private IEnumerator RotateAndWait(float angle)
    {
        isRotating = true;
        transform.Rotate(0.0f, 0.0f, angle, Space.World);         
        yield return new WaitForSeconds(1f);
        isRotating = false;

    }

}
