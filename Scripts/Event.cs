using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public void ReplyGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // на всякий случай сделал. но оно как-то странно работает. Запускается сцена но без юай игра даже не начинается(((
    public void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
