using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class BGScrollingParallax : MonoBehaviour
{
    public float backgroundSize;
    public Speed bgScrollSpeed;

    private Transform m_cameraTransform;
    private Transform[] m_layers;
    private float m_viewZone = 10;
    private int m_leftIndex;
    private int m_rightIndex;
    // Start is called before the first frame update
    void Start()
    {
        m_cameraTransform = Camera.main.transform;
        //Counts the number of backgrounds in the bg object
        m_layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            m_layers[i] = transform.GetChild(i);

        m_leftIndex = 0;
        m_rightIndex = m_layers.Length - 1;
    }

    /// <summary>
    /// This Function scrolls left
    /// </summary>
    private void ScrollLeft()
    {
        int lastRight = m_rightIndex;
        m_layers[m_rightIndex].position = Vector3.right * (m_layers[m_leftIndex].position.x - backgroundSize);
        m_leftIndex = m_rightIndex;
        m_rightIndex--;
        if (m_rightIndex < 0)
            m_rightIndex = m_layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = m_leftIndex;
        m_layers[m_leftIndex].position = Vector3.right * (m_layers[m_rightIndex].position.x + backgroundSize);
        m_rightIndex = m_leftIndex;
        m_leftIndex++;
        if (m_leftIndex == m_layers.Length)
            m_leftIndex = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        if (m_cameraTransform.position.x < (m_layers[m_leftIndex].transform.position.x + m_viewZone))
            ScrollLeft();
        if (m_cameraTransform.position.x > (m_layers[m_rightIndex].transform.position.x - m_viewZone))
            ScrollRight();
        transform.position += new Vector3(-bgScrollSpeed.minSpeed,0);
    }
}
