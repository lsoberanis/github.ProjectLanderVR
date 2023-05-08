using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variableC : MonoBehaviour
{
    // Start is called before the first frame update
    public int formula = 0;
    public float var1 = 1.0f;
    public float var2 = 1.0f;
    public float var3 = 1.0f;
    public float var4 = 1.0f;
    public float var5 = 1.0f; // formula 1 has max 5 var
    public float var6 = 1.0f; // formula 3 has max 6 var
    public float var7 = 1.0f; // formula 2 has max 7 var
    public int varSolveFor = 0; // index variable of which one we are solving for
    public int varIndex = 0; // what variable index we're on
    public float gravity = 0;
    public bool low = false;
    public bool high = false;
    public bool correct = false;
    [SerializeField] private GameObject Mesh_f1_var1;
    [SerializeField] private GameObject Mesh_f1_var2;
    [SerializeField] private GameObject Mesh_f1_var3;
    [SerializeField] private GameObject Mesh_f1_var4;
    [SerializeField] private GameObject Mesh_f1_var5;

    [SerializeField] private GameObject Mesh_f2_var1;
    [SerializeField] private GameObject Mesh_f2_var2;
    [SerializeField] private GameObject Mesh_f2_var3;
    [SerializeField] private GameObject Mesh_f2_var4;
    [SerializeField] private GameObject Mesh_f2_var5;
    [SerializeField] private GameObject Mesh_f2_var6;
    [SerializeField] private GameObject Mesh_f2_var7;

    [SerializeField] private GameObject Mesh_f3_var1;
    [SerializeField] private GameObject Mesh_f3_var2;
    [SerializeField] private GameObject Mesh_f3_var3;
    [SerializeField] private GameObject Mesh_f3_var4;
    [SerializeField] private GameObject Mesh_f3_var5;
    [SerializeField] private GameObject Mesh_f3_var6;
    public Material selectMaterialRef;
    public Material oldMaterialRef;

    static public List<GameObject> f1List;
    static public List<GameObject> f2List;
    static public List<GameObject> f3List;
    [SerializeField] public List<List<GameObject>> parentList;


    void Start()
    {
        f1List = new List<GameObject>();
        f2List = new List<GameObject>();
        f3List = new List<GameObject>();

        f1List.Add(Mesh_f1_var1);
        f1List.Add(Mesh_f1_var2);
        f1List.Add(Mesh_f1_var3);
        f1List.Add(Mesh_f1_var4);
        f1List.Add(Mesh_f1_var5);

        f2List.Add(Mesh_f2_var1);
        f2List.Add(Mesh_f2_var2);
        f2List.Add(Mesh_f2_var3);
        f2List.Add(Mesh_f2_var4);
        f2List.Add(Mesh_f2_var5);
        f2List.Add(Mesh_f2_var6);
        f2List.Add(Mesh_f2_var7);

        f3List.Add(Mesh_f3_var1);
        f3List.Add(Mesh_f3_var2);
        f3List.Add(Mesh_f3_var3);
        f3List.Add(Mesh_f3_var4);
        f3List.Add(Mesh_f3_var5);
        f3List.Add(Mesh_f3_var6);

        parentList = new List<List<GameObject>>();

        parentList.Add(f1List);
        parentList.Add(f2List);
        parentList.Add(f3List);


    }

    public void Reset()
    {
        //formula = 0;
        var1 = -1.0f;
        var2 = -1.0f;
        var3 = -1.0f;
        var4 = -1.0f;
        var5 = -1.0f; // formula 1 has max 5 var
        var6 = -1.0f; // formula 3 has max 6 var
        var7 = -1.0f; // formula 2 has max 7 var
        varSolveFor = 0; // index variable of which one we are solving for
        varIndex = 0; // what variable index we're on

        Mesh_f1_var1.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f1_var2.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f1_var3.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f1_var4.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f1_var5.GetComponent<Renderer>().material = oldMaterialRef;

        Mesh_f2_var1.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f2_var2.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f2_var3.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f2_var4.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f2_var5.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f2_var6.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f2_var7.GetComponent<Renderer>().material = oldMaterialRef;

        Mesh_f3_var1.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f3_var2.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f3_var3.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f3_var4.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f3_var5.GetComponent<Renderer>().material = oldMaterialRef;
        Mesh_f3_var6.GetComponent<Renderer>().material = oldMaterialRef;

    }

}





