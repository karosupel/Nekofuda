using UnityEngine;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{
    private GameObject playerHandCanvas;
    [SerializeField] List<GameObject> activeCards = new List<GameObject>();

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
        for (int i = 0; i < 5; i++) //5 is the limit of cards in hand
        {
            if (activeCards[i] == null)
            {
                activeCards.Add(card);
                prefabInstance = Instantiate(card);
                prefabInstance.transform.SetParent(playerHandCanvas.transform, false);
                Debug.Log("Added card to hand: " + card.name);
                return;
            }
        }

        Debug.Log("Hand is full");
    }
}
