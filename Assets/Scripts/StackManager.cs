using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StackManager : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3(0, 12f, 0);
    private StackPool _stackPool;
    [SerializeField] private int _stackSize;
    public bool _spawning = true;
    public int StackSize
    {
        get{return _stackSize;}
    }
    private float _timer;

    private void Awake()
    {
        _stackPool = gameObject.GetComponent<StackPool>();
        print(_stackPool);
    }

    private void Start()
    {
        GameObject obj = Spawn();
        obj.transform.position += spawnPos;
        GameObject obj1 = Spawn();
        obj1.transform.position += spawnPos;
        SetTimer();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            GameObject obj = Spawn();
            obj.transform.position += spawnPos;
        }

        if(_stackSize < 10)
        {
            if(Time.time > _timer && _spawning)
            {
                GameObject obj = Spawn();
                obj.transform.position += spawnPos;
                SetTimer();
            }
        }
    }

    private GameObject Spawn()
    {
        GameObject obj = _stackPool.Spawn();
        _stackSize = CountStack();

        return obj;
    }

    private void SetTimer()
    {
        _timer = Time.time + 5f;
    }

    private int CountStack()
    {
        int count = 0;
        foreach(Transform child in transform)
        {
            if ( child.gameObject.activeInHierarchy )
            {
                count++;
            }
        }
        return count;
    }

    public void OnTriggerExit (Collider collider)
    {
        if(collider.tag == "block")
        {
            print("unparent");
            //transform.parent = null;
            collider.GetComponent<block>().UnParrent();
        }
    }

    public void ActivatePhysics()
    {
        for (int i = 0; i < _stackPool.BlockList.Count; ++i)
        {
            if (_stackPool.BlockList[i].activeInHierarchy )
            {
                _stackPool.BlockList[i].GetComponent<block>().ActivatePhysics();
            }
        }
    }

    public void DeactivatePhysics()
    {
        for (int i = 0; i < _stackPool.BlockList.Count; ++i)
        {
            if ( _stackPool.BlockList[i].activeInHierarchy )
            {
                _stackPool.BlockList[i].GetComponent<block>().DeactivatePhysics();
            }
        }
    }

    public void SavePosition()
    {
        for (int i = 0; i < _stackPool.BlockList.Count; ++i)
        {
            if ( _stackPool.BlockList[i].activeInHierarchy )
            {
                _stackPool.BlockList[i].GetComponent<block>().SavePosition();
            }
        }
    }

    public void ReturnPosition()
    {
        _stackSize = CountStack();
        for (int i = 0; i < _stackPool.BlockList.Count; ++i)
        {
            if ( _stackPool.BlockList[i].activeInHierarchy )
            {
                _stackPool.BlockList[i].GetComponent<block>().ReturnPosition();
            }
        }
    }

}
