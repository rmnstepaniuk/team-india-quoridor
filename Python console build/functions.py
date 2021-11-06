import Startup

def find_location(move_location):
    location = [0, 0]
    move_location = list(move_location)
    if move_location[0] in Startup.letters_dictionary1.keys():
        location[1] = Startup.letters_dictionary1.get(move_location[0])
    location[0] = int(move_location[1]) - 1
    return location

def find_wall_location(move_location):
    location = [0, 0, 0]
    move_location = list(move_location)
    if move_location[0] in Startup.letters_dictionary2.keys():
        location[1] = Startup.letters_dictionary2.get(move_location[0])
    location[0] = int(move_location[1]) - 1
    location[2] = move_location[2]
    return location

def find_friends(square):
    for kvadrat in Startup.field:
        for i in range(9):
            if (abs(square.coords[1]-kvadrat[i].coords[1]) == 0 and abs(square.coords[0]-kvadrat[i].coords[0]) == 1) or (abs(square.coords[1]-kvadrat[i].coords[1]) == 1 and abs(square.coords[0]-kvadrat[i].coords[0]) == 0):
                square.friendlist.append(kvadrat[i])
    return square.friendlist

def move_decipher(player, player_move):
    decision = player_move.split(" ")
    location = list(decision[1])
    if decision[0] == 'move':
        player.move(location)
    elif decision[0] == 'wall':
        player.wall(location)
    elif decision[0] == 'jump':
        player.jump(location)

