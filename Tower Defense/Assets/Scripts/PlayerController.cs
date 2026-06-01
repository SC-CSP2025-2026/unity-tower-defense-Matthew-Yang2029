using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public int Gold { get; private set; } = 200;
    [field: SerializeField]
    public TextMeshProUGUI InfoLabel { get; private set; }

    public void SpendGold(int amount)
    {
        Gold -= amount;
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }

    void Start()
    {
        InfoLabel.text = "Click Build to Place a Turret";
    }

    void Update()
    {

    }
}
