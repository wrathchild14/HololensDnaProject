using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine.UI;

public class neki : MonoBehaviour
{
    GameObject[] ogljiki;
    GameObject[] kisiki;
    GameObject[] forforji;
    GameObject[] dusiki;
    GameObject[] vodiki;
    GameObject[] holium;
    GameObject krogla;
    GameObject vrstica;
    GameObject textSkalirni;
    float skalirniFaktor;
    float razdalja;
    GameObject anchor;
    GameObject model;
    GameObject krogla2;
    GameObject anchor2;
    float razdalja1;
    float skalirniFaktor2;
    Handedness trackedHand = Handedness.Both;
    // Start is called before the first frame update
    void Start()
    {
        ogljiki = new GameObject[1441];
        kisiki = new GameObject[897];
        forforji = new GameObject[145];
        dusiki = new GameObject[641];
        vodiki = new GameObject[1665];
        holium = new GameObject[33];
        string baseOgljik = "Carbon_mesh|Carbon_ball|Dupli|";
        string baseKisik = "Oxygen_mesh|Oxygen_ball|Dupli|";
        string baseFosforji = "Phosphorus_mesh|Phosphorus_ball|Dupli|";
        string baseDusiki = "Nitrogen_mesh|Nitrogen_ball|Dupli|";
        string baseVodiki = "Hydrogen_mesh|Hydrogen_ball|Dupli|";
        string baseHolium = "Holmium_mesh|Holmium_ball|Dupli|";
        holium[0] = GameObject.Find(baseHolium);
        forforji[0] = GameObject.Find(baseFosforji);
        dusiki[0] = GameObject.Find(baseDusiki);
        kisiki[0] = GameObject.Find(baseKisik);
        ogljiki[0] = GameObject.Find(baseOgljik);
        vodiki[0] = GameObject.Find(baseVodiki);
        holium[32] = GameObject.Find("Holmium_ball");
        forforji[144] = GameObject.Find("Phosphorus_ball");
        dusiki[640] = GameObject.Find("Nitrogen_ball");
        kisiki[896] = GameObject.Find("Oxygen_ball");
        ogljiki[1440] = GameObject.Find("Carbon_ball");
        vodiki[1664] = GameObject.Find("Hydrogen_ball");
        krogla = GameObject.Find("SliderKrogla");
        vrstica = GameObject.Find("Slider vrstica");
        anchor = GameObject.Find("anchor");
        model = GameObject.Find("model");
        krogla2 = GameObject.Find("SliderKrogla2");
        anchor2 = GameObject.Find("anchor2");

        for (int i = 1; i < 1664; i++) {
            if (i < 32) {
                holium[i] = GameObject.Find(baseHolium + i.ToString());
            }
            if (i < 144)
            {
                forforji[i] = GameObject.Find(baseFosforji + i.ToString());
            }
            if (i < 640)
            {
                dusiki[i] = GameObject.Find(baseDusiki + i.ToString());
            }
            if (i < 896)
            {
                kisiki[i] = GameObject.Find(baseKisik + i.ToString());
            }
            if (i < 1440)
            {
                ogljiki[i] = GameObject.Find(baseOgljik + i.ToString());
            }
            vodiki[i] = GameObject.Find(baseVodiki + i.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        razdalja = Vector3.Distance(anchor.transform.position, krogla.transform.position);
        skalirniFaktor = razdalja / 0.919f;
        razdalja1 = Vector3.Distance(anchor2.transform.position, krogla2.transform.position);
        skalirniFaktor2 = razdalja1 / 0.919f;
        //Debug.Log(razdalja1);
        if (skalirniFaktor > 1f) {
            skalirniFaktor = 1f;
        }
        if (skalirniFaktor < 0f)
        {
            skalirniFaktor = 0f;
        }
        if (skalirniFaktor2 > 1f) {
            skalirniFaktor2 = 1f;
        }
        if (skalirniFaktor2 < 0f)
        {
            skalirniFaktor2 = 0f;
        }
        //textSkalirni.GetComponent<Text>().text = skalirniFaktor.ToString();
        //Debug.Log(skalirniFaktor.ToString() + "\n");
        //959 je max
        //min = -0.585; Scale 0,1;
        //max = 0.374; Scale 1;

        for (int i = 0; i < 1665; i++) {
            if (i < 33)
            {
                skalirej(holium[i], skalirniFaktor);
            }
            if (i < 145)
            {
                skalirej(forforji[i], skalirniFaktor);
            }
            if (i < 641)
            {
                skalirej(dusiki[i], skalirniFaktor);
            }
            if (i < 897)
            {
                skalirej(kisiki[i], skalirniFaktor);
            }
            if (i < 1441)
            {
                skalirej(ogljiki[i], skalirniFaktor);
            }
            skalirej(vodiki[i], skalirniFaktor);
        }
        skalirej(model, skalirniFaktor2);
        
    }

    void skalirej(GameObject objekt, float skalirniFaktor1) {
        objekt.transform.localScale = new Vector3(skalirniFaktor1, skalirniFaktor1, skalirniFaktor1);
    
    }
}
