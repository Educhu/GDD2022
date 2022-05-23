using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public bool isRecovering = false; 
    public float speed;
    public static double vida;
    static public int potion = -1;

    public Image hpForeGround;

    public Sprite potionEmpty;
    public Sprite potionFull;

    public List<GameObject> BottleList;

    public float timerFonte = 0.0f;
    public float timerPotion = 0.0f;

    //
    private List<string> Falas = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        vida = 0.1f;
        //

        Falas.Add("oi");
        Falas.Add("Meu nome é klaus");
        Falas.Add("como ousa pisar em meu território plebeu?");

        var novaFala = Falas[1][0].ToString() + Falas[0][0].ToString() + Falas[2][6].ToString()
        + Falas[2][7].ToString() + Falas[1][1].ToString();

        Debug.Log(novaFala);
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        
        if(isRecovering == true && vida >= 0.1f)
        {
            timerFonte += Time.deltaTime;
            timerPotion += Time.deltaTime;

            if(timerPotion >= 0.3f && potion < 9)
            {
                potion += 1;

                ReloadPotion();

                timerPotion -= timerPotion;  
            }


            if (timerFonte >= 0.05f)
            {
                vida += 0.02f;

                timerFonte -= timerFonte;
            }
            //animação.
        }
        else if(vida > 1)
        {
            vida = 1;
        }

        hpForeGround.fillAmount = (float)PlayerController.vida;
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

    void ReloadPotion()
    {
       if(potion >= 0 && potion <= 9)
       {
            BottleList[potion].GetComponent<Image>().sprite = potionFull;
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fonte")
        {
            isRecovering = true;
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
