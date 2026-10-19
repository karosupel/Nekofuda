using UnityEngine;
using UnityEngine.Events;

public class CardScriptUI : MonoBehaviour
{
    private UnityEvent<int> getCurrentIndex = new UnityEvent<int>();

    public void ScaleUp()
    {
        gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void ScaleDown()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    
    public void GetCurrentIndex()
    {
        int id = gameObject.GetComponent<Card>().Id;
        getCurrentIndex.Invoke(id);
        GameManagerScript.Instance.PublishCardIndex(id);
    }
}
