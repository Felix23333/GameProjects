import random
majong_mountain = [[1,'1W', 1, 4],[1,'2W', 2, 4],[1,'3W', 3, 4],[1,'4W', 4, 4],[1,'5W', 5, 4],[1,'6W', 6, 4],[1,'7W', 7, 4],[1,'8W', 8, 4],[1,'9W', 9, 4],
[2,'1P', 1, 4],[2,'2P', 2, 4],[2,'3P', 3, 4],[2,'4P', 4, 4],[2,'5P', 5, 4],[2,'6P', 6, 4],[2,'7P', 7, 4],[2,'8P', 8, 4],[2,'9P', 9, 4],
[3,'1S', 1, 4],[3,'2S', 2, 4],[3,'3S', 3, 4],[3,'4S', 4, 4],[3,'5S', 5, 4],[3,'6S', 6, 4],[3,'7S', 7, 4],[3,'8S', 8, 4],[3,'9S', 9, 4],
[4,'East', 1, 4],[4,'South', 2, 4],[4,'West', 3, 4],[4,'North', 4, 4],[4,'Red Dragon', 5, 4],[4,'White Dragon', 6, 4],[4,'Green Dragon', 7, 4]]

honor_tiles_list = ['East', 'West', 'South', 'North', 'Green Dragon', 'Red Dragon', 'White Dragon']
green_list = ['2S', '3S', '4S', '6S', '8S', 'Green Dragon']
pure_orphans_list = ['1W','9W', '1P', '9P', '1S', '9S']
orphans_list = ['1W','9W', '1P', '9P', '1S', '9S', 'East', 'South', 'North', 'West', 'Green Dragon', 'Red Dragon', 'White Dragon']
majong_hand = []
hand_info = []
round = 1
history = []

def print_welcome_info():
    print('''\nWelcome to Python 5-pieces Majong! (Made by orange)

            MENU
play ---- Play the game
score ---- Show your history score!
quit ---- Leave the game
''')


def get_majong():
    while True:
        number = random.randint(0, len(majong_mountain)-1)
        majong = majong_mountain[number]
        if majong[3] == 0:
            continue
        else:
            majong_hand.append(majong[1])
            hand_info.append(majong)
            majong_mountain[number][3] = majong_mountain[number][3] - 1
            sorted_hand_info = sorted(hand_info)
            sorted_hand = sorted(majong_hand)
            print('Your Hand:', end = ' ')
            print(sorted_hand)
            break

def first_get():
    get_majong()
    get_majong()
    get_majong()
    get_majong()
    get_majong()

def draw_majong():
    while True:
        user_play_out = input('\nEnter the name of majong that you want to draw:')
        try:
            index = majong_hand.index(user_play_out)
            majong_hand.remove(user_play_out)
            hand_info.pop(index)
            sorted_hand_info = sorted(hand_info)
            sorted_hand = sorted(majong_hand)
            break
        except:
            print("\nYou don't have this majong, try again.\n")
            continue

def check_win():
    check_pair = False
    check_three_part = False
    sorted_hand_info = sorted(hand_info)
    count_repeat = 0
    for i in range(0, len(sorted_hand_info)):
        if count_repeat == 1:
            check_pair = True
            sorted_hand_info.pop(i-1)
            sorted_hand_info.pop(i-1)
            break
        count_repeat = 0
        majong1 = sorted_hand_info[i][1]
        for i2 in range(0, len(sorted_hand_info)):
            if i2 > len(sorted_hand_info):
                break
            if i2 == i:
                continue
            majong2 = sorted_hand_info[i2][1]
            if majong1 == majong2:
                count_repeat += 1
    majong1 = sorted_hand_info[0]
    majong2 = sorted_hand_info[1]
    majong3 = sorted_hand_info[2]
    if majong1[0] == majong2[0] == majong3[0]:
        if majong2[2] - majong1[2] == 1 and majong1[0] != 4:
            if majong3[2] - majong2[2] == 1:
                check_three_part = True
        elif majong1[2] == majong2[2] == majong3[2]:
            check_three_part = True
    if check_pair == True and check_three_part == True:
        user_win = input('\nYou have met the winning condition!(y to win, else for skip):')
        if user_win == 'y':
            calculate_win()
            return True
        else:
            pass
    else:
        pass

def calculate_win():
    print('\n        Fan Count')
    Fan_count = 0
    Yakuman_check = 0
    Yakuman_check += win_with_no_draw()
    Yakuman_check += all_honor_tiles()
    Yakuman_check += pure_orphans()
    Yakuman_check += green_flush()
    if Yakuman_check == 0:
        print('All concealed hand ---- 1 Fan')
        Fan_count += 1
        Fan_count += no_orphans()
        Fan_count += honor_tiles_triplets()
        Fan_count += win_last_draw()
        Fan_count += win_without_points()
        Fan_count += all_triplets()
        Fan_count += mixed_orphans()
        Fan_count += outside_hand()
        Fan_count += one_suit()
    if Yakuman_check == 1:
        score = '\nTotal: 13 Fan   Yakuman ---- 32000 POINTS GET!\n'
        history.append(score)
        print(score)
    elif Yakuman_check == 2:
        score = '\nTotal: 26 Fan   Dabuluyakuman ---- 64000 POINTS GET!\n'
        history.append(score)
        print(score)
    elif Fan_count == 1:
        score = '\nTotal: 1 Fan   Win ---- 1000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 2:
        score = '\nTotal: 2 Fan   Win ---- 2000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 3:
        score = '\nTotal: 3 Fan   Win ---- 4000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 4:
        score = '\nTotal: 4 Fan   Mangan ---- 8000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 5:
        score = '\nTotal: 5 Fan   Mangan ---- 8000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 6:
        score = '\nTotal: 6 Fan   Haneman---- 12000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 7:
        score = '\nTotal: 7 Fan   Haneman---- 12000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 8:
        score = '\nTotal: 8 Fan   Baiman---- 16000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 9:
        score = '\nTotal: 9 Fan   Baiman---- 16000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 10:
        score = '\nTotal: 10 Fan   Baiman---- 16000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 11:
        score = '\nTotal: 11 Fan   Sanbaiman---- 24000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count == 12:
        score = '\nTotal: 12 Fan   Sanbaiman---- 24000 POINTS GET!\n'
        print(score)
        history.append(score)
    elif Fan_count >= 13:
        score = '\nTotal: 13 Fan   Yakuman ---- 32000 POINTS GET!\n'
        history.append(score)
        print(score)

def all_honor_tiles():
    sorted_hand = sorted(hand_info)
    count1 = 0
    for i in range(0,5):
        check = sorted_hand[i][1] in honor_tiles_list
        if check == True:
            count1 += 1
        else:
            break
    if count1 == 5:
        print('All_honor_titles ---- 13 Fan')
        return 1
    else:
        return 0

def pure_orphans():
    count1 = 0
    sorted_hand = sorted(hand_info)
    for i in range(0,5):
        check = sorted_hand[i][1] in pure_orphans_list
        if check == True:
            count1 += 1
        else:
            break
    if count1 == 5:
        print('Pure orphans ---- 13 Fan')
        return 1
    else:
        return 0

def green_flush():
    count1 = 0
    sorted_hand = sorted(hand_info)
    for i in range(0,5):
        check = sorted_hand[i][1] in green_list
        if check == True:
            count1 += 1
        else:
            break
    if count1 == 5:
        print('Green flush ---- 13 Fan')
        return 1
    else:
        return 0

def win_with_no_draw():
    if round == 0:
        print('Win with no draw ---- 13 Fan')
        return 1
    else:
        return 0

def no_orphans():
    count1 = 0
    sorted_hand = sorted(hand_info)
    for i in range(0,5):
        check = sorted_hand[i][1] not in orphans_list
        if check == True:
            count1 += 1
        else:
            break
    if count1 == 5:
        print('No orphans ---- 1 Fan')
        return 1
    else:
        return 0

def honor_tiles_triplets():
    count1 = 0
    sorted_hand = sorted(hand_info)
    count_repeat = 0
    for i in range(0, len(sorted_hand)):
        if count_repeat == 1:
            sorted_hand.pop(i-1)
            sorted_hand.pop(i-1)
            break
        count_repeat = 0
        majong1 = sorted_hand[i][1]
        for i2 in range(0, len(sorted_hand)):
            if i2 > len(sorted_hand):
                break
            if i2 == i:
                continue
            majong2 = sorted_hand[i2][1]
            if majong1 == majong2:
                count_repeat += 1
    majong1 = sorted_hand[0]
    majong2 = sorted_hand[1]
    majong3 = sorted_hand[2]
    if majong1[0] == majong2[0] == majong3[0] == 4:
        print('Honor tiles triplets ---- 1 Fan')
        return 1
    else:
        return 0

def win_last_draw():
    if round == 29:
        print('Win last draw ---- 1 Fan')
        return 1
    else:
        return 0

def win_without_points():
    count1 = 0
    sorted_hand = sorted(hand_info)
    count_repeat = 0
    for i in range(0, len(sorted_hand)):
        if count_repeat == 1:
            sorted_hand.pop(i-1)
            sorted_hand.pop(i-1)
            break
        count_repeat = 0
        majong1 = sorted_hand[i][1]
        for i2 in range(0, len(sorted_hand)):
            if i2 > len(sorted_hand):
                break
            if i2 == i:
                continue
            majong2 = sorted_hand[i2][1]
            if majong1 == majong2:
                count_repeat += 1
    majong1 = sorted_hand[0]
    majong2 = sorted_hand[1]
    majong3 = sorted_hand[2]
    if majong2[2] - majong1[2] == 1 and majong1[0] != 4:
        if majong3[2] - majong2[2] == 1:
            print('Win without points ---- 1 Fan')
            return 1
        else:
            return 0
    else:
        return 0
def all_triplets():
    count1 = 0
    sorted_hand = sorted(hand_info)
    count_repeat = 0
    for i in range(0, len(sorted_hand)):
        if count_repeat == 1:
            sorted_hand.pop(i-1)
            sorted_hand.pop(i-1)
            break
        count_repeat = 0
        majong1 = sorted_hand[i][1]
        for i2 in range(0, len(sorted_hand)):
            if i2 > len(sorted_hand):
                break
            if i2 == i:
                continue
            majong2 = sorted_hand[i2][1]
            if majong1 == majong2:
                count_repeat += 1
    majong1 = sorted_hand[0]
    majong2 = sorted_hand[1]
    majong3 = sorted_hand[2]
    if majong1[2] == majong2[2] == majong3[2]:
        print('All triplets ---- 2 Fan')
        return 2
    else:
        return 0

def mixed_orphans():
    count1 = 0
    sorted_hand = sorted(hand_info)
    count_repeat = 0
    for i in range(0, len(sorted_hand)):
        if count_repeat == 1:
            majong1 = sorted_hand.pop(i-1)
            majong2 = sorted_hand.pop(i-1)
            check_pair_orphans = majong1[1] in orphans_list
            break
        count_repeat = 0
        majong1 = sorted_hand[i][1]
        for i2 in range(0, len(sorted_hand)):
            if i2 > len(sorted_hand):
                break
            if i2 == i:
                continue
            majong2 = sorted_hand[i2][1]
            if majong1 == majong2:
                count_repeat += 1
    majong1 = sorted_hand[0]
    majong2 = sorted_hand[1]
    majong3 = sorted_hand[2]
    if majong1[2] == majong2[2] == majong3[2]:
        check = majong1[1] in orphans_list
        if check == True and check_pair_orphans == True:
            print('Mixed orphans ---- 2 Fan')
            return 2
        else:
            return 0
    else:
        return 0

def outside_hand():
    count1 = 0
    sorted_hand = sorted(hand_info)
    count_repeat = 0
    for i in range(0, len(sorted_hand)):
        if count_repeat == 1:
            majong1 = sorted_hand.pop(i-1)
            majong2 = sorted_hand.pop(i-1)
            check_pair_orphans = majong1[1] in orphans_list
            check_pair_pure_orphans = majong1[1] in pure_orphans_list
            break
        count_repeat = 0
        majong1 = sorted_hand[i][1]
        for i2 in range(0, len(sorted_hand)):
            if i2 > len(sorted_hand):
                break
            if i2 == i:
                continue
            majong2 = sorted_hand[i2][1]
            if majong1 == majong2:
                count_repeat += 1
    majong1 = sorted_hand[0]
    majong2 = sorted_hand[1]
    majong3 = sorted_hand[2]
    if majong2[2] - majong1[2] == 1 and majong1[0] != 4:
        if majong3[2] - majong2[2] == 1:
            check_orphans1 = majong1[1] in pure_orphans_list
            check_orphans2 = majong3[1] in pure_orphans_list
        if check_pair_pure_orphans == True:
            if check_orphans1 == True or check_orphans2 == True:
                print('Pure ouside hand ---- 3 Fan')
                return 3
            else:
                return 0
        elif check_pair_orphans == True:
            if check_orphans1 == True or check_orphans2 == True:
                print('Mixed ouside hand ---- 2 Fan')
                return 2
            else:
                return 0
        else:
            return 0
    else:
        return 0
def one_suit():
    count1 = 0
    sorted_hand = sorted(hand_info)
    majong1 = sorted_hand[0]
    majong2 = sorted_hand[1]
    majong3 = sorted_hand[2]
    majong4 = sorted_hand[3]
    majong5 = sorted_hand[4]
    if majong1[0] == majong2[0] == majong3[0] == majong4[0] == majong5[0]:
        print('All of one suit ---- 6 Fan')
        return 6
    elif majong1[0] == 4 or majong2[0] == 4 or majong3[0] == 4 or majong4[0] == 4 or majong5[0] == 4:
        print('Mixed of one suit ---- 3 Fan')
        return 3
    else:
        return 0

if __name__ == "__main__":
    while True:
        print_welcome_info()
        user = input('Enter the command:')
        if user == 'play':
            first_get()
            check_win()
            draw_majong()
            round += 1
            while round < 30:
                get_majong()
                win_check = check_win()
                if win_check == True:
                    break
                draw_majong()
                round += 1
            if round == 30:
                print('Draw!')
            majong_hand = []
            hand_info = []
            round = 0
            continue
        if user == 'quit':
            print('\nThank you for playing!')
            break
        if user == 'score':
            for i in history:
                print(i)
            continue
        else:
            print('\nInvaild Command! Try again!')
            continue
