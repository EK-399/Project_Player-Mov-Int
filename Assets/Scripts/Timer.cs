using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Start at 60, count down
    //
    public bool startTimer = true;
    public float MaxTimeInSeconds = 60f;
    
    float timer;
    TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        timer = MaxTimeInSeconds; //Star our timer at 60
    }

    // Update is called once per frame
    private void Update()
    {
        if(startTimer == true)
        {
            FormatTimer();
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                startTimer = false;

                EndTime();
            }
        }
    }

        void FormatTimer()
    {
        int min = Mathf.FloorToInt(timer / 60);
        int sec = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void EndTime()
    {
        //Do the thing!
    }
}
