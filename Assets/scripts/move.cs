using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class move : MonoBehaviour
{
    private bool isRotating = false;
    private int x = 1;
    private int y = 2;
    public BoxCollider col;
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

                transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);

                StartCoroutine(RotateAndWait(90.0f, 1));

            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {

                if (transform.position.y == 1)
                {
                    transform.position = new Vector3(transform.position.x- 1.5f, 0.5f, transform.position.z);
                    

                }
                else
                {
                    transform.position = new Vector3(transform.position.x - 1.5f, 1f, transform.position.z);
                    
                }
                StartCoroutine(RotateAndWait(-90.0f, 1));


            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {

                Debug.Log(transform.rotation.eulerAngles);

                
                if (transform.position.y == 1)
                {
                    transform.position = new Vector3(transform.position.x , 0.5f, transform.position.z+ 1.5f);
                    

                }
                else
                {

                    transform.position = new Vector3(transform.position.x, 1f, transform.position.z+ 1.5f);
                     
                }

                StartCoroutine(RotateAndWait(90.0f, 2));

            }
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
                    transform.position += new Vector3(0, 0.5f, -1.5f);

                }
            }
        }

       

        var yHalfExtents = col.bounds.extents.y;
        //get the center
        var yCenter = col.bounds.center.y;
        //get the up border
        //get the lower border
        float yLower = yCenter - yHalfExtents;


        Debug.Log("Lower border: " + yLower);


        if (yLower < 0f)
        {
            yLower = 0f;
        }


        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitData;
        var raycasthit = Physics.Raycast(ray,out hitData,3);


        Debug.DrawRay(transform.position, Vector3.down, Color.green);

        if (!raycasthit) 
        {
            return;
        }


        var offset =  hitData.distance -yHalfExtents;

        transform.position = new Vector3(transform.position.x, transform.position.y -offset, transform.position.z);

    }


    private IEnumerator RotateAndWait(float angle, int axis)
    {
        isRotating = true;
        if (axis == 1)
        {
            transform.Rotate(0.0f, 0.0f, angle, Space.World);
        }
        else if (axis == 2)
        {
            transform.Rotate(angle, 0.0f, 0.0f, Space.World);
        }

        /*
        //get the extents
        var yHalfExtents = col.bounds.extents.y;
        //get the center
        var yCenter = col.bounds.center.y;
        //get the up border
        //get the lower border
        float yLower = transform.position.y - yHalfExtents;


        Debug.Log("Lower border: " + yLower);


        


        /*
        if (transform.position.y -(transform.position.y- yLower) > 0.1f  )
        {
            Debug.Log(yUpper);


            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        }
        else if( yLower < 1f)
        {
            transform.position = new Vector3(transform.position.x, Math.Abs(0.5f + transform.position.y ), transform.position.z);

        }
        */

        yield return new WaitForSeconds(1f);
        isRotating = false;

    }

  
    
   
}
