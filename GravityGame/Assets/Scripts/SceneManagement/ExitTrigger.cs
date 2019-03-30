using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public enum PlayerExit {Player1, Player2, Both};
    public PlayerExit Exit;

    public Color[] PlayerColors;

    SpriteRenderer m_SpriteRenderer;
    
    public bool isTriggerActive;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Color m_color;

        if (Exit == PlayerExit.Player1)
            m_color = PlayerColors[0];
        else if (Exit == PlayerExit.Player2)
            m_color = PlayerColors[1];
        else
            m_color = PlayerColors[2];

        m_SpriteRenderer.color = m_color;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Exit == PlayerExit.Player1)
        {
            if (collision.tag == "Player1")
                isTriggerActive = true;
        }
        else if (Exit == PlayerExit.Player2)
        {
            if (collision.tag == "Player2")
                isTriggerActive = true;
        }
        else
        {
            if (collision.tag == "Player1" || collision.tag == "Player2")
                isTriggerActive = true;
        }
            

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Exit == PlayerExit.Player1)
        {
            if (collision.tag == "Player1")
                isTriggerActive = false;
        }
        else if (Exit == PlayerExit.Player2)
        {
            if (collision.tag == "Player2")
                isTriggerActive = false;
        } else
        {
            if (collision.tag == "Player1" || collision.tag == "Player2")
                isTriggerActive = false;
        }
    }
}
