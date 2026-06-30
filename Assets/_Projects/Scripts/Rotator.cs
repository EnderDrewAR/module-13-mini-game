using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
    private int _firstSide = 1;
    private int _secondSide = -1;
    
    [SerializeField] private float _rotateSpeed = 50f;
    
    private int _currentSide = 1;

    private void Awake()
    {
        _currentSide = DetermineRotateSide();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _currentSide * _rotateSpeed * Time.deltaTime);
    }

    private int DetermineRotateSide()
    {
        int chance = Random.Range(0, 2);
        
        return chance == 0 ? _firstSide : _secondSide;
    }
}
