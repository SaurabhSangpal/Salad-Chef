# Salad-Chef
This is a video game
## Prerequisites
Unity Engine 2019.1.0f2.
Visual Studio or Mono Develop.
## Status
There are two player characters, can be controlled by WASD and arrow keys
and both have collision detection.
Bricks are the borders, the player can't leave the play area.

Players can pick up the vegetables by pressing __Special__ key (__SPACE__
and __ENTER__) from either side of the room and chop it on the chopping
board. The player can give the chopped vegetables to the customers and
if they give the correct combination, they get points.

Each player has a separate inventory and can hold up to two vegetables at a time.

There is a timer on each customer and the player must give the correct
combination before the timer expires. If the players fail to do so, 3 points
will be deducted from both of them.

If a player gives incorrect combination to a customer, the customer gets
angry and his timer moves twice as fast. If an angry customer leaves, the
negative points are doubled and given to the player who gave the incorrect
order.

Player timer shows up at bottom left/right.
Game timer shows up at top right corner.

## TODO
Fix cutting time (it is taking too long)
Spawn boosters when player gives correct combination within 70% of customer
waiting time.

# Disclaimer
None of the images (except bar2.png) used in this game are created or owned
by me. All of the images used in this game are licensed under a Creative
Commons license.
