using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private Vector2 _scrollSpeed = new Vector2(0, 0.5f);
    private Renderer _renderer;
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = Time.time * _scrollSpeed;
        _material.SetTextureOffset(MainTex, offset);
    }

    private void OnDestroy()
    {
        Destroy(_material);
    }
}
