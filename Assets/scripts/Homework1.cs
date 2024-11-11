using System.Collections;
using UnityEngine;

public class hom_1 : MonoBehaviour
{
    public Vector3 Center;
    public float Radius;
    public int counter = 0;
    GameObject obj;
    private bool creating = false;
    public int limit = 7;

    public void Start()
    {
        GameObject obj = new GameObject();

        InitCircle(Center, Radius);
    }

    public void InitCircle(Vector3 center, float radius)
    {
        Center = center;
        Radius = radius;
        
    
}


    private void Update()
    {
        if (!creating && counter < limit)
        {
            StartCoroutine(delay(Center, Radius));

        }
    }

    private IEnumerator delay(Vector3 center, float radius)
    {

        creating = true;

        float angle = Random.Range(0f, Mathf.PI * 2);

        float distance = Mathf.Sqrt(Random.Range(0f, 1f)) * Radius;

        float x = distance * Mathf.Cos(angle);
        float y = distance * Mathf.Sin(angle);

        int type = Random.Range(0, 3);

        if (type == 0)
        {
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        else if (type == 1)
        {
            obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
        else if (type == 2)
        {
            obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        }


        obj.transform.position = new Vector3(x, obj.transform.position.y, y );
        obj.AddComponent<oscillate>();

        counter++;
        obj.transform.LookAt(Center);

        yield return new WaitForSeconds(1f);
        creating = false;

    }
}
