# OrganicCity
A procedural generated city that grows and changes organically over time. The buildings grow and change depending on those around them and the general growth of the city affects the envrionment around it.

# My Vision
I initially set out with the goal of building a city generator that would build everything randomly according to a set of pre-defined rules. The buildings would vary in size, height and density and the road network would change according to where the buildings were and how they built. I wanted something more than that though and decided on bringing the city to life, literally. I wanted the city to grow and develop and impact other buildings around it as well as have a green space or environment that would evolve alongside the city. The rules that would govern this evolution would be similar to [Conway's Game of Life](http://www.conwaylife.com/w/index.php?title=Conway%27s_Game_of_Life) in the sense that there would be a set of rules that would dictate the dynamic of how the city would grow and develop.

![](Photos/2D%20City.png)

The first thing I did after deciding on my idea was to start researching other city generators that already exist and see how they achieved their generation. The first one I came across was a simple 2D generator that generates roads and buildings. The roads can form into intersections and junctions and those affect roads around them by lengthening or shortening them depending on the nearest junction or intersection. Then the population density would also be taken into account when the road was making a decision of where to extend to. The A* was used for pathfinding and the algorithm below was the driving force behind the generation.

Source:https://www.tmwhere.com/city_generation.html

```
initialize priority queue Q with a single entry: r(0, r0, q0)
initialize segment list S to empty

until Q is empty
  pop smallest r(ti, ri, qi) from Q
  accepted = localConstraints(&r)
  if (accepted) {
    add segment(ri) to S
    foreach r(tj, rj, qj) produced by globalGoals(ri, qi)
      add r(ti + 1 + tj, rj, qj) to Q
  }
  ```
  *"r is a road segment with parameters: ti - the time delay until the segment is placed in the world, ri - the geometrical properties of the segment, and qi - any additional metadata associated with the segment. Q is a list of segments yet to be placed in the world. In each iteration of the algorithm the segment with the smallest ti is removed from Q. localConstraints checks the segment for compatibility with all previously placed segments and may modify its geometry if necessary, for example to join the end of the segment to a nearby junction.*

*If the segment is found to be compatible, it is added to the list of placed segments S. The newly placed segment is then fed into globalGoals which decides what, if any, new segments should branch out from it in the future. The implementation of globalGoals is entirely up to the developer: I made the decision for roads to simply tend towards areas of high population density. The original authors added further constraints to create several distinctive categories of road patterns.*

*The behaviour of the algorithm can be visualised by turning on the debug view in the demonstration above. The highlighted path shows the order that segments are placed. Segments can be seen branching out from the main highways, and merging with parallel areas of growth as dictated by the local constraints. The consequence of queueing the segments by ti can also be seen, causing the network to grow roughly uniformly across its circumference and leaving no dangling segment inactive for long."*

![City](Photos/City.png)

Source:https://pjreddie.com/projects/procedural-city-generation/
  
The other city generator I found was a 3D one which focused more on the buildings than the roads, dividing an area into sectors and then subdividing those sectors and applying rules onto them to decide the height, size, light number and density of the buildings. The divisions of the sectors were done using randomly placed control points and these formed the roads and then things such as stop signs and traffic lights were added around their cities.

After looking at these two projects I felt I had a reasonable start point, I know how I wanted the city to grow and evolve and as a side-effect how the environment around it would change and develop, I also have an idea of the math behind actually generating the city and how to map out the buildings and the roads themselves.

# What I ended up with
A Conway's Game of Life city that changes on start and depending on player input it also has roads which will create city like road networks depending on the roads around it. This is accomplished by using a standard Conway's Game of Life script that I had taken from my processing projects from 2 years ago and converting it to C# and the unity system. The grid is built on start to be a 10 by 10 grid with cells the width of the buildings, any cell that is determined to be true is a building and false is a road. This is the first thing done, when done each building will cast rays in every direction around it y cell that is determined to be true is a building and false is a road. This is the first thing done, when done each building will cast rays in every direction around it and count how many buildings are around it, it then follows the Conway's game of life rules depending on how many buildings are around it. If there are 4 or less than 2 then the building will be destroyed and a road will be spawned in it's place, if there are exactly 3 other buildings then it will choose a random direction without a building in it and spawn a new one, if there are 2 or 3 buildings then the building will grow to a random max height by a random value to create an interesting image. The roads do the same as the buildings by checking all around to see what other roads are around, they then either turn to connect, stretch to connect or create a corner road in its place to create a road network beside all of the buildings. Thats the main body of the project, the buildings are of course multiple colours and the player can move the camera around to fly through the city or look at 'ground' level, if the player clicks on a road then a new building is spawned in its place and the city updates. The player can also reset the grid over the current one by pressing r.

A lot of how the city works is through a 2D Array of bools which are itterated through by a nested for loop running along the parameters of the rowCount and colCount. The buildings counting is done through raycasting and then adding to a list of objects around and setting an int based on that list's length. The roads work in the same fashion. The spawning of the buildings is done through instantiation of prefabs which are then assigned a parent in the hierarchy for neatness. Camera moves through changing of velocity on the w,a,s and d keys, the q and e keys make you rise and fall and the shift key speeds you up if you wish, you can also hold space to avoid moving up and down. The roads are spawned in the same way as the buildings except they are spawned on a delay using a co-routine to allow the buildings to first build and then letting the roads change.

Key:
W,A,S,D,Q,E - Camera movement controls.

Shift, Space - Extra Camera controls.

Left Click (On Road) - Spawns a building in its place.

R - Resets the gird on top of the current one.

Mouse - Controls camera direction.

All the stuff aside from the camera movement and Conway's Game of Life was done off the top of my head, I took the camera thing from on script online and then edited to suit my purposes, the game of life is taken from the script I wrote in processing and then just edited for unity. 

I think I am most proud of the roads, having a road system that actually looks like a city grid was the best thing for me. Seeing it form that road network was my favorite moment of the project.

The project should just build and run without issue, just use the standard way to build for windows. I'll include a pre built version of the project in the repo.
