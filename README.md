# STE C# Pair

## Setup

1. Install Docker locally. https://docs.docker.com/get-docker/
2. Run `docker-compose up` in `SurveyDatabase` folder to run the MySql database locally.
3. Install .NET 5.0 https://dotnet.microsoft.com/download
4. Run `dotnet test` in the root directory to run tests.
5. Add tests to `tests\SurveyApi.Tests\SurveyApiTests.cs`.
6. Run `dotnet test` again to re-run tests.

## API Requirements

* If a request does not satisfy business or technical requirements, it **must** return an InvalidRequest (HTTP status code BadRequest) instead of throwing an exception.
* All survey responses must have the survey ID they are for, the customer name, customer email, and complete set of question responses for that survey response.
* Users should be given back their survey response with the saved ID so they can retrieve it later if they wish.
* Survey ID must correspond to an existing survey.
* Customer name must be the full name, defined as having a space in it.
* Customer email must pass a basic email validation test (some characters, an @ sign, some more characters, a dot, and some more characters).
* There must be at least one question response on the survey response.
* Question IDs must correspond to existing questions tied to the survey on the Survey ID passed up.
* Responses must not be null or whitespace.

