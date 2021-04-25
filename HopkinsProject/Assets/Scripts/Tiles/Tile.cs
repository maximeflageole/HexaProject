using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] protected float m_productionBaseTime = 5.0f;
    
    protected float m_currentTimer = 0.0f;

    [SerializeField] protected Vector2Int m_coordinates;

    public void Instantiation(Vector2Int coordinates)
    {
        m_coordinates = coordinates;
    }
    
    // Update is called once per frame
    void Update()
    {
        m_currentTimer += Time.deltaTime;
        if (m_currentTimer > m_productionBaseTime)
        {
            m_currentTimer %= m_productionBaseTime;
            GameManager.GetInstance().AddSeeds();
        }
    }
}