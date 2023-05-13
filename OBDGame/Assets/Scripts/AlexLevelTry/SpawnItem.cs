using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private GameObject buildingToPlace;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)
        {
            GameObject instance = Instantiate(buildingToPlace, Input.mousePosition, Quaternion.identity);
            instance.transform.SetParent(transform, false);
            //Instantiate(buildingToPlace, Input.mousePosition, Quaternion.identity);
            buildingToPlace = null;
        }
    }

    public void ConstructionBuilding(GameObject building)
    {
        buildingToPlace = building;
    }
}
