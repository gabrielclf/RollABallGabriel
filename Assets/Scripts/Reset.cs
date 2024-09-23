
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Reset : MonoBehaviour
{
    public float limite = -12f; //Altura para definir um gameover + reset
    public float restartDelay = 2f; // Passam alguns segundos antes de resetar o nivel
    public TextMeshProUGUI loseText;
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameReset(){
        Invoke("RestartGame", restartDelay);
    }

    void Start(){
        loseText.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < limite)
        {
            loseText.text = "GAME OVER";
            //Time.timeScale = 0;
            GameReset();
        }
    }
}
