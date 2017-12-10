use session4
go

create table Question(
	QuestionId int primary key identity,
	QuestionText varchar(max) not null
)

create table Choice(
	ChoiceId int primary key identity,
	ChoiceText varchar(max),
	ChoiceValue int
)

create table MultipleChoice(
	MultipleChoiceId int primary key identity
)

create table MultipleChoiceDetail(
	MultipleChoiceId int not null references MultipleChoice(MultipleChoiceId),
	ChoiceId int not null references Choice(ChoiceId),
	primary key (MultipleChoiceId, ChoiceId)
)

create table Mapping(
	MappingId int primary key identity,
	QuestionId int not null references Question(QuestionId),
	MultipleChoiceId int not null references MultipleChoice(MultipleChoiceId)
)

create table Survey(
	SurveyId int primary key identity,
	SurveyName varchar(100),
)

create table SurveyDetail(
	SurveyId int not null references Survey(SurveyId),
	MappingId int not null references Mapping(MappingId),
	primary key(SurveyId, MappingId)
)

create table SurveySubmission(
	SurveySubmissionId int primary key identity,
	SurveyId int not null references Survey(SurveyId),
	Gender varchar(10),
	Age int,
	DepartureAirport char(3),
	ArrivalAirport char(3),
	CabinType varchar(30),
	SubmissionMonth int,
	SubmissionYear int
)

create table SurveySubmissionDetail(
	SurveySubmissionDetailId int primary key identity,
	SurveySubmissionId int not null references SurveySubmission(SurveySubmissionId),
	QuestionId int not null references Question(QuestionId),
	ChoiceId int not null references Choice(ChoiceId)
)

insert into Choice (ChoiceText, ChoiceValue) values ('Outstanding', 1)
insert into Choice (ChoiceText, ChoiceValue) values ('Very Good', 2)
insert into Choice (ChoiceText, ChoiceValue) values ('Good', 3)
insert into Choice (ChoiceText, ChoiceValue) values ('Adequate', 4)
insert into Choice (ChoiceText, ChoiceValue) values ('Needs Improvement', 5)
insert into Choice (ChoiceText, ChoiceValue) values ('Poor', 6)
insert into Choice (ChoiceText, ChoiceValue) values ('Don''t know', 7)

insert MultipleChoice default values

insert into MultipleChoiceDetail (MultipleChoiceId, ChoiceId) values (1, 1)
insert into MultipleChoiceDetail (MultipleChoiceId, ChoiceId) values (1, 2)
insert into MultipleChoiceDetail (MultipleChoiceId, ChoiceId) values (1, 3)
insert into MultipleChoiceDetail (MultipleChoiceId, ChoiceId) values (1, 4)
insert into MultipleChoiceDetail (MultipleChoiceId, ChoiceId) values (1, 5)
insert into MultipleChoiceDetail (MultipleChoiceId, ChoiceId) values (1, 6)
insert into MultipleChoiceDetail (MultipleChoiceId, ChoiceId) values (1, 7)

insert into Question (QuestionText) values ('Please rate our aircraft flown on AMONIC Airlines')
insert into Question (QuestionText) values ('How would you rate our flight attendants')
insert into Question (QuestionText) values ('How would you rate our inflight entertainment')
insert into Question (QuestionText) values ('Please rate the ticket price for the trip you are taking')

insert into Mapping (QuestionId, MultipleChoiceId) values (1, 1)
insert into Mapping (QuestionId, MultipleChoiceId) values (2, 1)
insert into Mapping (QuestionId, MultipleChoiceId) values (3, 1)
insert into Mapping (QuestionId, MultipleChoiceId) values (4, 1)

insert into Survey (SurveyName) values ('Sample Survey Form')

insert into SurveyDetail (SurveyId, MappingId) values (1, 1)
insert into SurveyDetail (SurveyId, MappingId) values (1, 2)
insert into SurveyDetail (SurveyId, MappingId) values (1, 3)
insert into SurveyDetail (SurveyId, MappingId) values (1, 4)