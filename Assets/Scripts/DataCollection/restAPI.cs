using UnityEngine;
using Proyecto26;
using System.Collections.Generic;

[System.Serializable]
public class CommTool {
  public string datetime;
  public string id;
  public double x;
  public double y;
  public bool doubleClick;
}

[System.Serializable]
public class Favorite {
  public string datetime;
  public string id;
  public double x;
  public double y;
  public int favorite_id;
}

[System.Serializable]
public class Setting {
  public string datetime;
  public string id;
  public string representation;
}

[System.Serializable]
public class Game {
  public string datetime;
  public string id;
  public double target_x; 
  public double target_y; 
  public int level; 
  public int num_other_targets; 
  public double shot_x; 
  public double shot_y; 
  public bool success; 
  public int tries_left;
}

public class restAPI : MonoBehaviour {

	// api.php database set to "emosonics"

	private static readonly string id = SystemInfo.deviceUniqueIdentifier; 
	private static readonly string serverPath = "http://ec2-18-195-226-50.eu-central-1.compute.amazonaws.com/api.php/";

	public static void SendUsage(double x, double y, bool doubleClick){

		/**
   		* Sends coordinates and boolean toggle of a double click or 
		* not to data collection server
		*
   		* @param x x coordinate of click in unit circle
		* @param y y coordinate of click in unit circle
		* @param doubleClick False if play Button was pressed, True otherwise
   		*/

		string database = "commTool";

		string datetime = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

		if (Application.internetReachability != NetworkReachability.NotReachable) {
			RestClient.Post<CommTool>(serverPath + database, new CommTool {
				datetime = datetime,
				id = id,
				x = x,
				y = y,
				doubleClick = doubleClick
			});
		}

	}

	public static void SendFavorite(double x, double y, int favorite_id) {

		/**
   		* Sends x and y coordinates of a favorite and it's ID when
		* clicked to the data collection server
		*
   		* @param x x coordinate of favorite location in unit circle
		* @param y y coordinate of favorite location in unit circle
		* @param favorite_id number of favorite between 1 and 4
   		*/

		string database = "favorites";

		string datetime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

		if (Application.internetReachability != NetworkReachability.NotReachable) {
			RestClient.Post<Favorite>(serverPath + database, new Favorite {
				datetime = datetime,
				id = id,
				x = x,
				y = y,
				favorite_id = favorite_id
			});
		}

	}

	public static void SendSetting(string representation) {

		/**
   		* Sends visualization and representation setting data
		* to data collection server
		*
   		* @param visualization 0 if russel or 1 if unit distribution of anchors is used
		* @param representation 0 if points or 1 if text representation of anchors is used
   		*/

		string database = "settings";

		string datetime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

		if (Application.internetReachability != NetworkReachability.NotReachable) {
			RestClient.Post<Setting>(serverPath + database, new Setting {
				datetime = datetime,
				id = id,
				representation = representation
			});
		}

	}

	public static void SendGame(double target_x, double target_y, int level, int num_other_targets, double shot_x, double shot_y, bool success, int tries_left) {

		/**
   		* Sends game shot data to data collection server
		*
   		* @param target_x x coordinate of target sound
   		* @param target_y y coordinate of target sound
		* @param level current level/difficulty
		* @param num_other_targets number of other targets on board
		* @param shot_x x coordinate of collision of shot with board
		* @param shot_y y coordinate of collision of shot with board
		* @param success True if correct target was hit, False otherwise
		* @param tries_left number of tries player has left before game over
   		*/

		string database = "game";

		string datetime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

		if (Application.internetReachability != NetworkReachability.NotReachable) {
			RestClient.Post<Game>(serverPath + database, new Game {
				datetime = datetime,
				id = id,
				target_x = target_x, 
				target_y = target_y, 
				level = level, 
				num_other_targets = num_other_targets, 
				shot_x = shot_x, 
				shot_y = shot_y, 
				success = success, 
				tries_left = tries_left,
			});
		}

	}
}