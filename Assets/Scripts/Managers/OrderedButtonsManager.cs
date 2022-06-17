using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderedButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;
    public int index = 0;
    public bool doorOpened = false;

    public AudioSource playerAudio;
    public AudioClip wrongSound;
    public AudioClip rightSound;
    public AudioClip puzzlePassSound;

    public GameObject porta;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushButton(GameObject button)
    {
        if(button.GetComponent<ButtonO>().buttonIndex == index)
        {
            index ++;
            buttons.Add(button);

            if(buttons.Count < 5)
            {
                playerAudio.PlayOneShot(rightSound);
            }
            else if (buttons.Count >= 5 && doorOpened == false)
            {
                playerAudio.PlayOneShot(puzzlePassSound);
                doorOpened = true;
                Debug.Log("A porta se abriu");
                Destroy(porta);
            }
        }
        else if(button.GetComponent<ButtonO>().buttonIndex > index)
        {
            playerAudio.PlayOneShot(wrongSound);
            index = 0;
            foreach(GameObject _button in buttons)
            {
                _button.GetComponent<ButtonO>().itsPushed = false;
            }

            buttons.RemoveAll(gO => gO);
        }
    }
}
