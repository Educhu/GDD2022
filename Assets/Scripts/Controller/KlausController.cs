using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlausController : MonoBehaviour
{
    public GameObject Klaus;
    public GameObject Player;

    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KlausMoving()
    {
        if(moving == true)
        {
            //klaus.position == player. position
            //mandar o klaus até o player;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = true;
        }
    }
}
