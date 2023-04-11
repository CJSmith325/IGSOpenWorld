using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    public void OnShrekClick()
    {
        SceneManager.LoadScene("Planet attack");
    }
}
