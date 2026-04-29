using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GridManager : MonoBehaviour
{
    public int width = 12;
    public int height = 12;
    public float cellSize = 1f;

    public GameObject enemyPrefab;
    public int enemyCount = 5;

    private List<Vector2> usedPositions = new List<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      GenerateGrid();
      SpawnEnemies();  
    }
    void GenerateGrid()
    {
        usedPositions.Clear();
    }

    public Vector2 GetRandomGridPosition()
    {
        Vector2 pos;
        
        do
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0,height);
            pos = new Vector2(x * cellSize, y * cellSize);
        } 
        while (IsPositionUsed(pos));

        usedPositions.Add(pos);
        return pos;
    }

    bool IsPositionUsed(Vector2 pos)
    {
        return usedPositions.Contains(pos);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 spawnPos = GetRandomGridPosition();
            Instantiate(enemyPrefab,spawnPos,Quaternion.identity);
        }
    }

    public void ClearGrid()
    {
        usedPositions.Clear();
    }

}
