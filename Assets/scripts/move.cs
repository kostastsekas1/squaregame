using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
       */
        if (!isRotating)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                StartCoroutine(RotateAndWait(90.0f));
                //CharacterController. += transform.localScale.z;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                StartCoroutine(RotateAndWait(-90.0f));
            }
        }


    }
    private bool isRotating = false;


    private IEnumerator RotateAndWait(float angle)
    {
        isRotating = true;
        transform.Rotate(0.0f, 0.0f, angle, Space.World);
        //transform.position.z += transform.localScale.z;
        yield return new WaitForSeconds(1f);
        isRotating = false;
    }
}
