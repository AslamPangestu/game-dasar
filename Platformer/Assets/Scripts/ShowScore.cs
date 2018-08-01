using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowScore : MonoBehaviour {

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Text>().text = Data.score.ToString("000");
    }
}
