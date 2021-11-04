from functions import find_location, find_wall_location
from Startup import *

class Player(object):
    """description of class"""

    MyTurn = bool
    walls = 8
    location = [0, 0]

    def __init__(self, color):
        self.color = color
        if self.color == "black":
            self.location = [0, 4]
        elif self.color == "white":
            self.location = [8, 4]

    def pass_turn(self):
        self.MyTurn = not self.MyTurn

    def move(self, move_location):
        move_location = find_location(move_location)
        if field[move_location[0]][move_location[1]] in field[self.location[0]][self.location[1]].friendlist:
            self.location = move_location
        # self.pass_turn()

    def wall(self, wall_location):
        wall_location = find_wall_location(wall_location)
        if wall_field[wall_location[0]][wall_location[1]] < 1:
            if wall_location[2] == 'h':
                field[wall_location[0]][wall_location[1]].friendlist.remove(field[wall_location[0] + 1][wall_location[1]])
                field[wall_location[0]][wall_location[1] + 1].friendlist.remove(field[wall_location[0] + 1][wall_location[1] + 1])
            elif wall_location[2] == 'v':
                field[wall_location[0]][wall_location[1]].friendlist.remove(field[wall_location[0]][wall_location[1] + 1])
                field[wall_location[0 + 1]][wall_location[1]].friendlist.remove(field[wall_location[0] + 1][wall_location[1] + 1])
            #("wall placed on ", wall_location)
            self.walls -= 1
            wall_field[wall_location[0]][wall_location[1]] += 1
            # self.pass_turn()

    def ai_work(self):
        aber = []
        for square in field[self.location[0]][self.location[1]].friendlist:
            aber.append(square.coords[0])
        if self.color == "white":
            move_square = aber.index(min(aber))
        else:
            move_square = aber.index(max(aber))
        position = val_list1.index(field[self.location[1]][self.location[0]].friendlist[move_square].coords[1])
        move_address = key_list1[position]
        move_address += str(field[self.location[1]][self.location[0]].friendlist[move_square].coords[0]  + 1)

        self.move(move_address)
        print("move", move_address)