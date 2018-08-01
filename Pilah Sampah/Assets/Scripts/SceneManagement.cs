using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour {

    public void GameScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void KembaliScene()
    {
        SceneManager.LoadScene("Menu");
    }  
    
    public void Exit()
    {
        Application.Quit();//aplikasi keluar
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
