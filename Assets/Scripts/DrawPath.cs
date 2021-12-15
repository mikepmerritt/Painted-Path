using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawPath : MonoBehaviour
{
    public GameObject PathPrefab;
    public Vector3 LastClickLocation;
    public bool MouseHeld;
    public int MaxPathCount;
    public static int CurrentPathCount = 0;
    public Image Fill;
    public GameObject[] NoDrawBoxes;

    public void Start()
    {
        NoDrawBoxes = GameObject.FindGameObjectsWithTag("No Draw");
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            MouseHeld = false;
        }
        Fill.fillAmount = 0.01f * (MaxPathCount - CurrentPathCount);
        if(CurrentPathCount < 0)
        {
            CurrentPathCount = 0;
        }
        if (CurrentPathCount > MaxPathCount)
        {
            CurrentPathCount = MaxPathCount;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(MouseHeld)
            {
                // draw in between last click and current click if the distance was too large for the artist to walk
                float distanceBetween = Mathf.Sqrt((mousePosition.x - LastClickLocation.x) * (mousePosition.x - LastClickLocation.x) + (mousePosition.y - LastClickLocation.y) * (mousePosition.y - LastClickLocation.y));
                if (distanceBetween > 0.2f)
                {
                    int numDotsToDraw = Mathf.FloorToInt(distanceBetween / 0.2f); // calculate the amount of in-between dots that need to be drawn
                    float slopeBetween = (mousePosition.y - LastClickLocation.y) / (mousePosition.x - LastClickLocation.x);
                    float changeX = (mousePosition.x - LastClickLocation.x) / numDotsToDraw; // move horizontally by the 
                    float changeY;
                    if (slopeBetween == float.PositiveInfinity || slopeBetween == float.NegativeInfinity)
                    {
                        changeY = 0f;
                    }
                    else
                    {
                        changeY = slopeBetween * changeX;
                    }

                    Vector3 tempPosition = LastClickLocation;

                    for (float remainingDistanceToDraw = distanceBetween; remainingDistanceToDraw > 0; remainingDistanceToDraw -= 0.2f)
                    {
                        tempPosition += new Vector3(changeX, changeY, 0);
                        CreatePathObject(tempPosition);
                    }
                }
            }

            CreatePathObject(mousePosition);
            LastClickLocation = mousePosition;
            MouseHeld = true;
        }
    }

    public GameObject CreatePathObject(Vector3 position)
    {
        if(CurrentPathCount < MaxPathCount)
        {
            bool draw = true; // draw path dot by default
            foreach (GameObject box in NoDrawBoxes)
            {
                // if inside the bounds of the no draw box
                if((position.x >= box.GetComponent<NoDrawBox>().minX && 
                    position.x <= box.GetComponent<NoDrawBox>().maxX) &&
                   (position.y >= box.GetComponent<NoDrawBox>().minY &&
                    position.y <= box.GetComponent<NoDrawBox>().maxY))
                {
                    draw = false; // in box, so don't draw
                }
            }
            if (draw)
            {
                GameObject newObject = Instantiate(PathPrefab, position + new Vector3(0, 0, 10), Quaternion.identity);
                CurrentPathCount++;
                return newObject;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
