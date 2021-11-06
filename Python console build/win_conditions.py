from functions import move_decipher


def game(player1, player2):
    while not player1.Win_status or not player2.Win_status:
        if player1.color == 'black':
            player_move = input()
            move_decipher(player2, player_move)
            if player2.win_check():
                print("Player won")
                break
            player1.ai_work()
            if player1.win_check():
                print("Bot won")
                break
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
