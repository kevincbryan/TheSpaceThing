using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerInteraction : MonoBehaviour
{
    public float oxygen = 100;

    public float minimumLoss = 1f;
    public float maximumLoss = 33f;

    public float oxygenGainRate = 5f;
    public Image healthBar;

    private HashSet<DoorTrigger> nearbyDoors = new HashSet<DoorTrigger>();

    private HashSet<RoomTrigger> inRooms = new HashSet<RoomTrigger>();

    private PlayerInputManager inputManager;

    private void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
    }

    public void Update() {
        HandleOxygen();
        HandleDoorToggle();
    }

    public void PlayerSuffocate() {
        Debug.Log("Player Suffocated");
        Invoke("GameOver", 3f);
        //Destroy(this.gameObject);
    }

    public void HandleOxygen() {
        if (!inRooms.Any()) {
            //Debug.Log("Not in any rooms. Map needs repair.");
            return;
        }

        var highestOxygen = inRooms.Select(rt => rt.room.oxygen).Max();
        if (highestOxygen < 50) {
            var percentToward50 = highestOxygen / 50f;
            var percentToward0From50 = 1 - highestOxygen;
            var oxygenLossRate = Mathf.Lerp(minimumLoss, maximumLoss, percentToward0From50);
            oxygen -= oxygenLossRate * Time.deltaTime;
            
        }

        if (highestOxygen >= 75) {
            oxygen += oxygenGainRate;
        }

        if (oxygen <= 0) {
            oxygen = 0;
            PlayerSuffocate();
        }

        oxygen = Mathf.Clamp(oxygen, 0, 100);
        healthBar.fillAmount = oxygen / 100f;
    }

    public void GameOver ()
    {
        SceneLoader.GoToNextScene();

    }

    public void HandleDoorToggle() {
        if (inputManager.InteractPressed()) {
            foreach (var door in nearbyDoors) {
                door.Toggle();
            }
        }
    }
    
    public void OnRoomEnter(RoomTrigger room) {
        //Debug.Log("OnRoomEnter");
        this.inRooms.Add(room);
        //Debug.Log($"In Rooms {inRooms.Count}");
    }
    
    public void OnRoomExit(RoomTrigger room) {
        //Debug.Log("OnRoomExit");
        this.inRooms.Remove(room);
        //Debug.Log($"In Rooms {inRooms.Count}");
    }

    public void OnDoorEnter(DoorTrigger door) {
        //Debug.Log("OnDoorEnter");
        this.nearbyDoors.Add(door);
        //Debug.Log($"Nearby Doors {nearbyDoors.Count}");
    }
    
    public void OnDoorExit(DoorTrigger door) {
        //Debug.Log("OnDoorExit");
        this.nearbyDoors.Remove(door);
        //Debug.Log($"Nearby Doors {nearbyDoors.Count}");
    }
}
