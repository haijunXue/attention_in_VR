using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position4vector : MonoBehaviour
{
    // Start is called before the first frame update
    //BoxCollider b;
    Mesh mesh;
    Vector3[] vertices;
   // public GameObject  someRandomGameobject;
    Renderer rend;
    public void Start()
    {
      //  Vector3[] meshVerts = someRandomGameobject.GetComponent().mesh.vertices;
       // GetComponent().mesh.vertices;
        //Vector3 vertPos = transform.position + transform.TransfomrPoint(meshVerts[0]);
        //Debug.Log(vertPos);
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        rend = GetComponent<Renderer>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        //Vector3[] verts = new Vector3[4]; 
       // verts[0] = b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
       // verts[1] = b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;
       // verts[2] = b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f;
        //verts[3] = b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f;

        //Debug.Log("Verts[0]: "+ verts[0]);
      //  Vector3[] corners = new Vector3[4];
       // gameObject.GetComponent<RectTransform>().GetWorldCorners(corners);
       // foreach (var item in corners)
       // {
        //    Debug.Log(item);
        //}
       // for (var i = 0; i < vertices.Length; i++)
        //{
           // vertices[i] += Vector3.up * Time.deltaTime;
        //    Vector3 vertPos =  transform.TransformPoint(vertices[i]);
        //    Debug.Log(vertPos +"  the " +i + " position");
        //    Debug.Log(transform.position);
        //}
        Vector3 center = rend.bounds.center;
        Debug.Log("center" + center);
        float radius = rend.bounds.extents.magnitude;
        Debug.Log("radius " + radius );
        Vector3 p1 = center - rend.bounds.extents;
        Debug.Log("point1"+ p1 );
        Vector3 p2 = center + rend.bounds.extents;
        Debug.Log("point2"+ p2 );
        Debug.Log("the extension is : " + rend.bounds.extents);

       
    }

}
