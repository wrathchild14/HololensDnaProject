using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prehodvdrugosceno : MonoBehaviour
{
    GameObject valj;
    public int scena;
    void Start()
    {
       SaveToTxt.preveriCeObstajaTXTdatoteka();
    }

    void Update()
    {
        if (scena == 0) {
            if (GameObject.Find("Cylinder").GetComponent<Transform>().transform.localScale.x > 0.2f)
            {
                SceneManager.LoadScene(sceneName: "Scena1");
            }
        }
        //Debug.Log(valj.GetComponent<Transform>().transform.localScale.x);
        else
        {
            Debug.Log("skala kocke: " + GameObject.Find("Prehodna kocka").GetComponent<Transform>().transform.localScale.x);
            if (GameObject.Find("Prehodna kocka").GetComponent<Transform>().transform.localScale.x < 130f)
            {
                Debug.Log("Tuki");
                SceneManager.LoadScene(sceneName: "Scena Zunaj");
            }
        }
        
    }
}
