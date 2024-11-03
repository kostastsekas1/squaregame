using System.Collections;
using UnityEngine;

public class newmove : MonoBehaviour
{
    private bool isRotating = false;

    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                StartCoroutine(RotateAndMove(90.0f, Vector3.right * 1.5f));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                StartCoroutine(RotateAndMove(-90.0f, Vector3.left * 1.5f));
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                StartCoroutine(RotateAndMove(90.0f, Vector3.forward * 1.5f));
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                StartCoroutine(RotateAndMove(90.0f, Vector3.back * 1.5f));
            }
        }
    }

    private IEnumerator RotateAndMove(float angle, Vector3 direction)
    {
        isRotating = true;

        // Rotate around the appropriate axis
        if (direction == Vector3.right || direction == Vector3.left)
        {
            transform.Rotate(0.0f, 0.0f, angle, Space.World);
        }
        else
        {
            transform.Rotate(angle, 0.0f, 0.0f, Space.World);
        }

        // Move in the specified direction while adjusting y position to keep the object grounded
        transform.position += direction;
        AdjustYPosition();

        yield return new WaitForSeconds(1f);
        isRotating = false;
    }

    private void AdjustYPosition()
    {
        Vector3 position = transform.position;

        // Set y to 0 or 0.5 based on rotation
        if (Mathf.Abs(transform.eulerAngles.x % 180) > 0.01f || Mathf.Abs(transform.eulerAngles.z % 180) > 0.01f)
        {
            position.y = 0.5f;  // Grounded position when rotated 90 or 270 degrees
        }
        else
        {
            position.y = 0;      // Grounded position when not rotated or at 180 degrees
        }

        transform.position = position;
    }
}
