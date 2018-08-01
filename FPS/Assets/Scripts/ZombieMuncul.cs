using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMuncul : MonoBehaviour {

    [SerializeField]
    private GameObject zombie;
    private GameObject player;
    GameObject[] monsters;
    float timer = 0;

    // Use this for initialization
    private void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 3f)//Memunculkan monster dilakukan setiap 3 detik
        {
            //Memastikan Zombie muncul di area Terrain yang luasnya 500 x 500. Dan memastikan jarak minimal player dengan zombie adalah 100.
            Vector3 posRecomended;
            do
            {
                posRecomended = new Vector3(Random.Range(0, 500), 5, Random.Range(0, 500));
            } while (Vector3.Distance(posRecomended, player.transform.position) < 50f);
            Instantiate(zombie, posRecomended, Quaternion.identity);
            timer = 0;
        }
    }
}
