#!/usr/bin/env -S dotnet fsi

#load "Utilities.fs"

open Boxcreek.Utilities

let now = System.DateTime.Now

let rec addBusinessDays (dt: System.DateTime) days =
    match days, dt.DayOfWeek with
    | 0, _ -> dt
    | _, System.DayOfWeek.Saturday
    | _, System.DayOfWeek.Sunday -> addBusinessDays (dt.AddDays(1)) days
    | _, _ -> addBusinessDays (dt.AddDays(1)) (days - 1)


let newDate = addBusinessDays now 7

now |> pp
newDate |> pp

//System.TimeZoneInfo.ConvertTime(now, System.TimeZoneInfo.)|> pp
now.TimeOfDay |> pp

let cutoffTime = System.TimeSpan(12, 0, 0)

System.TimeZoneInfo.FindSystemTimeZoneById "America/New_York"
|> pp

System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, "America/New_York")
|> (fun dt -> dt.TimeOfDay > cutoffTime)
|> pp

System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, "America/Los_Angeles")
|> (fun dt -> dt.TimeOfDay > cutoffTime)
|> pp

let dtFormat = "yyyy-MM-dd"
now.ToString dtFormat |> pp
