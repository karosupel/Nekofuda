using UnityEngine;
using UnityEngine.Events;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }
    private int[,] board = new int[4,3];
    [SerializeField] private GameObject[] dircardPile = new GameObject[36];
    [SerializeField] private GameObject[] drawPile = new GameObject[36];

    [Header("NIE RUSZAC")]
    [SerializeField] private GameObject[] deck = new GameObject[36];
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public UnityEvent<GameObject> addCardToHandEvent = new UnityEvent<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        drawPile = Shuffle(deck);
        AddCardToHand(5);
    }

    private GameObject[] Shuffle(GameObject[] deckToShuffle)
    {
        int j = 0;
        GameObject swap;
        for(int i=deckToShuffle.Length-1; i>1; i--)
        {
            j = Random.Range(0,i);
            swap = deckToShuffle[i];
            deckToShuffle[i] = deckToShuffle[j];
            deckToShuffle[j] = swap;
        }
        return deckToShuffle;
    }

    public void AddCardToHand(int howMany)
    {
        for(int i=0; i<howMany; i++)
        {
            addCardToHandEvent.Invoke(drawPile[i]);
        }
    }
}
