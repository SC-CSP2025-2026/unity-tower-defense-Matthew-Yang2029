using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurretPrefab { get; private set; }
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }
    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void OnEnable()
    {
        Controller.InfoLabel.text = "Select a Tile";
        foreach (TileController tile in TargetGrid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(ShowInfo);
            tile.OnCursorExit.AddListener(ResetInfo);
            tile.OnCursorClick.AddListener(SpawnTurret);
        }
    }

    void OnDisable()
    {
        if (TargetGrid == null) { return; }
        Controller.InfoLabel.text = "Click Build to Place a Turret";
        foreach (TileController tile in TargetGrid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.RemoveListener(ShowInfo);
            tile.OnCursorExit.RemoveListener(ResetInfo);
            tile.OnCursorClick.RemoveListener(SpawnTurret);
        }
    }

    public void ShowInfo(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            Controller.InfoLabel.text = "Cannot build here";
        }
        else if (Controller.Gold < 50)
        {
            Controller.InfoLabel.text = "<color=red>Not Enough Gold</color>";
        }
        else
        {
            Controller.InfoLabel.text = "50 Gold - Place Turret";
        }
    }

    public void ResetInfo(TileController tileController)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }

    public bool CanSpawn(TileController tileController)
    {
        if (tileController.IsOccupied) { return false; }
        if (Controller.Gold < 50) { return false; }
        return true;
    }

    public void SpawnTurret(TileController tileController)
    {
        if (!CanSpawn(tileController)) { return; }
        GameObject newTurret = Instantiate(TurretPrefab);
        newTurret.transform.position = tileController.transform.position;
        tileController.SetOccupied(true);
        Controller.SpendGold(50);
        gameObject.SetActive(false);
    }
}
