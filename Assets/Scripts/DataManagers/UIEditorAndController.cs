using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIEditorAndController : MonoBehaviour
{
    public Status status;

    void Start()
    {
        status = SaveManager.Load();
    }

    void Update()
    {
        
    }

    public void ChangeGameTime(string time)
    {
        status.gameTime = int.Parse(time);

        if(status.gameTime > 180)
        {
            status.gameTime = 180;
        }
        else if(status.gameTime < 60)
        {
            status.gameTime = 60;
        }
        SaveManager.Save(status);
    }

    public void ChangeSpawnEnemyTime(string time)
    {
        status.spawnEnemyTime = int.Parse(time);
        if(status.spawnEnemyTime < 1)
        {
            status.spawnEnemyTime = 1;
        }

        SaveManager.Save(status);
    }
}
