#include <fstream>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

struct star
{
    int x, y;       // координаты звезды
    int galaxyNum;  // номер созвездия; 0, если созвездие не задано.
};

// Найти первую неиспользованную звезду
star* findUnusedStar(vector<star*>& stars)
{
    for (int i = 0; i < stars.size(); ++i)
    {
        if (stars[i]->galaxyNum == 0)
        {
            return stars[i];
        }
    }

    return 0;
}

// найти звезду по координатам
star* findStarWithCoords(vector<star*> &stars, int x, int y)
{
    for (int i = 0; i < stars.size(); ++i)
    {
        if (stars[i]->x == x && stars[i]->y == y)
        {
            return stars[i];
        }
    }

    return 0;
}

// задать номер созвездия звезде и её соседям
void classifyStar(vector<star*> &stars, int currentGalaxyNum, star* currentStar)
{
    if (currentStar == 0 || currentStar->galaxyNum != 0)
    {
        return;
    }

    currentStar->galaxyNum = currentGalaxyNum;

    classifyStar(stars, currentGalaxyNum, findStarWithCoords(stars, currentStar->x - 1,  currentStar->y)); // смотрим слева
    classifyStar(stars, currentGalaxyNum, findStarWithCoords(stars, currentStar->x + 1,  currentStar->y)); // смотрим справа
    classifyStar(stars, currentGalaxyNum, findStarWithCoords(stars, currentStar->x,  currentStar->y - 1)); // смотрим снизу
    classifyStar(stars, currentGalaxyNum, findStarWithCoords(stars, currentStar->x,  currentStar->y + 1)); // смотрим сверху
}

int main()
{
    string line;
    ifstream file("map.txt");  // открываем файл со звёздами
    vector<star*> stars;       // вектор со всеми звёздами
    int y = 0;

    // Читаем файл построчно и ищем звёзды
    while(getline(file, line))
    {
        for (int x = 0; x < line.size(); ++x)
        {
            if (line[x] == '*')
            {
                star* star = new struct star;
                star->x = x;
                star->y = y;
                star->galaxyNum = 0;

                stars.push_back(star);
            }
        }

        y++;
    }

    cout << "Количество звёзд: " << stars.size() << endl;

    // задаем номера созвездий звёздам
    int currentGalaxyNum = 0;
    star* currentStar = findUnusedStar(stars);
    while (currentStar != 0)
    {
        currentGalaxyNum++;
        classifyStar(stars, currentGalaxyNum, currentStar);
        currentStar = findUnusedStar(stars);
    }

    cout << "Количество созвездий: " << currentGalaxyNum << endl;

    if (currentGalaxyNum == 0)
    {
        return 0;
    }

    // подсчитываем количество звёзд в каждом созвездии
    int* starsPerGalaxy = new int[currentGalaxyNum];
    for (int i = 0; i < currentGalaxyNum; ++i)
    {
        starsPerGalaxy[i] = 0;
    }

    for (int i = 0; i < stars.size(); ++i)
    {
        starsPerGalaxy[stars[i]->galaxyNum - 1]++;
    }

    for (int i = 0; i < currentGalaxyNum; ++i)
    {
        cout << "В созвездии " << i + 1 << " " << starsPerGalaxy[i] << " звезд" << endl;
    }

    // находим номер созвездия с самым большим количеством звёзд
    int withBiggestCount = 0;
    for (int i = 0; i < currentGalaxyNum; ++i)
    {
        if (starsPerGalaxy[withBiggestCount] < starsPerGalaxy[i])
        {
            withBiggestCount = i;
        }
    }

    cout << "В созвездии " << withBiggestCount + 1 << " больше всего звезд" << endl;

    return 0;
}
