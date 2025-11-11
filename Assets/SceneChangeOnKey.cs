using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnKey : MonoBehaviour
{
    
    [SerializeField] string targetScene;
    [SerializeField] KeyCode key = KeyCode.C;
        void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("its working");
            SceneManager.LoadScene(targetScene);
        }
    }
}
