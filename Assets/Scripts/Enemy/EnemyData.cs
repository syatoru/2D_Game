using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData",menuName = "自作データ/EnemyData")]
public class EnemyData : ScriptableObject
{

    public string Name;
    public int EnemyPattern;
    public float EnemyHP;
    public float EnemyDF;
    public float EnemyPA;
    public float EnemyEXP;
    public float EnemySpeed;
}
