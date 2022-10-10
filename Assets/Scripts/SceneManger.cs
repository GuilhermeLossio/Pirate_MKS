using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

    public void Exit()
	{
		Application.Quit ();
	}
}
