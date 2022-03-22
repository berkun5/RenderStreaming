using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button changeS;
    // Start is called before the first frame update
    void Start()
    {
        changeS.onClick.AddListener(ChangeScenee);
    }

    private void ChangeScenee()
    {
        if (SceneManager.GetActiveScene().name != "MultiplayExtra")
        {
            SceneManager.LoadScene("MultiplayExtra");
        }
        else
        {
            SceneManager.LoadScene("Multiplay");
        }
    }

}
