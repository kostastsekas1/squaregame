using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private bool isRotating = false;
    private int x = 1;
    private int y = 1;
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
                StartCoroutine(RotateAndWait(90.0f,1));
                x++;
                y++;
                Debug.Log(x);

                if (x % 2 == 0) {
                    transform.position += new Vector3(1.5f,-0.5f, 0);
                    x = 0;
                    y= 0;
                   
                }
                else {
                    transform.position += new Vector3(1.5f,0.5f, 0);
                    
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                StartCoroutine(RotateAndWait(-90.0f,1));
                x++;
                y++;
                Debug.Log(x);

                if (x % 2 == 0)
                {
                    transform.position += new Vector3(-1.5f, -0.5f, 0);
                    y= 0;
                    x = 0;
                }
                else
                {
                    transform.position += new Vector3(-1.5f,0.5f, 0);

                }
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                StartCoroutine(RotateAndWait(90.0f, 2));
                x++;
                y++;
                
                Debug.Log("x in x:"+x);

                if (y % 2 == 0)
                {
                    transform.position += new Vector3(0, -0.5f, 1.5f);
                    y= 0;
                    x = 0;
                }
                else
                {
                    transform.position += new Vector3(0, 0.5f, 1.5f);

                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                StartCoroutine(RotateAndWait(90.0f, 2));
                x++;
                y++;
                Debug.Log(y);
                if (y % 2 == 0)
                {
                    transform.position += new Vector3(0, -0.5f, -1.5f);
                    y = 0;
                }
                else
                {
                    transform.position += new Vector3(0,0.5f, -1.5f);

                }
            }
        }


    }


    private IEnumerator RotateAndWait(float angle,int axis)
    {
        isRotating = true;
        if (axis == 1) 
        {
            transform.Rotate(0.0f, 0.0f, angle, Space.World);
        }
        else if (axis==2) 
        {
            transform.Rotate(angle, 0.0f,0.0f , Space.World);
        }
                 
        yield return new WaitForSeconds(1f);
        isRotating = false;

    }

}
