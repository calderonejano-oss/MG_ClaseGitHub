using UnityEngine;

public class item : MonoBehaviour
{
    public player player;
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
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            player = other.GetComponent<player>();
            player.puntajemonedas();
        }
    }

}
