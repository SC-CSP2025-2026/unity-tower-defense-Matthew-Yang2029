using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [field: SerializeField]
    public BuildingData Selected { get; set; }
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
        if (Selected == null) { return; }
        if (tileController.IsOccupied)
        {
            Controller.InfoLabel.text = "Cannot build here";
        }
        else if (Controller.Gold < Selected.Cost)
        {
            Controller.InfoLabel.text = "<color=red>Not Enough Gold</color>";
        }
        else
        {
            Controller.InfoLabel.text = $"{Selected.Cost} Gold - Place Turret";
        }
    }

    public void ResetInfo(TileController tileController)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }

    public bool CanSpawn(TileController tileController)
    {
        if (Selected == null) { return false; }
        if (tileController.IsOccupied) { return false; }
        if (Controller.Gold < Selected.Cost) { return false; }
        return true;
    }

    public void SpawnTurret(TileController tileController)
    {
        if (!CanSpawn(tileController)) { return; }
        tileController.IsOccupied = true;
        GameObject newTurret = Instantiate(Selected.BuildingPrefab, Controller.transform);
        newTurret.transform.position = tileController.transform.position;
        Controller.Gold -= Selected.Cost;
        gameObject.SetActive(false);
    }
}
