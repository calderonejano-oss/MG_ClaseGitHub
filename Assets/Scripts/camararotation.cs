using UnityEngine;

public class camararotation : MonoBehaviour
{
    public float velocidadX = 200f;
    public float velocidadY = 200f;

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        rotacionX += Input.GetAxis("Mouse X") * velocidadX * Time.deltaTime;
        rotacionY -= Input.GetAxis("Mouse Y") * velocidadY * Time.deltaTime;


        rotacionY = Mathf.Clamp(rotacionY, -20f, 60f);

        transform.localRotation = Quaternion.Euler(rotacionY, rotacionX, 0f);
    }
}