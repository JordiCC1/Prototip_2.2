using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool changedScene = true;
    public void ChangeScene(string name)
    {
        if (changedScene) { changedScene = false; }
        else changedScene = true;
        SceneManager.LoadScene(name);
    }

    public void ChangeCombatScene()
    {
        int random = Random.Range(0, 2);
        if (changedScene) { changedScene = false; }
        else changedScene = true;

        switch (random) 
        {
            case 0:
                SceneManager.LoadScene("CombatScene_1");
                break; 
            case 1:
                SceneManager.LoadScene("CombatScene_2");
                break;
            case 2:
                SceneManager.LoadScene("CombatScene_3");
                break;
            default:
                SceneManager.LoadScene("CombatScene_1");
                break;

        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
