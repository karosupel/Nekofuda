using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int[,] board = new int[4,3];
    [SerializeField] private GameObject[] dircardPile = new GameObject[35];
    [SerializeField] private GameObject[] drawPile = new GameObject[35];

    [SerializeField] static private GameObject[] deck = new GameObject[35];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drawPile = deck;
    }

    private GameObject[] Shuffle(GameObject[] deckToShuffle)
    {
        return null;
    }
}
