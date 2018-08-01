using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    public bool isPlayer = true; //cek apakah dia player
    private bool isMove = true; //cek apakah seda bergerak
    public int attact = 100; //poin serangan
    public int defense = 200; //poin bertahan

    [HideInInspector] // tidak ditampilkan dalam insceptor
    public int underAttact; //untuk seberapa besar kekurangan serangan yang diterimanya
    private float timer = 0; //waktu
    private float posYLawan; //menyimpan posisi vertikal
    private bool isCari = false; //cek lawan dalam area trigger
    private string nameTagLawan; //memberi tag
    
    // Use this for initialization
    void Start()//memberi nilai tag pada object
    {
        if (isPlayer)
        {
            nameTagLawan = "Enemy";
        }
        else
        {
            nameTagLawan = "Player";
        }
    }

    // Update is called once per frame
    void FixedUpdate()//memproses code berulang
    {
        if (isPlayer)//cek apakah dia player
        {
            if (isMove)//jika bergerak
            {
                transform.position += transform.right * Time.deltaTime * 0.5f;//menggerakkan objek sejauh 0.5/detik
                //menyamai posisi player dengan lawan(saat lawan dalam area trigger)
                if (transform.position.y > (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYLawan - 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }
            }
            else//jika diam
            {
                // attact
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    defense -= underAttact;
                    transform.localScale = new Vector3(1, 1f);
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(1, 1.2f);
                }
            }
        }
        else//cek bukan player
        {
            if (isMove)//jika bergerak
            {
                transform.position -= transform.right * Time.deltaTime * 0.5f;//menggerakkan objek sejauh 0.5/detik
                //menyamai posisi player dengan lawan(saat lawan dalam area trigger)
                if (transform.position.y > (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYLawan - 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }
            }
            else//jika diam
            {
                // attact
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    defense -= underAttact;
                    transform.localScale = new Vector3(1, 1f);
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(1, 1.2f);
                }
            }
        }
        if (defense <= 0)//jika defens == 0. objek dihancurkan
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 9 || transform.position.x < -9)//jika objek berada di luar area maka akan dihilangkan
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)//saat terkena colider
    {
        if (collision.transform.tag.Equals(nameTagLawan) && isMove)//jika objek bersentuhan dgn objek lawan dan dlm keadaan bergerak
        {
            isMove = false;//diubah jadi diam
            Attacker m = collision.gameObject.GetComponent<Attacker>();
            if (m != null) m.underAttact = attact;
            Defender d = collision.gameObject.GetComponent<Defender>();
            if (d != null) d.underAttact = attact;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals(nameTagLawan))//jika objek lawan dlm area trigger
        {
            isCari = true;//melakukan pencarian
            posYLawan = collision.transform.position.y;//merubah posisi
        }
    }
    public void OnCollisionExit2D(Collision2D collision)//jika sudah tidak bersentuhan
    {
        isMove = true;//objek jalan
        transform.localScale = new Vector3(1, 1f);//kembail ke posisi awal
    }
}
