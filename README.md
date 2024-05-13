# Process-Monitor-Utility


## Description
This utility is designed to monitor specific Windows processes and automatically terminate them if they exceed a specified runtime. It's built with .NET 7 and can be used to ensure that certain applications do not exceed resource utilization limits.

## Prerequisites
To run this utility, you will need:
- .NET 7.0.400 or later installed on your machine.
- NUnit.Framework
- Moq library

## Installation
1. Clone the repository to your local machine using:

git clone https://github.com/tudor129/Process-Monitor-Utility.git

2. Navigate into the project directory:

cd ProcessMonitorUtility

3. To start monitoring a process:

dotnet run

4. Type the name of the process. Example: notepad, explorer (it won't work with other processes at the moment)

5. Type the desired lifetime. Example: 2

6. Type the desired frequency of monitoring. Example: 1

This command configures the utility to monitor all instances of Notepad. If a Notepad process runs longer than 2 minutes, it will be terminated. The application checks for running processes every second.

## TESTING

To run the unit tests for this project: 

dotnet test
