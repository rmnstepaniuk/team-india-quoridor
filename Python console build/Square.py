class Square(object):
    """description of class"""
    occupied = False

    def __init__(self, x, y):
        self.coords = [x, y]
        self.friendlist = []
