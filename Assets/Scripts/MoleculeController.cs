using System;
using System.IO;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoleculeController : MonoBehaviour, IMixedRealityPointerHandler
    {
        public TextMeshPro readDataText;
        public string fileName = "names.txt";
        private string _filePath;

        private MeshOutline _outline;
        private bool _saved;
        private DateTime _timePassed;

        private void Start()
        {
            _filePath = Path.Combine(Application.persistentDataPath, fileName);
            _outline = GetComponent<MeshOutline>();
        }

        public void OnPointerDown(MixedRealityPointerEventData eventData)
        {
            if (!_saved)
            {
                _outline.enabled = true;
                _timePassed = DateTime.Now;
            }
        }

        public void OnPointerDragged(MixedRealityPointerEventData eventData)
        {
        }

        public void OnPointerUp(MixedRealityPointerEventData eventData)
        {
            if (!_saved)
            {
                var duration = DateTime.Now.Subtract(_timePassed);
                if (duration.Seconds >= 2)
                {
                    var data = gameObject.name + ", ";
                    File.AppendAllText(_filePath, data);
                    _saved = true;
                }
                else
                {
                    _outline.enabled = false;
                }
            }
        }

        public void OnPointerClicked(MixedRealityPointerEventData eventData)
        {
            if (_outline.enabled && _saved) readDataText.text = File.ReadAllText(_filePath);
        }
    }
}