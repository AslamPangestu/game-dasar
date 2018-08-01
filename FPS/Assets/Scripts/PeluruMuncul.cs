using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PeluruMuncul : MonoBehaviour {

    public Rigidbody peluru;//Menyimpan variabel prefabs peluru
    [Range(0, 100)]//junlah peluru keluar
    public float speed = 75;//kecepatan peluru

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))//Merespon setiap melakukan klik kiri pada mouse
        {
            Rigidbody peluruBaru = (Rigidbody)GameObject.Instantiate(peluru, transform.position, transform.rotation);//Menciptakan peluru/bullet dengan posisi tepat didepan posisi pistol
            peluruBaru.velocity = transform.TransformDirection(Vector3.up * speed);//Melontarkan peluru kearah sumbu Y dengan kecepatan yang telah ditentukan
            Physics.IgnoreCollision(peluruBaru.GetComponent<SphereCollider>(), GameObject.Find("RigidBodyFPSController").GetComponent<CapsuleCollider>());//Berfungsi untuk memberi batasan ketika object peluru terkena Player maka peluru tidak meledak.
        }
    }
}
