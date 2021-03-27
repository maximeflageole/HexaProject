using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Map m_map;

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
    void Start()
    {
        if (_INSTANCE != null && _INSTANCE != this)
        {
            Destroy(gameObject);
            return;
        }

        _INSTANCE = this;
    }

    // Update is called once per frame
    void Update()
    {
        m_seedsTMPro.text = m_seedsAmount.ToString();
    }

    public void AddSeeds(int amount = 1)
    {
        m_seedsAmount += amount;
    }
}
