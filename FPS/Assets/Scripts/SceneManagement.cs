using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour {

    public void GameScene()
    {
        
        Data.score = 0;
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    
}
