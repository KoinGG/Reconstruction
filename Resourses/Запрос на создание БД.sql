--CREATE DATABASE [Reconstruction]
--USE [Reconstruction]

GO

CREATE TABLE [User]
(
	UserID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Surname] NVARCHAR(25) NOT NULL,
	[Name] NVARCHAR(25) NOT NULL,
	[Patronymic] NVARCHAR(25) NOT NULL,
	[Login] NVARCHAR(20) UNIQUE NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	[PhoneNumber] NVARCHAR(15) NOT NULL
)

CREATE TABLE [TaskStatus]
(
	TaskStatusID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	StatusType NVARCHAR(15) NOT NULL,
)

CREATE TABLE [Task]
(
	TaskID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	TaskStatusID INT NOT NULL,
	CreatingUserID INT NOT NULL,

	FOREIGN KEY (TaskStatusID) REFERENCES [TaskStatus] (TaskStatusID) ON DELETE CASCADE,
	FOREIGN KEY (CreatingUserID) REFERENCES [User] (UserID) ON DELETE CASCADE
)