using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculkanSampah : MonoBehaviour {

    public float jeda = 0.8f;// variabel untuk memberi jeda spawn sampah
    float timer;//variabel menyimpan waktu
    public GameObject[] obyekSampah;// array utk menyimpan objek sampah

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;//berdasarkan waktu jeda yang telah ditentukan
        if (timer > jeda)
        {
            int random = Random.Range(0, obyekSampah.Length);//menentukan index object sampah secara acak yang akan dimunculkan
            Instantiate(obyekSampah[random], transform.position, transform.rotation); //memunculkan object Sampah dari index yang telah ditentukan sebelumnya dengan posisi dan rotasi Gameoject yang terdapat Script ini
            timer = 0;// timer dikembalikan ke 0 untuk menghitung nilai jeda dari awal
        }
    }
}
