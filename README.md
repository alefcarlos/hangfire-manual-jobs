![.NET Core](https://github.com/alefcarlos/hangfire-manual-jobs/workflows/.NET%20Core/badge.svg)

Hangfire POC
=======

Using [Hangfire](https://github.com/HangfireIO/Hangfire#hangfire-) and [Hangfire.MissionControl ](https://github.com/ahydrax/Hangfire.MissionControl)

# Features 

- Dependency Injection
- Manual Jobs
- InMemory Storage
- ASPNET Core 3

# Run

```bash
docker build -t hangfire:poc .
docker run --rm -p 8080:80 hangfire:poc
```