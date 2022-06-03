using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*允许按钮触发各种功能，如QuitGame和LoadScene*/

public class MenuHandler : MonoBehaviour {

	[SerializeField] private string whichScene;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(whichScene);
    }
}
