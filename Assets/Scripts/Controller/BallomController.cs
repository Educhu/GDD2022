using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallomController : MonoBehaviour
{
    public List<string> falasDoKlaus;

    public TMP_Text speechText;

    private int index, linha = 0;

    private float animationTextTimer;
    private bool hasSpeechCompleted = false;
    private bool canPassTheSpeech = false; 

    public GameObject interactionManager;
    public GameObject mouseInteractImage;

    // Start is called before the first frame update
    void Start()
    {
        //uma sauda��o:
        falasDoKlaus.Add("hahaha esses monstros s�o muito fracos...");
        falasDoKlaus.Add("Ol� plebeu, meu nome � Klaus, nobre da casa Chagas");

        //contextualiza��o:
        falasDoKlaus.Add("O que um ral� como voc� faz aqui?");
        falasDoKlaus.Add("N�o sabia que era permitido plebeus no teste");
        falasDoKlaus.Add("pensei que s� membros da alta-roda conseguiam aprender magia");

        //desfecho final:
        falasDoKlaus.Add("Por que voc� n�o est� fala nada?");
        falasDoKlaus.Add("Est� insinuando que � superior a mim?");
        falasDoKlaus.Add("Vamos ver quem � superior aqui.");

        speechText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        animationTextTimer += Time.deltaTime;

        if(animationTextTimer >= 0.001f)
        {
            if(!hasSpeechCompleted)
            {
                if (!speechText.text.Equals(falasDoKlaus[linha]))
                {
                    speechText.text += falasDoKlaus[linha][index];
                    index++;
                }
                else
                {
                    if (linha == falasDoKlaus.Count - 1)
                    {
                        //as falas acabaram
                        hasSpeechCompleted = true;
                        
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        //acabou a linha
                        mouseInteractImage.SetActive(true);

                        canPassTheSpeech = true;
                    }
                }
            }
            animationTextTimer -= animationTextTimer;
        }
        if (Input.GetMouseButtonDown(0) && canPassTheSpeech)
        {
            mouseInteractImage.SetActive(false);
            speechText.text = "";
            linha++;
            index = 0;
            canPassTheSpeech = false;
        }
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("InteractionManager").GetComponent<InteractionManager>().StartKlausBattle();
    }
}
