# tournament-tracker
A Tournament Tracker that sets up a schedule for teams to play each other in a single-elimination style matchups.

# Useful For:
1. Office ping pong Tournaments
2. Rec League Playoffs
3. 3v3 Backetball leagues
4. Many More

# Technology Utilized
THe "C# technology" we use in this project includes:
1. Multi-form WinForms application 
2. In-depth class library
3. SQL Database
4. Text File Storage
5. Dapper
6. Linq
7. Interfaces
8. Emailing from C#
9. Custom Events
10. Advance Debugging

# Scenario
Your friend come to you and ask you to create a tournament tracker. They are always playing games and want to determine who is the best. The idea is that you create a bracket tournameent system where the computer will tell them who to play in a single-elimination style bracket. At the end, the winner should be identified. Their model is the NCAA Basketball tournament bracket for March Madness.

# Requirments
1. Tracks games played and their outcome (who won).
2. Multiple competitors play in the tournaments.
3. Creates a tournaments plan(who plays in what order).
4. Schedules games.
5. A single loss eliminates a player.
6. The last player standing is the winner.

# Big Picture Design:
Structure : Windows Forms application and class library
Data : SQL  and/or Text file
Users: One at a time on one application
KEY CONCEPTS:
1. Email
2. SQL
3. Custom Events
4. Error Handling 
5. Interfaces
6. Random Ordering 
7. Texting

# Data Design

# Teams
1. TeamMembers(List<Persons>)
2. TeamName(string)
 
# Person
1. FirstName(string)
2. LastName(string)
3. EmailAddress(string)
4. CellphoneNumber(string)

# Tournament
1. TournamentName(string)
2. EntryFee(decimal)
3. EnteredTeams(List<Teams>)
4. Prizes(List<Prize>)
5. Rounds (List<List<Matchup>>)

# Prize 
1. PlaceNumber(int)
2. PlaceName(string)
3. PrizeAmount(decimal)
4. PrizePercentage(double)

# Matchup
1. Entries(List<MatchupEntry>)
2. Winner (Teams)
3. MatchupRound(int)
 
# MatchupEntry
1. TeamsCompeting(Team)
2. Score(double)
3. ParentMatchup(Matchup)

