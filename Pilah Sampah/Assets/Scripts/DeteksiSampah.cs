using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;//import liblary UI dri unityEngine
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeteksiSampah : MonoBehaviour {

    public string nameTag;//menyimpan string namaTag yang nanti akan digunakan untuk filter gameobject apa saja yang akan di proses.

    //resources audio yang nanti diperoleh dari file audio yang terdapat di Panel Project.
    public AudioClip audioBenar;
    public AudioClip audioSalah;

    //control audio baik itu untuk play, loop, pause dan stop
    private AudioSource MediaPlayerBenar;
    private AudioSource MediaPlayerSalah;

    public SceneManagement endScene;

    public Text textScore;//menampilkan score yang telah didapat dan pastikan sudah menambah library using UnityEngine.UI

    // Use this for initialization
    private void Start ()
    {
        //mendeklarasikan audio pada Control Audio supaya dapat dimodifikasi
        MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
        MediaPlayerBenar.clip = audioBenar;

        MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
        MediaPlayerSalah.clip = audioSalah;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))//Jika tag object yang masuk ke area Trigger adalah sesuai dengan namaTag,
        {
            Data.score += 25;//tambah score
            textScore.text = Data.score.ToString();//tampilkan score
            Destroy(collision.gameObject);//hancurkan objek
            MediaPlayerBenar.Play();//audio benar keluar
        }
        else//jika tag salah
        {
            if(Data.score > 0)
            {
                Data.score -= 5;//kurangi skor
                textScore.text = Data.score.ToString();//tampilkan skore
                Destroy(collision.gameObject);//hancurkan objek
                MediaPlayerSalah.Play();//keluar audio salah
            }
            else
            {
                Destroy(collision.gameObject);
                endScene.GameOver();
            }
        }
    }
}
