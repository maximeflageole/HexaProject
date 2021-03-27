using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float m_translateSpeed = 5f;
    [SerializeField] private float m_zoomSpeed = 5f;
    [SerializeField] private float m_minZoomLevel = 1.0f;
    [SerializeField] private float m_maxZoomLevel = 10.0f;
    private Camera m_camera;

    private void Awake()
    {
        m_camera = GetComponent<Camera>();
    }

    void Update()
    {
        //I want the camera to go faster when it is "unzoomed" (when orthographic size is bigger)
        var frameSpeed = m_translateSpeed * Time.deltaTime * m_camera.orthographicSize;
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal * frameSpeed, vertical * frameSpeed, 0), Space.World);

        if (m_camera)
        {
            var ortographicSize = m_camera.orthographicSize -(Input.mouseScrollDelta.y * m_zoomSpeed * Time.deltaTime);
            m_camera.orthographicSize = Mathf.Clamp(ortographicSize, m_minZoomLevel, m_maxZoomLevel);
        }
    }
}
