using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{

    public void Setup(){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Level1Scene1");
        Debug.Log("Game Restarted");
    }
    public void ExitButton(){
        SceneManager.LoadScene("StartMenu");
    }
}
