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
    //public GameObject Reach;
    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKeyDown(respawn)) //Calls Respawn Function
        {
            PlayerRespawn();
        }
        

    }
    //Respawn Function
    public void PlayerRespawn()
    {
        Debug.Log("SpawnPoint: " + SpawnPoint.transform.position);
        Debug.Log("TP");
        Player.transform.position = SpawnLocation; //Sets player Position to SpawnLocations saved position.
        HUD.Instance.PlayerHealth = HUD.Instance.PlayerMaxHealth;
        Debug.Log("PlayerHealth: " + HUD.Instance.PlayerHealth);
        Debug.Log("SpawnLocation: " + SpawnLocation + "\tplayerLocation: " + Player.transform.position);
        Time.timeScale = 1;
    }

    void SpawnPointSelection()
    {
        SpawnLocation = Player.transform.position;
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
