using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private bool isRotating = false;
    private int x = 1;
    private int y = 2;
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

                if (transform.rotation.z == 0 || transform.rotation.z == 180)
                {
                    transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
                    return;
                }

                if (transform.position.y == 1)
                {
                    transform.position = new Vector3(transform.position.x+ 1.5f, 0.5f, transform.position.z);

                }
                else
                {
                    transform.position = new Vector3(transform.position.x + 1.5f, 1f, transform.position.z);
                }

                /*
                x++;
                Debug.Log(x);

                if (x % 2 == 0) {
                    transform.position += new Vector3(1.5f,-0.5f, 0);
                    x = 0;
                    
                }
                else {
                    transform.position += new Vector3(1.5f,0.5f, 0);
                    
                }
                */
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                StartCoroutine(RotateAndWait(-90.0f,1));
                if (transform.rotation.x == 90 || transform.rotation.x == -90) 
                {
                    transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
                    return;
                }



                if (transform.position.y == 1)
                {
                    transform.position = new Vector3(transform.position.x- 1.5f, 0.5f, transform.position.z);
                    

                }
                else
                {
                    transform.position = new Vector3(transform.position.x - 1.5f, 1f, transform.position.z);
                    
                }
                /*
                x++;
                
                Debug.Log(x);

                if (x % 2 == 0)
                {
                    transform.position += new Vector3(-1.5f, -0.5f, 0);
                    x = 0;
                }
                else
                {
                    transform.position += new Vector3(-1.5f,0.5f, 0);

                }
                */
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                StartCoroutine(RotateAndWait(90.0f, 2));

                Debug.Log("x in x:" + x);

                if (transform.rotation.x == 0 || transform.rotation.x == 180)
                {
                    transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z+1.5f );
                    return;
                }

                if (transform.position.y == 1)
                {
                    transform.position = new Vector3(transform.position.x , 0.5f, transform.position.z+ 1.5f);
                    

                }
                else if (transform.position.y == 1)
                {

                    transform.position = new Vector3(transform.position.x, 1f, transform.position.z+ 1.5f);
                    x = 2;  
                }
                

                /*
                Debug.Log("x in x:"+x);

                if (x % 2 == 0)
                {
                    transform.position += new Vector3(0, 0, 1.5f);
                }
                else
                {
                    if (y % 2 == 0)
                    {
                        transform.position += new Vector3(0, -0.5f, 1.5f);
                        y = 1;
                       
                    }
                    else
                    {
                        transform.position += new Vector3(0, +0.5f, 1.5f);
                        y++;
                    }
                   

                }
                */
            }
            /*
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                StartCoroutine(RotateAndWait(90.0f, 2));
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
            */
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
