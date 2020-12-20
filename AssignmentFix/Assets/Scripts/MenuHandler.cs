using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] private string pongEffect;
    [SerializeField] private string retrowave;
    [SerializeField] private string theClub;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPong()
    {
        SceneManager.LoadScene(pongEffect);
    }

    public void LoadRetro()
    {
        SceneManager.LoadScene(retrowave);
    }

    public void LoadClub()
    {
        SceneManager.LoadScene(theClub);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
