using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const string PLAYER_PROFILE_NAME = "Geeno";

    private void Start()
    {
        // Delete the existing save profile to ensure we always have a fresh save.

        SaveManager.Delete(PLAYER_PROFILE_NAME);

        // Create a new player save data instance.
        var playerSaveData = new PlayerSaveData
        {
            position = transform.position,
            damage = 5,
            speed = 10,
            health = 10,
            inventory = new List<string> { "spada", "scudo", "pozione", "corda" }
        };

        // Create a new save profile with the player save data.
        var saveProfile = new SaveProfile<PlayerSaveData>(PLAYER_PROFILE_NAME, playerSaveData);

        // Save the profile to the save folder.
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

            var newPlayerSave = new PlayerSaveData { 
                position = transform.position, 
                health = 20, 
                damage = 10, 
                speed = 10, 
                inventory = new List<string> { "spada", "scudo", "pozione", "corda" }};

            var newSaveProfile = new SaveProfile<PlayerSaveData>(PLAYER_PROFILE_NAME, newPlayerSave);

            SaveManager.Save(newSaveProfile);
        }
    }


}

