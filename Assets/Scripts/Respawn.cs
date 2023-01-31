using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform Player;
    public Transform SpawnPoint;
    private Vector3 SpawnLocation;
    public KeyCode respawn;
    // Start is called before the first frame update
    void Start()
    {
       SpawnLocation = SpawnPoint.transform.position; //Sets Player SpawnLocation to Spawnpoint Position.

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(respawn)) //Calls Respawn Function
        {
            PlayerRespawn();
        }

    }
    //Respawn Function
    void PlayerRespawn()
    {

        Debug.Log("SpawnPoint: " + SpawnPoint.transform.position);

        Debug.Log("TP");
        Player.transform.position = SpawnLocation; //Sets player Position to SpawnLocations saved position.
        HUD.Instance.PlayerHealth = HUD.Instance.PlayerMaxHealth;
        Debug.Log("PlayerHealth: " + HUD.Instance.PlayerHealth);
        Debug.Log("SpawnLocation: " + SpawnLocation + "\tplayerLocation: " + Player.transform.position);

    }
}
