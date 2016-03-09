using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BridgeManager : MonoBehaviour {

    [SerializeField] private List<Bridge> _bridgeList = new List<Bridge>();
    private GameObject _bridgeParts;

    private void Awake ()
    {
        _bridgeParts = Resources.Load("Prefabs/BridgePart", typeof(GameObject)) as GameObject;
    }

	private void Start ()
    {
        int position = 27;
        for(int i = 0; i < 8; ++i)
        {
            GameObject obj = Instantiate(_bridgeParts, new Vector3(0,0,0), Quaternion.identity) as GameObject;
            obj.transform.name = "Bridge_Part_" + i;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = new Vector3(0,0,position);
            _bridgeList.Add(obj.GetComponent<Bridge>());
            position -= 9;
        }

        for(int i = 0; i < _bridgeList.Count; ++i)
        {
            _bridgeList[i]._playerPressent += PlayerPressent;
        }
	}

    private void PlayerPressent(Bridge bridge)
    {
        if(_bridgeList[4] == bridge)
        {
            _bridgeList[0].gameObject.transform.position += new Vector3(0,0,-72f);
            _bridgeList.Add(_bridgeList[0]);
            _bridgeList.RemoveAt(0);
        }
    }
}
