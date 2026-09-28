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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            Rigidbody.AddForce(new Vector3(0,jumpforce,0));
            jump = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rigidbody.AddForce(new Vector3(-speed,0,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rigidbody.AddForce(new Vector3(speed,0,0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            Rigidbody.AddForce(new Vector3(0,0,speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.AddForce(new Vector3(0,0,-speed));
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
    
