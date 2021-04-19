using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SentryCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		var sentry = gameObject.AddComponent<SentrySdk>();
        sentry.Dsn = "https://813e09476a0a42939e6cd5c626cc0133@o559188.ingest.sentry.io/5693691";
        SentrySdk.CaptureMessage("Test event");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
