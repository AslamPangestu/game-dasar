using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour {

    //float timer = 0;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Data.score < 0)
        {
            Data.score = 0;//reset score
            //SceneManager.LoadScene("GameOver", LoadSceneMode.Single);//load scene gameplay
        }
        /*timer += Time.deltaTime;//berdasarkan waktu jeda yang telah ditentukan
        if (timer > 2)//jika timer > 2
        {
            Data.score = 0;//reset score
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);//load scene gameplay

        }*/
    }
}
