using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Singleton
    public static LevelManager sharedInstance;

    //Lista de los distintos level blocks
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();

    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();

    //posicion del Primer bloque
    public Transform levelStartPosition;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // añadiendo bloques
    public void AddLevelBlock()
    {

    }
    // eliminando bloques
    public void RemoveLevelBlock()
    {

    }
    // eliminar todo
    public void RemoveAllLevelBlocks()
    {

    }
    //Generar la zona de inicio (almenos inicio y siguiente)
    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 2; i++)
        {
            AddLevelBlock();
        }
    }
}
