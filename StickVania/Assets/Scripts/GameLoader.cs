using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void NewGame()
    {
        // Reset game -> read file or create new file game to save your turn
        // Code here

        // Load Map 1
        SceneManager.LoadScene("Map_1");
    }

    public void QuitGame()
    {
        // Quit game
        Application.Quit();
    }

    public void LoadMenu()
    {
        // Load Scene 0
        SceneManager.LoadScene(0);
    }
}
