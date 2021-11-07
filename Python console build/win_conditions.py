from functions import move_decipher, write_jump_location, find_wall_location
from Startup import *
from random import choice

def game(player1, player2):
    while not player1.Win_status or not player2.Win_status:
        if player1.color == 'black':
            player_move = input()
            move_decipher(player2, player_move)
            if player2.win_check():
                print("Player won")
                break
            if field[player1.location[0]+1][player1.location[1]].occupied \
                    and wall_field[player1.location[0]][player1.location[1]] not in [1, 2] \
                    and wall_field[player1.location[0]][player1.location[1]-1] not in [1, 2] \
                    and wall_field[player1.location[0]+1][player1.location[1]] not in [1, 2] \
                    and wall_field[player1.location[0]+1][player1.location[1]-1] not in [1, 2]:
                jump_location = [player1.location[0]+2, player1.location[1]]
                player1.jump(write_jump_location(jump_location))
                print("jump", write_jump_location(jump_location))
            elif player1.location[0] < 7 and field[player1.location[0]+2][player1.location[1]].occupied:
                move_loc = key_list2[val_list2.index(player1.location[1])] + str(player1.location[0]) + 'h'
                location = find_wall_location(move_loc)
                if player1.location[1] != 4:
                    move_loc = key_list2[val_list2.index(player2.location[1])] + str(player2.location[0]) + 'h'
                    location = find_wall_location(move_loc)
                    if wall_field[location[0]][location[1]] > 0:
                        move_loc = key_list2[val_list2.index(player2.location[1]-1)] + str(player2.location[0]) + 'h'
                        location = find_wall_location(move_loc)
                while wall_field[location[0]][location[1]] > 0:
                    move_loc = choice(list(key_list2)) + choice([str(2), str(1)]) + 'h'
                    location = find_wall_location(move_loc)
                player1.wall(move_loc)
                print('wall', move_loc)
            else:
                player1.ai_work()
            if player1.win_check():
                print("Bot won")
                break
        else:
            if field[player1.location[0]-1][player1.location[1]].occupied \
                    and wall_field[player1.location[0]-1][player1.location[1]] not in [1, 2]\
                    and wall_field[player1.location[0]-1][player1.location[1]-1] not in [1, 2] \
                    and wall_field[player1.location[0]-2][player1.location[1]] not in [1, 2] \
                    and wall_field[player1.location[0]-2][player1.location[1]-1] not in [1, 2]:
                jump_location = [player1.location[0]-2, player1.location[1]]
                player1.jump(write_jump_location(jump_location))
                print("jump", write_jump_location(jump_location))
            elif player1.location[0] > 1 and field[player1.location[0]-2][player1.location[1]].occupied:
                move_loc = key_list2[val_list2.index(player1.location[1])] + str(player1.location[0]+1) + 'h'
                location = find_wall_location(move_loc)
                #print(move_loc)
                #print(location)
                if player1.location[1] != 4:
                    move_loc = key_list2[val_list2.index(player2.location[1])] + str(player2.location[0] + 1) + 'h'
                    location = find_wall_location(move_loc)
                    if wall_field[location[0]][location[1]] > 0:
                        move_loc = key_list2[val_list2.index(player2.location[1]-1)] + str(player2.location[0]+1) + 'h'
                        location = find_wall_location(move_loc)
                while wall_field[location[0]][location[1]] > 0:
                    move_loc = choice(list(key_list2)) + choice([str(7), str(6)]) + 'h'
                    location = find_wall_location(move_loc)
                    #print(wall_field[location[0]][location[1]])
                    #print(move_loc)
                    #print(location)
                player1.wall(move_loc)
                print('wall', move_loc)
            else:
                player1.ai_work()
            if player1.win_check():
                print("Bot won")
                break
            player_move = input()
            move_decipher(player2, player_move)
            if player2.win_check():
                print("Player won")
                break
