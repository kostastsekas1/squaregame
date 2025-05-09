using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool isRotating = false;
    public BoxCollider col;
    private bool isstanding = true;
    private int dir = 0;

    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                CheckDirection(2);
                MoveCube(true, 1);

                StartCoroutine(RotateAndWait(90.0f, 1));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {

                CheckDirection(2);
                MoveCube(true, -1);

                StartCoroutine(RotateAndWait(-90.0f, 1));
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                CheckDirection(1);
                MoveCube(false, 1);

                StartCoroutine(RotateAndWait(90.0f, 2));

            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                CheckDirection(1);
                MoveCube(false, -1);

                StartCoroutine(RotateAndWait(90.0f, 2));
            }
        }

        float yHalfExtents = col.bounds.extents.y;
        Ray ray = new Ray(transform.position, Vector3.down);
        bool raycasthit = Physics.Raycast(ray, out RaycastHit hitData, 30);
        
        if (!raycasthit)
        {
            return;
        }

        float offset = hitData.distance - yHalfExtents;
        transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);

        float GroundHeight = Mathf.Round(hitData.point.y * 10000f) / 10000f;
        if (transform.position.y > GroundHeight + 0.6f)
        {
            isstanding = true;
        }
        else
        {
            isstanding = false;
        }
    }
    private void MoveCube(bool movingleftright, int sign)
    {
        if (movingleftright)
        {
            if (dir == 0 || dir == 2)
            {
                transform.position = new Vector3(transform.position.x + sign * 1.5f, transform.position.y, transform.position.z);
            }
            else if (dir == 1)
            {
                transform.position = new Vector3(transform.position.x + sign * 1f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (dir == 0 || dir == 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sign * 1.5f);
            }
            else if (dir == 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sign * 1f);
            }
        }
    }

    private void CheckDirection(int dircheck)
    {
        if (isstanding == true && dir == 0)
        {
            dir = dircheck;
        }
        else if (isstanding == false && dir == dircheck)
        {
            dir = 0;
        }
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