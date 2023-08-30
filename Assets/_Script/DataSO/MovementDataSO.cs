using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Agent/MovementData")]
public class MovementDataSO : ScriptableObject
{
    [Range(1, 10)]
    public float maxSpeed = 5;

    [FormerlySerializedAs("aceleration")] [Range(0.1f, 100)]
    public float acceleration = 50;

    [Range(0.1f, 100)]
    public float deacceleration = 50;
}
