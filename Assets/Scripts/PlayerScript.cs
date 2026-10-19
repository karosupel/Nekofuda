using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{
    private GameObject playerHandCanvas;
    private int activeIndex = 0;
    private bool hasStarted;
    [SerializeField] List<GameObject> activeCards = new List<GameObject>();


    private void Awake()
    {
        playerHandCanvas = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        if (hasStarted)
        {
            SubscribeToEvents();
        }
    }

    private void Start()
    {
        hasStarted = true;
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        if (hasStarted && GameManagerScript.Instance != null)
        {
            GameManagerScript.Instance.addCardToHandEvent.RemoveListener(AddToHand);
            GameManagerScript.Instance.cardIndexEvent.RemoveListener(DisplayIndex);
        }
    }

    private void SubscribeToEvents()
    {
        GameManagerScript.Instance.addCardToHandEvent.AddListener(AddToHand);
        GameManagerScript.Instance.cardIndexEvent.AddListener(DisplayIndex);
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

    private void DisplayIndex(int index)
    {
        activeIndex = index;
        Debug.Log("current index: " + activeIndex);
    }
}
