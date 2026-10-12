using UnityEngine;
using TMPro;

public class canva : MonoBehaviour
{
    public player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.puntajemonedas();
    }
}
