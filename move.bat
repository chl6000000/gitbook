@echo off
:: copy to destint
::robocopy sd dd /e
:: move and delete origin files
robocopy "%CD%\_book" "C:\Users\chenh\Documents\GitHub\testgitbook" /move /e
pause