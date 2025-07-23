using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemies/Zombie")]
public class Zombie : ScriptableObject
{
    public int hp;
    public NavMeshAgent agent;
    public bool alive;
}
