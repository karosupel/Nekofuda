using UnityEngine;

[CreateAssetMenu(fileName = "CardStats", menuName = "ScriptableObjects/CardStats", order = 1)]
public class CardStatsSO : ScriptableObject
{
    public int id; //1-36
    public int season; //1-4 (1 is winter)
    public int month; //1-12 (1 is january)
    public bool kanji;
    public bool item;
}
