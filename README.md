# SamDinner

This is a project for practicing some concepts when developing an .NET Web Application.

Concepts and tools that I'll use:
- Clean Architecture
- Domain Driven Design
- Visual Studio 2022
- dotnet CLI

I am using the Clean Architecture as a core concept, so the hierarchy order is:

<table>
    <thead>
        <tr>
            <th>Presentation</th>
            <th>Infrastructure</th>
        </tr>
    </thead>
    <tbody>
        <td style="text-align: center" colspan=2>Application</td>
				<tr rowspan=2>
					<td style="text-align: center" colspan=2>Domain</td>
				</tr>
    </tbody>
</table>

 In detail:

 ## Presentation:
 ### Web api, MVC, Razor Pages, SPA (Angular, Vue, React)

 ## Infrastructure (DB)
 ### Persistence, Identity, File, System, System clock

 ## Application
 ### Interfaces, Models, Logic, Commands/Queries, Validators, Exceptions

 ## Domain
 ### Entities, Value Objects, Enumerations, Logic, Exceptions

 ---
 
 Topics that I want to cover in this project:

#### Presentation
- Libraries
  - Mapster
- Concepts/Patterns
  - Mediator

#### Infrastructure
  - Libraries
    - EF Core
	- BCrypt
  - Concepts/Patterns
    - ORM
    
#### Application
- Libraries
  - MediaTR
    - Requests
    - Notifications
    - Behaviors
  - FluentValidation
- Concepts/Patterns
  - CQRS
  - Repository
  - Unit of Work

#### Domain
  - Libraries
    - ErrorOr
  - Concepts/Patterns
    - Aggregates
    - Aggregate Roots
    - ValueObjects
    - Entities
    - Domain Errors
    - Domain Events