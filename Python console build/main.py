import Startup
from Player import *
from functions import find_friends
from pprint import pprint
import sys


color = str(input())
Bot = Player(color)
if color == "white":
    Bot2 = Player("black")
else:
    Bot2 = Player("white")

for item in Startup.field:
    for i in range(9):
        find_friends(item[i])

#pprint(field)

#print(field[Bot.location[0]][Bot.location[1]].friendlist)

#print(Bot.location)

#print(Bot.color)
#print(Bot.location)
#Bot.wall('W7h')
if Bot.color == 'black':
    while Bot.location[0] != 8:
        Bot.ai_work()
else:
    while Bot.location[0] != 0:
        Bot.ai_work()

lines = sys.stdin.readlines()
print(lines)



