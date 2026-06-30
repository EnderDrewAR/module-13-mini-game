using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int CollectedCoins { get; private set; } = 0;

    public int Score { get; private set; } = 0;
    
    public void AddCoin(int value)
    {
        CollectedCoins += 1;  
        Score += value; 
    }
}
