
create table People(
	id int primary key,
	FirstName varchar(50),
	LastName varchar(50),
	EmailAddress varchar(50),
	CellphoneNumber varchar(50),
)

create table Teams(
	id int primary key,
	TeamName varchar(50),

)

create table TeamMembers(
	id int primary key,
	Perosnid int foreign key references People(id),
	Teamid int foreign key references Teams(id),
)

create table Matchups(
	id int primary key,
	Winnerid int foreign key references Teams(id),
	MatchupRound int,
)

create table MatchupsEntries(
	id int primary key,
	Matchupid int foreign key references Matchups(id),
	ParentMatchupid int foreign key references Matchups(id),
	TeamCompetingid int foreign key references Teams(id),
	Score int,
)

create table Prizes(
	id int primary key,
	PlaceNumber int,
	PlaceName varchar(50),
	PrizeAmount decimal,
	PrizePercentage decimal
)

create table Tournaments(
	id int primary key,
	TournamentName varchar(50),
	EntryFee decimal,
)

create table TounamentPrizes(
	id int primary key,
	Tournamentid int foreign key references Tournaments(id),
	Prizeid int foreign key references Prizes(id),
)

create table TounameneEntries(
	id int primary key,
	Tournamentid int foreign key references Tournaments(id),
	Teamid int foreign key references Teams(id),
)



