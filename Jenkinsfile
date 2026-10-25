pipeline {
    agent any

    environment {
        DOTNET_ROOT = "${WORKSPACE}/.dotnet"
        PATH        = "${WORKSPACE}/.dotnet:${env.PATH}"
        DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = '1'
    }

    stages {
        stage('Setup .NET 10 SDK') {
            steps {
                sh '''
                    if [ ! -d "$DOTNET_ROOT" ]; then
                        echo "Downloading .NET 10 SDK..."
                        curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
                        chmod +x dotnet-install.sh
                        ./dotnet-install.sh --channel 10.0 --install-dir "$DOTNET_ROOT"
                        rm dotnet-install.sh
                    fi
                '''
            }
        }

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
                sh 'dotnet build --configuration Release'
            }
        }
    }
}