using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneChange : MonoBehaviour
    {
        private void Update()
        {
            if (transform.localScale.x > 0.2f)
            {
                SceneManager.LoadScene(sceneName: $"SceneInteractables");
            }
        }
    }
}