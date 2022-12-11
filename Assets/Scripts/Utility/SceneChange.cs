using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneChange : MonoBehaviour
    {
        void Update()
        {
            if (transform.localScale.x > 0.2f)
            {
                SceneManager.LoadScene(sceneName: $"SceneInteractables");
            }
        }
    }
}