using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Start()
    {
        // SaveToTxt.preveriCeObstajaTXTdatoteka();
    }

    void Update()
    {
        if (transform.localScale.x > 0.2f)
        {
            SceneManager.LoadScene(sceneName: "SceneInteractables");
        }
        //Debug.Log(valj.GetComponent<Transform>().transform.localScale.x);
        // else
        // {
        //     Debug.Log("skala kocke: " + GameObject.Find("Prehodna kocka").GetComponent<Transform>().transform.localScale.x);
        //     if (GameObject.Find("Prehodna kocka").GetComponent<Transform>().transform.localScale.x < 130f)
        //     {
        //         Debug.Log("Tuki");
        //         SceneManager.LoadScene(sceneName: "Scena Zunaj");
        //     }
        // }
    }
}