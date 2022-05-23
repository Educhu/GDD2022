using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonO : MonoBehaviour
{
    public bool itsPushed = false;
    public int buttonIndex;

    public Sprite buttonSpriteOn;
    public Sprite buttonSpriteOff;


    // Start is called before the first frame update
    void Start()
    {
        //bot�o � pressionado
        //ele � o numero 0?
        //se sim: tocar som de certo e manter pressionado;
        //se n�o: tocar som de errado;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            itsPushed = true;

            GameObject.FindGameObjectWithTag("OrdenedButtonsManager")
                .GetComponent<OrderedButtonsManager>().PushButton(gameObject);
        }
    }
}
