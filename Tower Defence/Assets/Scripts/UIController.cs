using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {

    public Slider slide;
    public Text coin;
    public Text time;
    float countdown = 90;//batas waktu permainan
    float timer = 0;
    // Use this for initialization
    void Start()
    {
        Data.coin = 0;//set data coin jadi 0
        time.text = "01:30";//set waktu
    }
    // Update is called once per frame
    void Update()
    {
        if (Data.coin < 800)//max koin == 800
        {
            Data.coin += 50 * Time.deltaTime;///detik bertambah 50
            slide.value = Data.coin;//merubah di slider
            coin.text = Data.coin.ToString("000");//menampilkan pada string
        }
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0;
            if (countdown > 0)
            {
                countdown--;
                string minutes = Mathf.Floor(countdown / 60).ToString("00");
                string seconds = Mathf.Floor(countdown % 60).ToString("00");
                time.text = minutes + ":" + seconds;
            }
            else
            {
                Data.isGameOver = true;
                Data.isComplate = false;
            }
        }
    }
}
