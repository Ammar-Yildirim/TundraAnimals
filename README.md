# Tundra Animal Simulation

This program simulates the interactions between prey and predator colonies in the tundra environment. The simulation includes three predator species (snowy owl, arctic fox, and wolf) and three prey species (lemming, arctic hare, and gopher). The number of animals in each colony affects the dynamics of the entire ecosystem.

## How to Run the Simulation

1. Clone or download the repository.
2. Prepare a text file with the initial setup of prey and predator colonies. The file should contain the number of prey and predator colonies on the first line, followed by each colony's data on subsequent lines, including the name, species, and starting number of animals.
3. Run the program, providing the path to the text file as input.

Example text file:
  4 2
  lem1 l 86
  lem2 l 90        
  hare1 h 26
  go g 12
  hungry w 12
  feathery o 6

4. The simulation will run until each prey colony becomes extinct or the number of prey animals quadruples compared to its starting value.
5. The program will print the data of each colony in each turn.

## Simulation Details - Documentation Supplied

The program includes detailed documentation to help users understand the simulation, its rules, and the code structure. You can refer to the supplied documentation for additional information.


## Contributing

Feel free to contribute to the improvement of this simulation by submitting issues or pull requests.

## Acknowledgements

- The program utilizes template design patterns for efficient code organization and readability.

