# firebase-csharp
Unity-friendly Lightweighted Firebase REST API Wrapper in C#

Copyright (c) 2016  M Dikra Prasetya

## Background

Our current offical Firebase-Unity has not yet covered platforms other than Editor, Android, and iOS. 

If you only need to call simple methods, you could simply implement all of it with REST calls in Unity by yourself, or, you could use my implementation!

I thought it maybe helpful to many of you guys out there. So, enjoy this plugin, and if possible, contribute to make this plugin complete!

## Sample Usage

I tried to make its behaviour as alike as possible with the official plugins. In Unity, wrap your firebase methods with IEnumerator coroutine manually or use Firebase.ToCoroutine() to make it Asynchronus. If not, your script should be waiting until the method's completed.

```
firebase = Firebase.CreateNew("samplefirebasecsharp.firebaseio.com");

firebase.Child("Messages").Push("{ name: \"firebase-csharp\", message: \"awesome!\"}", true);

firebase.OnFetchSuccess += (Firebase sender, DataSnapshot snapshot)=>{
	Debug.Log("[OK] Get from " + sender.Endpoint + ": " + snapshot.RawJson);
};

firebase.OnFetchFailed += (Firebase sender, FirebaseError err)=>{
	Debug.Log("[ERR] Get from " + sender.Endpoint + ": " + err.Message);
};

StartCoroutine(Firebase.ToCoroutine(firebase.GetValue, "print=pretty"));
```

On queries, you can either use the provided FirebaseParam struct or insert your own string parameter.

```
StartCoroutine(Firebase.ToCoroutine(firebase.GetValue, FirebaseParam.Empty.Shallow().OrderByKey()));
StartCoroutine(Firebase.ToCoroutine(firebase.GetValue, "shallow=true&orderBy=\"$key\""));
```

## Releases

###v0.1
Simply wraps-up all of the basic methods of Firebase REST API which is documented in https://www.firebase.com/docs/rest/

## Notes
1. This plugin has been tested and works like a charm on Desktop (Windows & Mac), iOS, and Android. 
2. This version does not support Web platforms, as the current Unity Web still have limitations on HTTP Rest methods.
3. Token generation is not yet supported.

## License
MIT
