using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public void load_game()
    {
        SceneManager.LoadScene("Level1");
    }
}
