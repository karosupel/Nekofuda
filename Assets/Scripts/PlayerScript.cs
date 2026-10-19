using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameObject playerHandCanvas;
    [SerializeField] GameObject[] activeCards = new GameObject[5];

    private void Awake()
    {
        playerHandCanvas = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        GameManagerScript.Instance.addCardToHandEvent.AddListener(AddToHand);
    }

    private void AddToHand(GameObject card)
    {
        GameObject prefabInstance;
        for (int i = 0; i < activeCards.Length; i++)
        {
            if (activeCards[i] == null)
            {
                activeCards[i] = card;
                prefabInstance = Instantiate(card);
                prefabInstance.transform.SetParent(playerHandCanvas.transform, false);
                Debug.Log("Added card to hand: " + card.name);
                return;
            }
        }

        Debug.Log("Hand is full");
    }
}
