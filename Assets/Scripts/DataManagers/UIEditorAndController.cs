using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEditorAndController : MonoBehaviour
{
    public Status status;

    // Start is called before the first frame update
    void Start()
    {
        status = SaveManager.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGameTime(string time)
    {
        //status.gameTime = String.Join("", System.Text.RegularExpressions.Regex.Split(time, @"[^\d]"));
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
        //status.spawnEnemyTime = String.Join("", System.Text.RegularExpressions.Regex.Split(time, @"[^\d]"));
        status.spawnEnemyTime = int.Parse(time);
        

        if(status.spawnEnemyTime < 1)
        {
            status.spawnEnemyTime = 1;
        }

        SaveManager.Save(status);
    }
}
