USE master
GO

CREATE DATABASE StudentDb
ON  PRIMARY 
( 
    NAME = N'StudentDb', 
    FILENAME = N'<location>' , 
    SIZE = 8192KB , 
    MAXSIZE = UNLIMITED, 
    FILEGROWTH = 65536KB 
)
LOG ON 
( 
    NAME = N'StudentDb_log', 
    FILENAME = N'<location>' , 
    SIZE = 8192KB , 
    MAXSIZE = 2048GB , 
    FILEGROWTH = 65536KB 
)
GO