using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDestroy : MonoBehaviour {

    public bool isPlayer = true;//cek player
    private void OnDestroy()//ketika hancur
    {
        if (!Data.isGameOver)//dijalankan saat game blm selesai
            if (isPlayer)//jika yg hancur tower player
            {
                Data.isGameOver = true;
                Data.isComplate = false;
                Debug.Log("Player Lost");
            }
            else//jika yg hancur tower enemy
            {
                Data.isGameOver = true;
                Data.isComplate = true;
                Debug.Log("Player Win");
            }
    }
}
