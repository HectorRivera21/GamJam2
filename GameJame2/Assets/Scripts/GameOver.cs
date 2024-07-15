using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Player ship;
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
            if (ship.currentHealth <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
    }
}
