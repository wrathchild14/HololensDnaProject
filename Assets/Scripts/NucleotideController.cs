using System;
using System.IO;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.Events;

public class NucleotideController : MonoBehaviour, IMixedRealityPointerHandler
{
    private MeshOutline _outline;
    public string filename = "test.txt";
    private string _path;

    private void Start()
    {
        _path = Path.Combine(Application.persistentDataPath, filename);
        // read information from some file in this path
        _outline = GetComponent<MeshOutline>();
    }

    public void OnInteractionStarted()
    {
        Debug.Log("interaction started");

        var data = "I interacted with " + gameObject.name;
        File.AppendAllText(_path, data);
        _outline.enabled = true;
    }

    public void OnInteractionEnded()
    {
        // _outline.enabled = false;
        Debug.Log("interaction ended");
    }

    private void Update()
    {
        // when gazed upon display information
        // when pinched save information to path
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        Debug.Log("pointer dow");
        OnInteractionStarted();
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        OnInteractionEnded();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
    }
}
