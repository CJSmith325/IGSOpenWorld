using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static Respawn Instance;
    public bool TouchingSpawn = false;

    public Transform Player;
    public Transform SpawnPoint;

    private Vector3 SpawnLocation;

    public KeyCode respawn;
    public KeyCode SetSpawn;
    
    public GameObject GameOverCanvas;
    public GameObject HUDCanvas;
    //public GameObject Reach;

    // Start is called before the first frame update
    void Start()
    {
        //GameOverCanvas.SetActive(false);
        Instance = this;
        SpawnLocation = SpawnPoint.transform.position; //Sets Player SpawnLocation to Spawnpoint Position.
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        //set active HUD
        HUDCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (TouchingSpawn == true & Input.GetKeyDown(SetSpawn))
        {
            SpawnPointSelection();
        }

        
        if (Input.GetKeyDown(respawn)) //|| HUD.Instance.PlayerHealth <= 0) //Calls Respawn Function
        {
            //GameOverCanvas.SetActive(true);
            PlayerRespawn();
        }
        

    }

    //Respawn Function
    public void PlayerRespawn()
    {
        Debug.Log("SpawnPoint: " + SpawnPoint.transform.position);
        Debug.Log("TP");

        HUDCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);

        //GetComponent<Collider>().gameObject.tag = "player";
        //Player.transform.position = SpawnPoint.transform.position; //Sets player Position to SpawnLocations saved position.

        //set player health and position
        Player.transform.position = SpawnLocation;
        HUD.Instance.PlayerHealth = HUD.Instance.PlayerMaxHealth;
        
        Debug.Log("PlayerHealth: " + HUD.Instance.PlayerHealth);
        Debug.Log("SpawnLocation: " + SpawnLocation + "\tplayerLocation: " + Player.transform.position);

        Time.timeScale = 1;     //start time
    }

    void SpawnPointSelection()
    {
        SpawnLocation = Player.transform.position;
        Debug.Log("");
    }

    public void GameOver()
    {
        Time.timeScale = 0;


        GameOverCanvas.SetActive(true);
        HUDCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //PlayerRespawn();
    }

}
