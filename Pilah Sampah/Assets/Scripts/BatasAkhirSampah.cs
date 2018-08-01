using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BatasAkhirSampah : MonoBehaviour {
    public SceneManagement endScene;

    private void OnTriggerEnter2D(Collider2D collision)//saat triger collider terkena
    {
        Data.score = 0;
        Destroy(collision.gameObject);//menghancurkan object
        endScene.GameOver();
    }
}
