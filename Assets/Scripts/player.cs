using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

public class player : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float speed;
    public float jumpforce;
    public bool jump;
    public Transform camareTransform;
    public float speedrotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            Rigidbody.AddForce(new Vector3(0,jumpforce,0));
            jump = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rigidbody.AddForce(new Vector3(-speed * Time.fixedDeltaTime,0,0), ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rigidbody.AddForce(new Vector3(speed* Time.fixedDeltaTime,0,0), ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Rigidbody.AddForce(new Vector3(0,0,speed* Time.fixedDeltaTime), ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.AddForce(new Vector3(0,0,-speed* Time.fixedDeltaTime), ForceMode.VelocityChange);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("colision_suelo"))
        {
            jump = true;
        }
    }
}
    
