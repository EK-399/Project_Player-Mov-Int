using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Start at 60, count down
    //
    public float maxtime = 60f;
    float timer;

    TextMeshProUGUI timerText;

    public bool startTimer;
    public GameObject gameOverScreen;

    void Start()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        timer = maxtime; //Star our timer at 60
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer == true)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString(); 

            if (timer < 0)
            {
                startTimer = false;
                gameOverScreen.SetActive(true);

                timer = 0;
                timerText.text = timer.ToString();

                Timer.timeScale = 0f;
            }
        }
    }
}
