using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public bool isRecovering = false; 
    public float speed;

    public float timerFonte = 0.0f;
    public float timerPotion = 0.0f;



    // Update is called once per frame
    void Update()
    {
        Movimentacao();

        SpringRecovering();
    }

    void Movimentacao()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("speed", movement.magnitude);

        if (Input.GetKey(KeyCode.Space))
        {
            float speedAux = speed * 2;
            
            transform.position = transform.position + movement * speedAux * Time.deltaTime;    
        }
        else
        {
            transform.position = transform.position + movement * speed * Time.deltaTime;
        }
    }

    private void SpringRecovering()
    {
        if (isRecovering == true && LifeSystem.Life >= 0.1f)
        {
            timerFonte += Time.deltaTime;
            timerPotion += Time.deltaTime;

            if (timerPotion >= 0.3f && LifeSystem.Potion < 9)
            {
                LifeSystem.AddPotion(1);

                LifeSystem.Instance.ReloadPotion();

                timerPotion -= timerPotion;
            }


            if (timerFonte >= 0.05f)
            {
                LifeSystem.Instance.IncreaseLife(0.02f);

                timerFonte -= timerFonte;
            }
            //animação.
        }
        else if (LifeSystem.Life > 1)
        {
            LifeSystem.Instance.LifeIsFull();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fonte")
        {
            isRecovering = true;
        }

        if (collision.gameObject.tag == "KlausInteraction")
        {
            InteractionManager.InstanciaKlaus();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fonte")
        {
            isRecovering = false;
        }
    }
}
