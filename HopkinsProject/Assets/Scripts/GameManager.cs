using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Map m_map;
    public TileCard SelectedCard { get; private set; }
    public DataDictionaries m_dataDictionaries;
    public Pile m_pile;
    public LevelData m_levelData;
    public TileCard m_tileCardPrefab;

    private static GameManager _INSTANCE;
    
    public static GameManager GetInstance()
    {
        if (_INSTANCE == null)
        {
            var go = new GameObject();
            _INSTANCE = go.AddComponent<GameManager>();
        }

        return _INSTANCE;
    }

    [SerializeField] private float m_baseProductionRate;
    public float BaseProductionRate
    {
        get => m_baseProductionRate;
        private set => m_baseProductionRate = value;
    }

    [SerializeField] private TextMeshProUGUI m_seedsTMPro;
    private int m_seedsAmount;

    // Start is called before the first frame update
    void Awake()
    {
        if (_INSTANCE != null && _INSTANCE != this)
        {
            Destroy(gameObject);
            return;
        }

        _INSTANCE = this;
        GeneratePile();
    }

    // Update is called once per frame
    void Update()
    {
        m_seedsTMPro.text = m_seedsAmount.ToString();
    }

    void GeneratePile()
    {
        foreach (var tileType in m_levelData.TileData)
        {
            for (var i = 0; i < tileType.Amount; i++)
            {
                var tileCard = Instantiate(m_tileCardPrefab, m_pile.transform).GetComponent<TileCard>();
                tileCard.Instantiate(tileType.TileData);
                m_pile.Enqueue(tileCard);
            }
        }
        m_pile.ShufflePile();
    }

    public void AddSeeds(int amount = 1)
    {
        m_seedsAmount += amount;
    }

    public void SelectCard(TileCard card)
    {
        if (SelectedCard != null)
        {
            if (SelectedCard == card)
            {
                return;
            }
            SelectedCard.Select(false);
        }
        SelectedCard = card;
    }

    public void PlaceCard(TileCard card)
    {
        card.Remove();
        SelectedCard = null;
    }
}
