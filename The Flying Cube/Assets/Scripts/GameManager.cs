using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject loseWindow;

    public static GameManager instance; //как бы создаем сами себ€, но статик дает нам пон€ть, что к этой переменной можно будет обращатьс€ по пр€мой ссылки на скрипт  

    private void Start() 
    {
        instance = this;
    }
    public void Lose()
    {
        loseWindow.SetActive(true); // у объекта луз виндоу вызываем сетактив, который регулирует галочку р€дом с объектом  
        Time.timeScale = 0;
    
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // загружаемс—цену.получаем“екущую—цену().получаем≈е»ндекс
        Time.timeScale = 1.0f;
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1.0f;
    }
}
