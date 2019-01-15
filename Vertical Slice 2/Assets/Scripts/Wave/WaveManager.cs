using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public int wave;

    
    public List<WaveData> waveDatas = new List<WaveData>(); 
    private SpawnManager spawnManager;

	// Use this for initialization
	void Start () {
        spawnManager = GetComponent<SpawnManager>();

        SetWave(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetWave(int wave)
    {
        this.wave = wave;

        int index = wave - 1;

        for (int i = 0; i < waveDatas[index].cow; i++)
        {
            spawnManager.remainingEnemies.Add(spawnManager.enemies[0]);
        }

        for (int i = 0; i < waveDatas[index].pig; i++)
        {
            spawnManager.remainingEnemies.Add(spawnManager.enemies[1]);

        }
    }


}

[System.Serializable]
public struct WaveData
{
    public int cow;
    public int pig;
}
