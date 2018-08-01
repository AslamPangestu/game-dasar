using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

    [HideInInspector]
    public Vector3 screenPoint;//menyimpan nilai posisi mouse
    [HideInInspector]
    public Vector3 offset;//menyimpan selesih posis object degn mouse
    [HideInInspector]
    public int cost;//menyimpan koin yg harus dikeluarkan
    [HideInInspector]
    public bool follow = true;//game object yg dipilih mengikuti mouse
    private void Update()
    {
        if (follow)//mengikuti
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);//menyimpan posisi mouse saat ini
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;//menentukan posisi gameobjek dari posisi awal mouse ke posisi skrang
            transform.position = curPosition;
            if (Input.GetMouseButtonUp(0))
            {
                if (transform.position.x < 0 && transform.position.y > -2f)
                {
                    follow = false;//matikan false
                    Data.coin -= cost;//mengurangi koin
                    foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
                        childCompnent.enabled = true;
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("Meletakkan area yg tidak diijinkan");
                }
            }
        }
    }
}
