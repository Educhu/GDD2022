using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtonManager : MonoBehaviour
{
    private bool startedTimer = false;
    public float timerButton = 0.0f;

    public List<GameObject> buttons = new List<GameObject>();

    public AudioSource playerAudio;
    public AudioClip doorOpening;
    public AudioClip buttonReset;

    public bool doorOpened = false;


    // Update is called once per frame
    void Update()
    {
        TimerManager();

        //voltar o botão(audio)
    }

    public void TimerManager()
    {
        if (startedTimer && !doorOpened)
        {
            timerButton += Time.deltaTime;
            if (timerButton >= 05.00f)
            {
                try
                {
                    foreach (GameObject _button in buttons)
                    {
                        _button.GetComponent<ButtonT>().itsPushed = false;
                        buttons.RemoveAll(b => b.gameObject);
                        playerAudio.PlayOneShot(buttonReset);
                    }
                }
                catch (Exception)
                {
                    Debug.Log("a coleção foi alterada");
                }


                startedTimer = false;
                timerButton -= timerButton;
            }

            if (buttons.Count == 3 && doorOpened == false)
            {
                Debug.Log("A Porta Abriu");
                playerAudio.PlayOneShot(doorOpening);
                doorOpened = true;
            }
        }
    }

    public void ButtonPushed(GameObject button)
    {
        if(!buttons.Contains(button))
        {
            buttons.Add(button);
        }

        startedTimer = true;
    }
}
