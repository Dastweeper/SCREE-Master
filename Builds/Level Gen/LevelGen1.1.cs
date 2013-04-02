using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LevelGenerator
{
    public static void LoadMap(Size map_size, int max_players, float crystal_density, float map_density)
    {
        int planetNum = GetNumberOfPlanets(map_size, max_players);
        for (int i = 0; i < planetNum; i++)
        {
            Planets[] planets = new Planet[planetNum];
            float size;
            float mass;

            //We will be adding 1/2 times the mapDensity to each planet to allow adequate space once we reduce
            size += (map_density * .5);   
 
            //Random Mass, random.Next(int,int)
            Random random = new Random();
            mass = random.Next(20,100);

            //Vector3 (x : float, y : float, z : float)
            //We will be randomly creating the location of the planets
            //Z offset by a number (10) each time to ensure that objects are not inside objects
            //x = random location in bounds of map
            //y = random location in bounds of map
            //The idea is that the planets will fall to the flat map, if any plants are too close they will not be on top of each other.
            float x,y;
            x = random.Next(0,100);
            y = random.Next(0,100);
            
            Vector3 center = new Vector3(x,y,((i+1)*10));
            
            //Do we want to set a planet health?
            //health = random.Next(0,100);

            /*
             * 
             * 
             */
            planets[i] = Planet.SetUp(Vector3 center, float mass, float size);
        }
    //setPlayers(planets);
        //We will set the players as far away as possible, or far enough away as specified?????????????????????????????????
    //setCrystals(planets);
        //We will set non-optional crystals as close to player as possible, or at specified range????????????????????
    }

    private static int GetNumberOfPlanets(Size map_size, int max_players)
    {
        int numPlanets = 0;

        Random random = new Random();

        switch (map_size)
        {
            case Size.Small:
                numPlanets = 4 * max_players + random.Next(0,2); // + a random 0-2
                break;
            case Size.Medium:
                numPlanets = 8 * max_players + random.Next(0,2); // + a random 0-2
                break;
            case Size.Large:
                numPlanets = 12 * max_players + random.Next(0,2); // + a random 0-2
                break;
        }

        return numPlanets;
    }
}

enum Size
{
    Small,
    Medium,
    Large
}