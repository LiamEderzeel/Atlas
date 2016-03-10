using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StackPool : MonoBehaviour
{
    public List<GameObject> BlockList
    {
        get{return _blockList;}
    }

    private GameObject _block;
    private List<GameObject> _blockList = new List<GameObject>();

    private void Awake()
    {
        _block = Resources.Load("Prefabs/Block", typeof(GameObject)) as GameObject;
        for(int i =0; i < 8; ++i)
        {
            CreateNew();
        }
    }

    private void Start()
    {
    }

    public GameObject Spawn()
    {
        for (int i = 0; i < _blockList.Count; ++i)
        {
            if ( !_blockList[i].activeInHierarchy )
            {
                _blockList[i].SetActive(true);
                return _blockList[i];
            }
        }

        GameObject obj = CreateNew ();
        obj.SetActive (true);
        //_stackSize = CountStack();
        return obj;
    }

    private GameObject CreateNew()
    {
        GameObject obj = GameObject.Instantiate( _block ) as GameObject;
        _blockList.Add ( obj );
        obj.transform.SetParent(gameObject.transform,false);
        obj.gameObject.transform.Rotate(0,180f,0);
        obj.SetActive( false );
        return obj;
    }
}
