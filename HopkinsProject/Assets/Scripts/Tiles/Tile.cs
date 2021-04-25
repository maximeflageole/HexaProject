using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] protected FloatingText m_resourceGainText;
    [SerializeField] protected float m_productionBaseTime = 5.0f;
    
    protected float m_currentTimer = 0.0f;

    [SerializeField] protected Vector2Int m_coordinates;
    public TileData TileData { get; protected set; }

    public void Instantiation(Vector2Int coordinates, TileData tileData)
    {
        TileData = tileData;
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
            m_resourceGainText.Init(TileData.ProductionMultiplier.ToString(), false, 1);
        }
    }
}