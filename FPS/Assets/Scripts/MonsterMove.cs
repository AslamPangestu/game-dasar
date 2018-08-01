using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    GameObject player;
    Animator animator;

    public SceneManagement endScene;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");//memanggil GameObject Player dari nama Tag 
        animator = gameObject.GetComponent<Animator>();//Memanggil komponen Animator yang akan digunakan untuk mengatur animasi Zombie
    }
	
	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MatiAnim")) // mengetahui selesainya animasi
        {//Jika Zombie menjalankan animasi Mati maka skor player ditambah dan Zombie dihilangkan.
            Data.score++;
            Destroy(gameObject);
        }
        else//Jika zombie tidak menjalankan animasi mati, maka zombie mengarah ke Player dan Zombie bergerak sejauh 20 setiap detiknya.
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * Time.deltaTime * 20f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))//jika zombie mengenai player
        {
            
            SceneManager.LoadScene("gameover");
        }
        if (collision.gameObject.tag.Equals("Peluru"))//jika peluru mengenai zombie
        {
            animator.SetBool("tertembak", true);
        }
    }
}
