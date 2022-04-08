using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBmanager
{
    public static int userID;
    public static string username;
    public static int score;
    public static string weaponName;
    public static int weaponDamage;
    public static string rangs;
    public static int rounds;
    public static Dictionary<string, int> weaponDB = new Dictionary<string, int>();
    

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}
