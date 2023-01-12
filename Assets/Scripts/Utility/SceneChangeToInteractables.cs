using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneChangeToInteractables : MonoBehaviour
    {
        public float scaleToChangeScene;
        private void Update()
        {
            if (transform.localScale.x > scaleToChangeScene) SceneManager.LoadScene("SceneInteractables");
        }
    }
}