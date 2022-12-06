using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class premikanje : MonoBehaviour
{
    GameObject kamera;
    GameObject sliderja;
    void Start()
    {
        kamera = GameObject.Find("Main Camera");
        sliderja = GameObject.Find("Sliderja");
    }

    // Update is called once per frame
    void Update()
    {
        sliderja.transform.position = new Vector3(kamera.transform.position.x - 27.8f, kamera.transform.position.y - 4.04f, kamera.transform.position.z+ 2.0f);
    }
}
