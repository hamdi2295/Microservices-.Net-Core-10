
pipeline {
    agent any

    stages {
        stage('Check .NET SDK') {
            steps {
                sh 'dotnet --info'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --configuration Release --no-build'
            }
        }

        stage('Publish') {
            steps {
                sh '''
                    dotnet publish \
                      --configuration Release \
                      --no-build \
                      --output publish
                '''
            }
        }
    }

    post {
        success {
            echo 'Build dan pipeline .NET API berhasil!'
            archiveArtifacts artifacts: 'publish/**',
                             allowEmptyArchive: false
        }

        failure {
            echo 'Pipeline gagal. Periksa Console Output.'
        }
    }
}
