using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPindah : MonoBehaviour {

    float speed = 3f; //variabel kecepatan
    public Sprite[] sprites; //variabel untuk menyimpan objek
    
    // Vector3 untuk menyimpan X,Y,Z
    private Vector3 screenPoint; //variabel untuk menyimpan nilai posisi objek terhadap screen
    private Vector3 offset;//variable utk menyimpan selisih posisi object dengan posisi mouse
    private float firstY;//variable untuk menyimpan posis untuk mengembalikan ke posisi semula 

    // Use this for initialization
    void Start ()
    {
        int index = Random.Range(0, sprites.Length);//membuat angka random dari 0 - batas jumlah sprite sampah
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];//mengambil komponen sprite sampah dimasukkan kedalam array
    }
	
	// Update is called once per frame
	void Update ()
    {
        //bergerak sesuai arah eskalator dengan menambahkan 
        float move = (speed * Time.deltaTime * -1f) + transform.position.x;//Menggerakkan objek ke kiri berdasarkan sumbu x
        transform.position = new Vector3(move, transform.position.y);//mengimplementasikan pergerakan horizontal
    }

    void OnMouseDown()//Saat mouse diklik
    {
        //inisialisasi terhadap Gameobject dan mouse yang nanti nilai tersebut akan digunakan untuk menggeser Gameobject tersebut
        firstY = transform.position.y;//variabel menyimpan vector y
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);//variabel menyimpan nilai vector dari object
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()//Saat mouse didrag
    {
        //melakukan pemindahan posisi Gameobject berdasarkan posisi mouse
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
    private void OnMouseUp()//Saat mouse dilepas
    {
        //mengembalikan posisi pada Gameobject ke posisi awal
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z);
    }
}
