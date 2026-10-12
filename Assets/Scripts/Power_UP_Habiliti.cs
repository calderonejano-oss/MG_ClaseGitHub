using UnityEngine;
using System.Collections;

public class Power_UP_Habiliti : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Transform camara;
    public Transform orientacion;
    public player player;

    [Header("Power UP Viento")]
    public bool powerUP_Viento;
    public float dashForce;
    public float dashDuration;
    public KeyCode dashinput = KeyCode.Alpha1;

    [Header("Power UP Tierra")]
    public bool powerUP_Tierra;
    public GameObject prefabPilar;     
    public float alturaMaximaPilar; 
    public float velocidadCrecimiento;
    public KeyCode pilarInput = KeyCode.Alpha2;
    private bool construyendoPilar = false;
    public bool pilarpoder = false;

    [Header("Power UP Agua")]
    public float forceimpulse;
    public bool powerUP_Agua;
    public bool habilitado;
    public KeyCode impulsoinput = KeyCode.Alpha3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody=GetComponent<Rigidbody>();
        player=GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(dashinput)&& powerUP_Viento == true)
        {
            dash();
        }
        if (Input.GetKeyDown(pilarInput) && powerUP_Tierra == true && !construyendoPilar && pilarpoder == true)
        {
            InvocarPilarTierra();
            pilarpoder = false;
        }
        if(Input.GetKeyDown(impulsoinput) && powerUP_Agua == true && habilitado == true)
        {
            impulso_de_agua();
            habilitado = false;
        }
    }

    public void PowerViento()
    {
        powerUP_Viento = true;
        Debug.Log("¡Poder de viento conseguido!");
    }
    void dash()
    {
        Vector3 forcetoaply = orientacion.forward * dashForce;
        Rigidbody.AddForce(forcetoaply, ForceMode.Impulse);
        Invoke(nameof(resetdash), dashDuration);
    }
    void resetdash()
    {
        
    }

    public void PowerTierra()
    {
        powerUP_Tierra = true;
        pilarpoder = true;
        Debug.Log("¡Poder de tierra conseguido!");
    }
    void InvocarPilarTierra()
    {
        StartCoroutine(CrearPilarCorrutina());
    }
    IEnumerator CrearPilarCorrutina()
    {
        construyendoPilar = true;
        if (player != null) player.enabled = false;
        Vector3 posSuelo = transform.position;
        float alturaPilar = 8f;
        Vector3 posInicial = posSuelo - new Vector3(0, alturaPilar, 0);
        Vector3 posFinal = posSuelo;
        GameObject nuevoPilar = Instantiate(prefabPilar, posInicial, Quaternion.identity);
        while (nuevoPilar.transform.position.y < posFinal.y)
        {
            float paso = velocidadCrecimiento * Time.deltaTime;
            nuevoPilar.transform.position = Vector3.MoveTowards(nuevoPilar.transform.position, posFinal, paso);
            transform.position = new Vector3(posSuelo.x, nuevoPilar.transform.position.y + alturaPilar, posSuelo.z);
            yield return null;
        }
        construyendoPilar = false; 
        if (player != null) player.enabled = true;
    }
    public void PowerAgua()
    {
        powerUP_Agua = true;
        habilitado = true;
        Debug.Log("¡Poder de agua conseguido!");
    }
    void impulso_de_agua()
    {
        Rigidbody.AddForce(new Vector3(0,forceimpulse,0),ForceMode.Impulse);
    }
}
