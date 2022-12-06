using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class Raycasting : MonoBehaviour
{
    Vector3 handPosition;
    Vector3 handRotation;
    Handedness hand;
    public RaycastHit hit;
    GameObject roka;
    Vector3 rotacijskiVektor;
    float x;
    float y;
    float z;
    Ray ray;
    GameObject kamera;
    string celString;
    string[] vrstice;
    string izpis;
    GameObject tekst;
    string oznaka;
    bool sePincha;
    float csPincha;
    float zacetekPincha;
    float pinchThreshold = 1f;          //kok casa more oseba pinchat da se zapise
    GameObject platnoZaIzpis;
    // Start is called before the first frame update
    void Start()
    {
        hand = Handedness.Both;
        roka = GameObject.Find("Roka");
        kamera = GameObject.Find("Main Camera");
        tekst= GameObject.Find("Text");
        handPosition = roka.transform.position; 
        handRotation = roka.transform.rotation.eulerAngles;
        x = (float)System.Math.Sin(handRotation.z * Mathf.PI / 180);
        y = (float)-(System.Math.Sin(handRotation.x * Mathf.PI / 180) *System.Math.Sin(handRotation.z * Mathf.PI / 180));
        z = (float)(System.Math.Cos(handRotation.x * Mathf.PI / 180) * System.Math.Cos(handRotation.y * Mathf.PI / 180));
        rotacijskiVektor = new Vector3(x, y, z);
        celString = SaveToTxt.ReadString();
        //SaveToTxt.emptyTXT();   //ta je za izbrisat ob koncni oddaji
        vrstice = SaveToTxt.stringByRows();
        platnoZaIzpis = GameObject.Find("PlatnoZaIzpis");
        platnoZaIzpis.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        csPincha = csPinchanja();
        celString = SaveToTxt.ReadString();
        Debug.Log(celString);
        vrstice = SaveToTxt.stringByRows();
        if (GameObject.Find("Right_ShellHandRayPointer(Clone)"))
        {
            roka.transform.position = GameObject.Find("Right_ShellHandRayPointer(Clone)").transform.position;
            roka.transform.rotation = GameObject.Find("Right_ShellHandRayPointer(Clone)").transform.rotation;
            platnoZaIzpis.SetActive(true);
        }
        else {
            platnoZaIzpis.SetActive(false);
        }
        handPosition = roka.transform.position;
        handRotation = roka.transform.rotation.eulerAngles+kamera.transform.rotation.eulerAngles;
        platnoZaIzpis.transform.position = handPosition;
        platnoZaIzpis.transform.position= new Vector3(platnoZaIzpis.transform.position.x+0.15f, platnoZaIzpis.transform.position.y+0.08f, platnoZaIzpis.transform.position.z);
        //platnoZaIzpis.transform.rotation;
        ray =new Ray(handPosition, roka.transform.forward);
        if (Physics.Raycast(ray, out hit)) {
            if (csPincha > 0f && GameObject.Find("Right_ShellHandRayPointer(Clone)")) {
                if (csPincha > pinchThreshold)
                {
                    if (!celString.Contains(hit.collider.ToString()))
                    {
                        oznaka = RandomStringGenerator(5);      //kle se da SaveToTxt.emso() da se dobi emso iz datoteke, namesto nakljucnega stringa
                        if (celString.Contains(oznaka))
                        {
                            for (int i = 0; i < vrstice.Length; i++) {
                                if (vrstice[i].Contains(oznaka)) {
                                    SaveToTxt.replacePart("", vrstice[i]);            //da se pobrise emso iz prvega objekta
                                }
                            }
                            SaveToTxt.WriteString(hit.collider.ToString() + oznaka);                //da se emso zapise na drugi objekt
                            tekst.GetComponent<Text>().text = "Objekt ste oznaèili z:\n" + oznaka;
                            Debug.Log("Pride");
                        }
                        else {
                            SaveToTxt.WriteString(hit.collider.ToString() + oznaka); //treba dolociti nek identifikator za osebo mogoce random
                            tekst.GetComponent<Text>().text = "Objekt ste oznaèili z:\n" + oznaka;
                            Debug.Log(SaveToTxt.ReadString());
                        }
                    }
                }
                else { 
                    if (!celString.Contains(hit.collider.ToString()))
                    {
                        tekst.GetComponent<Text>().text = "Neoznaceni objekt";
                    }
                    else
                    {
                        for (int i = 0; i < vrstice.Length; i++)
                        {
                            if (vrstice[i].Contains(hit.collider.ToString()))
                            {
                                izpis = vrstice[i];
                                izpis = izpis.Replace(hit.collider.ToString(), "");   //treba samo nekako izpisati ta tekst
                                tekst.GetComponent<Text>().text = izpis;
                                Debug.Log(izpis);
                            }
                        }
                    //display string of person here
                    }
                //v debug izpiše kateri collider je zadel, se lahko uporabi za doloèanje zadetega objekta
                }
            }
        }
    }
    string RandomStringGenerator(int lenght)
    {
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string generated_string = "";

        for (int i = 0; i < lenght; i++)
            generated_string += characters[Random.Range(0, lenght)];

        return generated_string;
    }
    float csPinchanja() {
        if (!pinchChecker.IsPinching(hand) && GameObject.Find("Right_ShellHandRayPointer(Clone)"))
        {
            if (sePincha)
            {
                csPincha = Time.time - zacetekPincha;
                zacetekPincha = Time.time;
                sePincha = false;
            }
            else
            {
                csPincha = 0f;
                zacetekPincha = Time.time;
            }
        }
        else {
            if (!sePincha)
            {
                zacetekPincha = Time.time;
                sePincha = true;
                csPincha = 0f;
            }
            else {
                csPincha = 0f;
            }
        }
        if (Time.time-zacetekPincha > pinchThreshold) {
            sePincha = false;
            csPincha = Time.time - zacetekPincha;
            zacetekPincha = Time.time;
        }

        return csPincha;
    }
}

