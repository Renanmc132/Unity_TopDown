using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    
    public string tagTargetDetection = "Player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagTargetDetection)
        {
            detectedObjs.Add(collision);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTargetDetection)
        {
            detectedObjs.Remove(collision);
        }
    }





}
