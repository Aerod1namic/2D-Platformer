using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Restart : MonoBehaviour
{
    public Player player;
    public GameObject WinScr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        WinScr.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
