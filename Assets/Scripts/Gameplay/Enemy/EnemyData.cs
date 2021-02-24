using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "enemyData", menuName = "enemyData", order = 1)]
public class EnemyData : ScriptableObject
{

    public enum TYPE
    {
        BUTO,
        BUTO_ARMOR,
        BUTO_BOSS
    };
    public TYPE type;
    public float speed;
    public int score;
    public string enemyName;
    public int hp;
}
