using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinedPlayers : MonoBehaviour
{
    public List<PlayerInputManager> players = new List<PlayerInputManager>();

    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<Vector3> spawnLocations = new List<Vector3>();

    private const int gameLevel = 2;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (spawnLocations.Count == 0)
        {
            spawnLocations.Add(new Vector3(0.58f, 1.42f, 0.51f));
        }
        if (playerPrefab == null)
        {
            playerPrefab = (GameObject)Resources.Load("Prefabs/Player", typeof(GameObject));
        }
    }

    public void StartGame()
    {
        foreach (PlayerInputManager player in players)
        {
            player.gameObject.SetActive(false);
        }
        SceneManager.sceneLoaded += SceneLoaded;
        SceneLoader.GoToNextScene();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("Game"))
        {
            SpawnPlayers();
        }

        if (scene.name.Equals("GameOver"))
        {
            Destroy(gameObject);
        }
    }

    private void SpawnPlayers()
    {
        foreach(PlayerInputManager player in players)
        {
            GameObject newPlayer = Instantiate(playerPrefab, spawnLocations[0], Quaternion.identity);
            PlayerInputManager playerInput = newPlayer.GetComponent<PlayerInputManager>();
            if (player.inputType == PlayerInputManager.InputType.keyboard)
            {
                playerInput.SetKeyboardControlled();
            }
            else if (player.inputType == PlayerInputManager.InputType.joystick)
            {
                playerInput.SetJoystickController(player.joyNum);
            }

        }
        Destroy(gameObject);
    }
}
