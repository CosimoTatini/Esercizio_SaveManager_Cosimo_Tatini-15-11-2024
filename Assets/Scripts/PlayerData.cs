using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public sealed class SaveProfile<T> where T: SaveProfileData
{
    public string name;
    public T saveData;

    private SaveProfile()
    {

    }
    public SaveProfile(string name , T saveData)
    {
        this.name = name;
        this.saveData = saveData;
    }

}


public abstract record SaveProfileData
{

}
public record PlayerSaveData:SaveProfileData
{
    public Vector3 position;
    public int health;
    public float speed;
    public float damage;
    public List<string> inventory;
}




