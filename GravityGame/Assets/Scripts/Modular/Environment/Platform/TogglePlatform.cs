using UnityEngine;

public class TogglePlatform : MonoBehaviour, IToggleable
{
    public Player_ManipController manipulatorController;

    private BoxCollider m_boxCollider;
    private MeshRenderer m_meshRenderer;

    private void Awake()
    {
        manipulatorController = GetComponent<Player_ManipController>();

        m_boxCollider = GetComponent<BoxCollider>();
        m_meshRenderer = GetComponent<MeshRenderer>();
    }

    //enables and disables the platform
    public void Toggle()
    {
        if (!m_boxCollider.isTrigger)
        {
            m_boxCollider.isTrigger = true;
            m_meshRenderer.enabled = false;
        }
        else
        {
            m_boxCollider.isTrigger = false;
            m_meshRenderer.enabled = true;
        }
    }
}
