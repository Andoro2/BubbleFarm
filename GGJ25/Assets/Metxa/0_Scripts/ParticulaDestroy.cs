using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaDestroy : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (!_particleSystem.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
