using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateCuts : MonoBehaviour
{

    [SerializeField]
    private GameObject cut;
    [SerializeField]
    private float cutDestroyTime;

    private bool dragging = false;
    private Vector2 swipeStart;

    
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            this.dragging = true;
            this.swipeStart = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else if ((Input.GetTouch(0).phase == TouchPhase.Ended) && this.dragging)
        {
            this.createCut();
        }
    }

    private void createCut()
    {
        this.dragging = false;
        Vector2 swipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject cut = Instantiate(this.cut, this.swipeStart, Quaternion.identity) as GameObject;
        cut.GetComponent<LineRenderer>().SetPosition(0, this.swipeStart);
        cut.GetComponent<LineRenderer>().SetPosition(1, swipeEnd);
        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = new Vector2(0.0f, 0.0f);
        colliderPoints[1] = swipeEnd - this.swipeStart;
        cut.GetComponent<EdgeCollider2D>().points = colliderPoints;
        Destroy(cut.gameObject, this.cutDestroyTime);
    }
}