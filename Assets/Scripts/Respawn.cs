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
    public GameObject mPlayer;
    private Vector3 SpawnLocation;
    public KeyCode respawn;
    public KeyCode SetSpawn;
    //public GameObject GameOverCanvas;
    //public GameObject Reach;
    // Start is called before the first frame update
    void Start()
    {
        //GameOverCanvas.SetActive(false);
        Instance = this;
        SpawnLocation = SpawnPoint.transform.position; //Sets Player SpawnLocation to Spawnpoint Position.

    }
    // Update is called once per frame
    void Update()
    {
        if (TouchingSpawn == true & Input.GetKeyDown(SetSpawn))
        {
            SpawnPointSelection();
        }

        if (Input.GetKeyDown(respawn) || HUD.Instance.PlayerHealth <= 0) //Calls Respawn Function
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
        //GetComponent<Collider>().gameObject.tag = "player";
        Player.transform.position = SpawnPoint.transform.position; //Sets player Position to SpawnLocations saved position.
        HUD.Instance.PlayerHealth = HUD.Instance.PlayerMaxHealth;
        //HUD.Instance.GameOverCanvas.SetActive(false);
        Debug.Log("PlayerHealth: " + HUD.Instance.PlayerHealth);
        Debug.Log("SpawnLocation: " + SpawnLocation + "\tplayerLocation: " + Player.transform.position);
        Time.timeScale = 1;
    }

    void SpawnPointSelection()
    {
        SpawnLocation = Player.transform.position;
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        //System.Threading.Thread.Sleep(3000);
        //GameOverCanvas.SetActive(true);
        Cursor.visible = true;
        PlayerRespawn();
    }
    /*    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Respawn")
            {
                TouchingSpawn = true;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Respawn")
            {
                TouchingSpawn = false;
            }
        }   */
}
