using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] protected HungerBar m_hungerBar;
    [SerializeField] protected float m_maxHunger;
    protected float m_currentHunger;

    private void Awake()
    {
        m_currentHunger = m_maxHunger;
    }

    void Update()
    {
        
    }
}
