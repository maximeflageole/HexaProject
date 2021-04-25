using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    protected TextMeshPro m_textMesh;
    [SerializeField]
    protected AnimationCurve m_animCurveYAxis;
    [SerializeField]
    protected float m_maxHeight = 1.5f;
    protected float m_xAxisVariation;
    protected float m_zAxisVariation;
    [SerializeField]
    protected float m_xAndYMaxVariation = 1.0f;
    protected float m_timeDisplayed = 0.0f;
    protected float m_duration;
    protected Vector3 m_initialPos;

    private void Awake()
    {
        m_initialPos = transform.position;
    }

    public void Init(string value, bool xAndYVariation = false, float duration = 1)
    {
        m_textMesh.enabled = true;
        m_duration = duration;
        m_textMesh.text = value;
        var material = GetComponent<MeshRenderer>().material;
        material.renderQueue = 5000;
        m_xAxisVariation = Random.Range(-1.0f, 1.0f);
        m_zAxisVariation = Random.Range(-1.0f, 1.0f);
        if (!xAndYVariation) m_xAndYMaxVariation = 0.0f;
        m_timeDisplayed = 0.0f;
    }

    private void Update()
    {
        m_timeDisplayed += Time.deltaTime;
        if (m_timeDisplayed > m_duration)
        {
            m_textMesh.enabled = false;
            return;
        }
        var lifetime = m_timeDisplayed / m_duration;
        var evaluation = m_animCurveYAxis.Evaluate(lifetime);
        transform.position = m_initialPos + new Vector3(m_xAxisVariation * lifetime * m_xAndYMaxVariation, m_zAxisVariation * lifetime * m_xAndYMaxVariation, -evaluation * m_maxHeight);
        m_textMesh.alpha = Mathf.Min(1.8f - (lifetime * 1.8f), 1.0f); //0.6
    }
}
