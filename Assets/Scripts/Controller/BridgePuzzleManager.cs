using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePuzzleManager : MonoBehaviour
{
    public float timerButton = 0.0f;
    public List<GameObject> bridges;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        timerButton += Time.deltaTime;
        if (timerButton >= 05.00f)
        {
            foreach (GameObject ponte in bridges)
            {
                ponte.SetActive(false);
            }
        }
        if(timerButton >= 10.00f)
        {
            foreach (GameObject ponte in bridges)
            {
                ponte.SetActive(true);
            }
            timerButton -= timerButton;
        }
    }
}
