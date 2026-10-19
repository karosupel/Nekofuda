using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] CardStatsSO cardStats;
    private int id;
    public int Id
    {get {return cardStats.id;} set{id = value;}}
    private int season;
    private int month;
    private bool kanji;
    private bool item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        id = cardStats.id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
