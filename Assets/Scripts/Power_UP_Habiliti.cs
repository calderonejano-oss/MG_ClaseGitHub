using UnityEngine;

public class Power_UP_Habiliti : MonoBehaviour
{
    [Header("Power UP")]
    public bool powerUP_Viento;
    public bool powerUP_Tierra;
    public bool powerUP_Agua;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)&& powerUP_Viento == true)
        {
            
        }
    }
    public void PowerViento()
    {
        powerUP_Viento = true;
        Debug.Log("¡Poder de viento conseguido!");
    }
    public void PowerTierra()
    {
        powerUP_Tierra = true;
        Debug.Log("¡Poder de tierra conseguido!");
    }
    public void PowerAgua()
    {
        powerUP_Agua = true;
        Debug.Log("¡Poder de agua conseguido!");
    }
}
