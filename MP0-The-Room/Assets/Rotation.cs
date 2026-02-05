using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 10f;
    public SphereCollider sphere;
    void Start()
    {

        sphere = GetComponent<SphereCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
