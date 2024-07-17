using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Player ship;
    private bool isGameover = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            ship = playerObject.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (!isGameover && ship != null && ship.currentHealth <= 0)
            {
                isGameover = true;
                SceneManager.LoadScene("StartScreen");
            }
    }
}
