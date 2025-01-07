using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer m_Renderer;

    public float aniamtionSpeed = 1f;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        m_Renderer.material.mainTextureOffset += new Vector2(aniamtionSpeed * Time.deltaTime,0); // Adjust the texture offset to create the parallax effect 
    }
}
