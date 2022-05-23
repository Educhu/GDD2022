using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonT : MonoBehaviour
{
    public bool itsPushed = false;

    public AudioSource playerAudio;
    public AudioClip buttonSound;
    

    public Sprite buttonSpriteOn;
    public Sprite buttonSpriteOff;
    public Sprite buttonImg;

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
        if (collision.gameObject.tag == "Player")
        {
            if (itsPushed == false)
            {
                playerAudio.PlayOneShot(buttonSound);
                Debug.Log("imagem 1");
                //buttonImg = buttonSpriteOn;
            }
            itsPushed = true;
            GameObject.FindGameObjectWithTag("PuzzleButtonsManager")
            .GetComponent<PuzzleButtonManager>()
                .ButtonPushed(gameObject);
        }
    }
}
