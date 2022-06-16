using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlausController : MonoBehaviour
{
    //public GameObject klaus;
    //public GameObject player;

    private bool isKlausMoving = false;

    //private Vector3 klausDestinationPosition;

    // Start is called before the first frame update
    void Start()
    {
        //klausDestinationPosition = new Vector3(player.transform.position.x, player.transform.position.y - 5, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //public void KlausMoving()
    //{
    //    if(isKlausMoving)
    //    {
    //        if (klaus.transform.position != klausDestinationPosition)
    //        {
    //            Debug.Log("klaus está indo");

    //            klaus.transform.Translate(Vector3.up * Time.deltaTime);
    //        }
    //        else
    //        {
    //            isKlausMoving = false;
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isKlausMoving = true;
        }
    }
}
