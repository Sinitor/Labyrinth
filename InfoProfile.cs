using UnityEngine;
using System.Collections;
using Firebase.Database;
using UnityEngine.UI;


public class InfoProfile : MonoBehaviour
{
    DatabaseReference dbRef;
    public Text textName;
    public Text textRoom;
    public Text textPhone;
    public Text textNews;

    private void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine(LoadNameData(textName.text));
        StartCoroutine(LoadRoomData(textRoom.text));
        StartCoroutine(LoadPhoneData(textPhone.text));
        StartCoroutine(LoadNewsData(textNews.text));
    }

    public IEnumerator LoadNameData(string email)
    {
        var user = dbRef.Child("Social").Child("Home").GetValueAsync();
        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogError(user.Exception);
        }
        else if (user.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;
            Debug.Log(snapshot.Child("People").Value.ToString());
            textName.text = snapshot.Child("People").Value.ToString();
        }
    }
    public IEnumerator LoadRoomData(string email)
    {
        var user = dbRef.Child("Social").Child("Home").GetValueAsync();
        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogError(user.Exception);
        }
        else if (user.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;
            Debug.Log(snapshot.Child("Room").Value.ToString());
            textRoom.text = snapshot.Child("Room").Value.ToString();
        }
    }
    public IEnumerator LoadPhoneData(string email)
    {
        var user = dbRef.Child("Social").Child("Home").GetValueAsync();
        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogError(user.Exception);
        }
        else if (user.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;
            Debug.Log(snapshot.Child("Phone").Value.ToString());
            textPhone.text = snapshot.Child("Phone").Value.ToString();
        }
    }

    public IEnumerator LoadNewsData(string email)
    {
        var user = dbRef.Child("News").Child("Home").GetValueAsync();
        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogError(user.Exception);
        }
        else if (user.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;
            Debug.Log(snapshot.Child("People").Value.ToString());
            textNews.text = snapshot.Child("People").Value.ToString();
        }
    }
}
