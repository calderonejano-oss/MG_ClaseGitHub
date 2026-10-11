using UnityEngine;

public enum tipodepoder {Power_UP_Agua,Power_UP_Viento,Power_UP_Tierra}

public class PowerUP : MonoBehaviour
{
    public tipodepoder tipodepoder;
    public Power_UP_Habiliti power_UP_Habiliti;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        power_UP_Habiliti = other.GetComponent<Power_UP_Habiliti>();
        if (other.CompareTag("Player"))
        {
            if(power_UP_Habiliti != null)
            {
                
                switch (tipodepoder)
                {
                    case tipodepoder.Power_UP_Viento:
                        power_UP_Habiliti.PowerViento();
                        break;
                    case tipodepoder.Power_UP_Tierra:
                        power_UP_Habiliti.PowerTierra();
                        break;
                    case tipodepoder.Power_UP_Agua:
                        power_UP_Habiliti.PowerAgua();
                        break;
                }
            }
        }
        Destroy(gameObject);
    }
}
