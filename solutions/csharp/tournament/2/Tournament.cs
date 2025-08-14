public static class Tournament
{   
    public static void Tally(Stream inStream, Stream outStream)
    {
        var teamsDict = new Dictionary<string, int[]>();

        // read inStream line by line until the end
        StreamReader reader = new StreamReader(inStream);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var arr = line.Split(";");
            string teamNameA = arr[0];
            string teamNameB = arr[1];
            string outcome = arr[2];

            // if team not already in dictionary, add the team
            if (!teamsDict.ContainsKey(teamNameA))
            {
                teamsDict.Add(teamNameA, new int[] { 0, 0, 0, 0, 0 });
            }
            if (!teamsDict.ContainsKey(teamNameB))
            {
                teamsDict.Add(teamNameB, new int[] { 0, 0, 0, 0, 0 });
            }

            // compute the outcome of the game and add accordingly to dictionary
            switch (outcome)
            {
                case "win":
                    teamsDict[teamNameA][0]++;
                    teamsDict[teamNameA][1]++;
                    teamsDict[teamNameB][0]++;
                    teamsDict[teamNameB][3]++;
                    break;
                case "loss":
                    teamsDict[teamNameB][0]++;
                    teamsDict[teamNameB][1]++;
                    teamsDict[teamNameA][0]++;
                    teamsDict[teamNameA][3]++;
                    break;
                case "draw":
                    teamsDict[teamNameA][0]++;
                    teamsDict[teamNameA][2]++;
                    teamsDict[teamNameB][0]++;
                    teamsDict[teamNameB][2]++;
                    break;
            }
        }

        // calculate points and write them to dictionary
        foreach (var element in teamsDict)
        {
            element.Value[4] = (element.Value[1] * 3) + element.Value[2];
        }

        // sort first by score then alphabetically by team name
        var sortedDict = teamsDict.OrderByDescending(x => x.Value[4]).ThenBy(x => x.Key);

        // string to stream
       using (var outStreamWriter = new StreamWriter(outStream))
        {
            outStreamWriter.Write("Team                           | MP |  W |  D |  L |  P");
            foreach (var element in sortedDict)
            {
                outStreamWriter.Write(String.Format("\n{0,-31}| {1,2} | {2,2} | {3,2} | {4,2} | {5,2}", element.Key, element.Value[0], element.Value[1], element.Value[2], element.Value[3], element.Value[4]));
            }
            outStreamWriter.Flush();
        }
    }
}
