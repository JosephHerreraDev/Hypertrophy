# Hypertrophy

Hypertrophy is a workout routine management application built for lifters who want structured, flexible, and data-driven training. The focus is a clean workflow for planning workouts, logging sessions, and tracking long-term progress—without turning the app into a social network or an all-in-one “fitness platform”.

## Features (Planned)

- Routine / program builder
- Workout logging (sets, reps, weight, RPE, rest times)
- Exercise library + variations
- Progress tracking (volume, PRs, trends, estimated 1RM)
- Program history and adherence insights
- Minimal, distraction-free UI

## Architecture

This project follows **Clean Architecture** to keep business rules independent from frameworks and UI.

Typical layers:
- **Domain**: core entities, value objects, domain rules
- **Application**: use cases, DTOs, validation, interfaces
- **Infrastructure**: EF Core, PostgreSQL, external services
- **Presentation**: Web UI + API endpoints

## Tech Stack

### Client
- Web application (details coming soon)

### Server
- .NET (ASP.NET Core)
- PostgreSQL

## Project Status

Early development / planning phase.

Currently defining:
- Data models and relationships
- Core workflows (program creation, session logging, metrics)
- API boundaries and contracts

## Roadmap (High Level)

- [ ] Define domain model (Program, Workout, Exercise, Set)
- [ ] CRUD for routines and exercises
- [ ] Logging workflow (start session → record sets → finish session)
- [ ] Basic metrics (weekly volume, PR tracking)
- [ ] Auth + user profiles (optional, depending on scope)
- [ ] Export/import (CSV/JSON)
