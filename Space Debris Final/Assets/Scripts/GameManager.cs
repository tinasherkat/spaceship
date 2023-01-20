
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > randomTime && screenDebris.transform.childCount < totalItemsOnScreen)
        {
            Vector3 spawnPoint = screenDebris.transform.position;
            int index = (int)Random.Range(0, debris.Length);
            GameObject debrisItem = Instantiate(debris[index], spawnPoint, Quaternion.identity) as GameObject;
            Vector3 newPosition = debrisItem.transform.position;
            debrisItem.transform.position = newPosition;
            debrisItem.transform.parent = screenDebris.transform;
            newPosition.z = 0;
            curTime = 0;
        }
    }
}
