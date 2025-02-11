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
    private int dir;  // 0 for x axis  1 for y axis
    private float movedistance =1.5f;	
    void Update()
    {
        if (!isRotating)
        {
           
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
		if(transform.position.y ==0.5f && dir== 0){
			movedistance = 1.5f;
		}else if (transform.position.y ==0.5f && dir== 1){
			movedistance = 1f;
		}

		transform.position = new Vector3(transform.position.x + movedistance, transform.position.y, transform.position.z);
                StartCoroutine(RotateAndWait(90.0f, 1));

		dir=0;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {

		if(transform.position.y ==0.5f && dir== 0){
			movedistance = 1.5f;
		}else if (transform.position.y ==0.5f && dir== 1){
			movedistance = 1f;
		}

                transform.position = new Vector3(transform.position.x - movedistance, transform.position.y, transform.position.z);

                StartCoroutine(RotateAndWait(-90.0f, 1));
		dir=0;
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
		if(transform.position.y ==0.5f && dir== 1){
			movedistance = 1.5f;
		}else if (transform.position.y ==0.5f && dir== 0){
			movedistance = 1f;
		}
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movedistance);
                StartCoroutine(RotateAndWait(90.0f, 2));
		dir=1;

            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
		
		if(transform.position.y ==0.5f && dir== 1){
			movedistance = 1.5f;
		}else if (transform.position.y ==0.5f && dir== 0){
			movedistance = 1f;
		}

                StartCoroutine(RotateAndWait(90.0f, 2));
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - movedistance);
		dir=1;
            }
        }

        var yHalfExtents = col.bounds.extents.y;
        //get the center
        var yCenter = col.bounds.center.y;

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

        yield return new WaitForSeconds(1f);
        isRotating = false;

    }
}
