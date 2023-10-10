using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    [SerializeField]
    private FileDataStoreAdapter _fileDataStoreAdapter;
    [SerializeField]
    private PlayerPrefsDataStoreAdapter _playerPrefsDataStoreAdapter;

    private void Awake()
    {
        //_fileDataStoreAdapter = new FileDataStoreAdapter();
        Data data = new Data("Test", 123);
        //_fileDataStoreAdapter.SetData(data, "TestDataLog");
        //_playerPrefsDataStoreAdapter = new PlayerPrefsDataStoreAdapter();
        _playerPrefsDataStoreAdapter.SetData(data, "TestData");
    }

    private void OnEnable()
    {
        //Data myData = _fileDataStoreAdapter.GetData<Data>("TestDataLog");
        Data myData = _playerPrefsDataStoreAdapter.GetData<Data>("TestData");
        Debug.Log(myData.Dato1);
        Debug.Log(myData.Dato2);
    }
}
