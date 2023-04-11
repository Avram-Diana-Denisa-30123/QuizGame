/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[username]
      ,[password]
      ,[scor]
  FROM [LoginAppDB].[dbo].[usertb]