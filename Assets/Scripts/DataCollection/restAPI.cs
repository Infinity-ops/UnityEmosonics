using UnityEngine;
using Proyecto26;
using System.Collections.Generic;

[System.Serializable]
public class DataPoint {
  public string datetime;
  public string id;
  public double x;
  public double y;
}

public class restAPI : MonoBehaviour {

	private static readonly string basePath = "https://localhost/api.php/usage_data";

	public static void SendData(string datetime, string id, double x, double y){

		if (Application.internetReachability != NetworkReachability.NotReachable) {
			RestClient.Post<DataPoint>(basePath, new DataPoint {
				datetime = datetime,
				id = id,
				x = x,
				y = y
			});
		}

	}
}