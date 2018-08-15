using UnityEngine;
using Proyecto26;
using System.Collections.Generic;

[System.Serializable]
public class UsageDataPoint {
  public string datetime;
  public string id;
  public double x;
  public double y;
}

public class restAPI : MonoBehaviour {

	// api.php database set to "emosonics"

	private static readonly string basePath = "https://localhost/api.php/";

	public static void SendUsage(double x, double y){

		string database = "comm_tool_usage";

		string datetime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

		string id = SystemInfo.deviceUniqueIdentifier; 

		Debug.Log(datetime);
		Debug.Log(id);
		Debug.Log(x);
		Debug.Log(y);

		if (Application.internetReachability != NetworkReachability.NotReachable) {
			RestClient.Post<UsageDataPoint>(basePath + database, new UsageDataPoint {
				datetime = datetime,
				id = id,
				x = x,
				y = y
			});
		}

	}
}