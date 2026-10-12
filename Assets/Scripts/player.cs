using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    [Header("Rg & Cam")]
    public Rigidbody Rigidbody;
    public Transform camareTransform;

    [Header("Moneda")]
    public float puntajedemonedas;

    [Header("jump")]
    public float jumpforce;
    public bool jump;

    [Header("speed & sprint")]
    public float sprint;
    public float speed;
    public float speedactual;

    [Header("Multiplicadores de Velocidad")]
    [Range(0f, 1f)] public float modificadorLados;  
    [Range(0f, 1f)] public float modificadorAtras;  
    [Range(0f, 1f)] public float modificadorSaltoAire; 

    [Header("Direcciones")]
    private float direccionX;
    private float direccionZ;

    [Header("canva")]
    public TextMeshProUGUI puntajetext;
    public float monedastotalparaganar;
    public GameObject canvavictoria;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        canvavictoria.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            Rigidbody.AddForce(new Vector3(0,jumpforce,0),ForceMode.Impulse);
            jump = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedactual = sprint;
        }
        else speedactual = speed;

        Vector3 camRotation = camareTransform.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, camRotation.y, 0f);

        direccionX= Input.GetAxis("Horizontal");
        direccionZ= Input.GetAxis("Vertical");

    }
    void FixedUpdate()
    {
        float velocidadFinalX = direccionX * speedactual;
        float velocidadFinalZ = direccionZ * speedactual;

        if (direccionZ < 0)
        {
            velocidadFinalZ *= modificadorAtras;
        }

        if (direccionX != 0)
        {
            velocidadFinalX *= modificadorLados;

            // Si además de ir de costado está EN EL AIRE (saltando), reducimos la velocidad lateral aún más
            if (!jump)
            {
                velocidadFinalX *= modificadorSaltoAire;
            }
        }

        Vector3 movimientoLocal = (transform.forward * velocidadFinalZ) + (transform.right * velocidadFinalX);
        Rigidbody.linearVelocity = new Vector3(movimientoLocal.x, Rigidbody.linearVelocity.y, movimientoLocal.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("colision_suelo"))
        {
            jump = true;
        }
    }
    public void puntajemonedas()
    {
        puntajedemonedas++;
        puntajetext.text = "Monedas Recolectadas: \n"+puntajedemonedas;
        if(puntajedemonedas == monedastotalparaganar)
        {
            canvavictoria.SetActive(true);
            Time.timeScale=0;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
    
