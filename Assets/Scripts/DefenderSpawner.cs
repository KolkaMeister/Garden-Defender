using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    StarsDisplay starsDisplay;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "defenders";
    void Start()
    {
        CteateDefenderParent();
        starsDisplay =FindObjectOfType<StarsDisplay>();
    }
    void CteateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }
    public void SetSelectedDefender(Defender selectedDefender )
    {
        defender = selectedDefender;
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return GetRoundedPos(worldPos);
    }
    private Vector2 GetRoundedPos(Vector2 worldPos)
    {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Vector2 roundedPos)
    {
        if (defender!=null && starsDisplay.stars>= defender.cost)
        {
        Defender newDefender= Instantiate(defender, roundedPos, Quaternion.identity);
        starsDisplay.SpendStars(defender.cost);
            newDefender.transform.parent = defenderParent.transform;
        }
    }
}
