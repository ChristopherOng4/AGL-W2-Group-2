using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        HealthSystem.OnPlayerDeath += EnableGameOverMenu; 
    }

    private void OnDisable()
    {
        HealthSystem.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu() 
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
