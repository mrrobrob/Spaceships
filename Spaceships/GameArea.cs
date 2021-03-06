﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceships
{
    public class GameArea
    {
        //Properties
        public Ship ship { get; set; }
        public AlienSwarm AlienSwarm { get; set; }

        //Fields
        int maxX = 100;
        int maxY = 100;

        //Constructor function. This shares the name of the class and its type is not defined here.
        public GameArea()
        {
            ship = new Ship();
            ship.X = maxX;
            ship.Y = 1;

            AlienSwarm = new AlienSwarm(maxX, maxY);


        }
        public void Fire(int maxY)
        {
            Gun = new Guns();
            Gun.X = ship.X;
            Gun.Y = ship.Y;


        }

        public Guns Gun { get; set; }

        /// <summary>
        /// Run a game turn, move aliens , move ship, move gun, detect collisions - destroy a collided with object.
        /// </summary>
        public void PlayTurn()
        {
            AlienSwarm.AlienSwarmMove(maxX);
            ship.ShipTurn();
            if (Gun != null)
            {
                Gun.Move();
            }
            var alien = CollisionAlienVsGun();
            if(alien != null)
            {
                AlienSwarm.Aliens.Remove(alien);
            }
           if(CollisionShipVsAlien() == true)
            {

            }

        }
        /// <summary>
        /// Check if X&Y of gun is the same as X&Y of any alien
        /// </summary>
        public Alien CollisionAlienVsGun()
        {
            if (Gun != null)
            {
                foreach (var alien in AlienSwarm.Aliens)
                {
                    if (alien.X == Gun.X && alien.Y == Gun.Y)
                    {
                        return alien;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Check if X/Y of ship is same as X/Y of any alien
        /// </summary>
        public bool CollisionShipVsAlien()
        {
            foreach(var alien in AlienSwarm.Aliens)
            {
                if(alien.X == ship.X && alien.Y == ship.Y)
                {
                    return true;
                }
            }
            return false;
        }
  
    
    }
}
