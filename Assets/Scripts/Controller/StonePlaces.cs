using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlaces : MonoBehaviour
{
    public bool itsPushed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            itsPushed = true;

            GameObject.FindGameObjectWithTag("StonePuzzleManager").GetComponent<StonePuzzleManager>()
           .OnPressPlace(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            itsPushed = false;

            GameObject.FindGameObjectWithTag("StonePuzzleManager").GetComponent<StonePuzzleManager>()
            .OnPullPlace(gameObject);
        }
    }
}
