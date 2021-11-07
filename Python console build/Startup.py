from Square import Square
field = [[Square(j, i) for i in range(9)] for j in range(9)]
wall_field = [[0 for k in range(8)] for l in range(8)]
letters_dictionary1 = {"A": 0, "B": 1, "C": 2, "D": 3, "E": 4, "F": 5, "G": 6, "H": 7, "I": 8}
letters_dictionary2 = {"S": 0, "T": 1, "U": 2, "V": 3, "W": 4, "X": 5, "Y": 6, "Z": 7}
key_list1 = list(letters_dictionary1.keys())
val_list1 = list(letters_dictionary1.values())
key_list2 = list(letters_dictionary2.keys())
val_list2 = list(letters_dictionary2.values())