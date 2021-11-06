import Startup
from Player import *
from functions import find_friends
from win_conditions import game


color = str(input())
Bot = Player(color)
if color == "white":
    Player2 = Player("black")
else:
    Player2 = Player("white")

for item in Startup.field:
    for i in range(9):
        find_friends(item[i])

game(Bot, Player2)




