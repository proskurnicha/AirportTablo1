CREATE VIEW StatisticTerminalCount
AS
SElECT TerminalInfo, Count(*) as CountTerminal FROM Flights 
INNER JOIN Terminals
ON Terminals.Id = Flights.TerminalId
GROUP BY TerminalInfo;
