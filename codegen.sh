#!/bin/bash

dotnet tool restore

dotnet fsdgenaspnet fsd//SurveyApi.fsd src//SurveyApi.v1//Controllers --namespace SurveyApi.v1.Controllers --target core --newline lf
dotnet fsdgencsharp fsd//SurveyApi.fsd src//Faithlife.SurveyApi.v1.Client// --clean --newline lf
