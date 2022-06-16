using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePuzzleManager : MonoBehaviour
{
    public List<GameObject> buttons;
    public bool doorOpened = false;

    public AudioSource playerAudio;
    public AudioClip clickPlace;
    public AudioClip unClickPlace;
    public AudioClip puzzleCompleteSound;

    // Start is called before the first frame update
    void Start()
    {
        //se todos os 4 estiverem its pushed, então a porta se abre;
        //buttons.Add(button);
    }

    // Update is called once per frame
    void Update()
    {
        if(buttons.Count == 4 && doorOpened == false)
        {
            Debug.Log("A porta Abriu");
            playerAudio.PlayOneShot(puzzleCompleteSound);
            doorOpened = true;
        }
    }

    public void OnPressPlace(GameObject button)
    {
        if (buttons.Count < 4)
        {
            buttons.Add(button);
            playerAudio.PlayOneShot(clickPlace);
        }
    }

    public void OnPullPlace(GameObject button)
    {
        buttons.Remove(button);
        playerAudio.PlayOneShot(unClickPlace);
    }
}
