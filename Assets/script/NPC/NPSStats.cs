using UnityEngine;

[CreateAssetMenu(fileName = "NPSStats", menuName = "Stats/NPSStats", order = 1)]
public class NPSStats : ScriptableObject
{
[SerializeField] private NPCType _Type;
	[SerializeField] private NPCName _Name;
	[SerializeField] private int _health;
[SerializeField] private int _Attack;
[SerializeField] private int _Speed;
	public int Health => _health;
	public int Attack => _Attack;
	public int Speed => _Speed;
	public NPCType Type => _Type;
	public NPCName Name => _Name;
}
public enum NPCType
{
	Enemy,
	Friendly,
	Neutral
}
public enum NPCName
{
	None,
	Bob=Consts.EnemyStart+1,
	Zora,
	ura,
	Friendly1,
	Friendly2,
	Friendly3
}
public static class Consts
{
	public const int EnemyStart = 1000;
	
}