from functions import find_location, find_wall_location
from Startup import *

class Player(object):
    """description of class"""

    MyTurn = bool
    walls = 8
    location = [0, 0]
    Possible_move = False
    Win_status = False

    def __init__(self, color):
        self.color = color
        if self.color == "black":
            self.location = [0, 4]
        elif self.color == "white":
            self.location = [8, 4]

    def win_check(self):
        if (self.color == 'white' and self.location[0] == 0) or (self.color == 'black' and self.location[0] == 8):
            self.Win_status = not self.Win_status
            return self.Win_status

    def pass_turn(self):
        self.MyTurn = not self.MyTurn

    def move(self, move_location):
        move_location = find_location(move_location)
        if (field[move_location[0]][move_location[1]] in field[self.location[0]][self.location[1]].friendlist) and (field[move_location[0]][move_location[1]].occupied is False):
            field[self.location[0]][self.location[1]].occupied = False
            self.location = move_location
            #print("Went to ", self.location)
            self.Possible_move = True
            field[move_location[0]][move_location[1]].occupied = True

        #else:
            #print("Hey, you can`t go there")
            #print(move_location)

        # self.pass_turn()

    def wall(self, wall_location):
        wall_location = find_wall_location(wall_location)
        if wall_field[wall_location[0]][wall_location[1]] < 1:
            if wall_location[2] == 'h':
                field[wall_location[0]][wall_location[1]].friendlist.remove(field[wall_location[0] + 1][wall_location[1]])
                field[wall_location[0]][wall_location[1] + 1].friendlist.remove(field[wall_location[0] + 1][wall_location[1] + 1])
                field[wall_location[0] + 1][wall_location[1]].friendlist.remove(field[wall_location[0]][wall_location[1]])
                field[wall_location[0] + 1][wall_location[1] + 1].friendlist.remove(field[wall_location[0]][wall_location[1] + 1])
                wall_field[wall_location[0]][wall_location[1]] += 2
                if wall_location[1] == 0:
                    wall_field[wall_location[0]][wall_location[1] + 1] += 2
                if 7 > wall_location[1] > 0:
                    wall_field[wall_location[0]][wall_location[1] + 1] += 2
                    wall_field[wall_location[0]][wall_location[1] - 1] += 2
                if wall_location[1] == 7:
                    wall_field[wall_location[0]][wall_location[1] - 1] += 2

        if wall_field[wall_location[0]][wall_location[1]] < 3:
            if wall_location[2] == 'v':
                field[wall_location[0]][wall_location[1]].friendlist.remove(field[wall_location[0]][wall_location[1] + 1])
                field[wall_location[0] + 1][wall_location[1]].friendlist.remove(field[wall_location[0] + 1][wall_location[1] + 1])
                field[wall_location[0]][wall_location[1] + 1].friendlist.remove(field[wall_location[0]][wall_location[1]])
                field[wall_location[0] + 1][wall_location[1] + 1].friendlist.remove(field[wall_location[0] + 1][wall_location[1]])
                wall_field[wall_location[0]][wall_location[1]] += 3
            #print("Wall placed on ", wall_location)
            self.walls -= 1

        #else:
            #print("You can place it here")
            # self.pass_turn()

    def jump(self, move_location):
        field[self.location[0]][self.location[1]].occupied = False
        move_location = find_location(move_location)
        if field[move_location[0]][move_location[1]].occupied is False:
            self.location = move_location
            # print("Went to ", self.location)
            self.Possible_move = True
            field[move_location[0]][move_location[1]].occupied = True

    def ai_work(self):
        aber = []
        for square in field[self.location[0]][self.location[1]].friendlist:
            aber.append(square.coords[0])
        self.Possible_move = False
        while not self.Possible_move:

            if self.color == "white":
                move_square = aber.index(min(aber))
                aber[move_square] += 1
            else:
                move_square = aber.index(max(aber))
                aber[move_square] -= 1

            position = val_list1.index(field[self.location[0]][self.location[1]].friendlist[move_square].coords[1])
            move_address = key_list1[position]
            move_address += str(field[self.location[0]][self.location[1]].friendlist[move_square].coords[0] + 1)


            self.move(move_address)

        print('move', move_address)
        #print(self.location)
