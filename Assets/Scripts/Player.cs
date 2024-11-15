using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Player : MonoBehaviour
{
    const string PLAYER_PROFILE_NAME = "Geeno";

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        SaveManager.Delete(PLAYER_PROFILE_NAME);
        var playerSave = new PlayerSaveData { position = transform.position, damage = 5, speed = 10, health = 10, inventory = { "spada", "scudo", "pozione", "corda" } };
        var saveProfile = new SaveProfile<PlayerSaveData>(PLAYER_PROFILE_NAME, playerSave);
        SaveManager.Save(saveProfile);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            var savedData = SaveManager.Load<PlayerSaveData>(PLAYER_PROFILE_NAME).saveData;
            float speed = savedData.speed;
            var position = savedData.position;
            int health = savedData.health;
            var inventory = savedData.inventory;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveManager.Delete(PLAYER_PROFILE_NAME);
            var newPlayerSave = new PlayerSaveData { position = transform.position, health = 20, damage = 10, speed = 10, inventory = { "spada", "scudo", "pozione", "corda" }};
            var newSaveProfile = new SaveProfile<PlayerSaveData>(PLAYER_PROFILE_NAME, newPlayerSave);
            SaveManager.Save(newSaveProfile);
        }
    }


}

