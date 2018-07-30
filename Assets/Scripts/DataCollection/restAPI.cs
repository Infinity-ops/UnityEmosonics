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

	private static readonly string basePath = "https://localhost/api.php/";

	public static void SendUsage(string datetime, string id, double x, double y, string database){

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