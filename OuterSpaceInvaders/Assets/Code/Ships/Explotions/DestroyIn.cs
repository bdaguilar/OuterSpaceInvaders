using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIn : MonoBehaviour
{
    [SerializeField]
    private float _delay = 2f;

    private void Awake()
    {
        Destroy(gameObject, _delay);
    }
}
