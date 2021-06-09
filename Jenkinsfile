pipeline {
    agent any
    stages {
        stage('Tests') {
            steps {
                bat returnStatus: true, script: "npx dotnet test \"${workspace}/ApiAutomationTest.sln\" --logger \"nunit;LogFileName=results.xml\""
                nunit failIfNoResults: true, testResultsPattern: '**/results.xml'
            }
        }
    }
}


