using UnityEngine;

public class NucleotideController : MonoBehaviour
{
    private void Start()
    {
        var path = Application.persistentDataPath;
        // read information from some file in this path
    }

    private void Update()
    {
        // when gazed upon display information
        DisplayInformation();
        
        // when pinched save information to path
        SaveInformation();
    }

    private void SaveInformation()
    {
        throw new System.NotImplementedException();
    }

    private void DisplayInformation()
    {
        throw new System.NotImplementedException();
    }
}
