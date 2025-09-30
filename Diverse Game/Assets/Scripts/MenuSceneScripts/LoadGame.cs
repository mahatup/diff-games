using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private GameObject menu, menuSelect;
    public void SwitchSelect()
    {
        
        menu.SetActive(false);
        menuSelect.SetActive(true);
    }
    public void SwitchMenu()
    {
        menu.SetActive(true);
        menuSelect.SetActive(false);
    }
    public void SelectGame(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum); 
    }


}
