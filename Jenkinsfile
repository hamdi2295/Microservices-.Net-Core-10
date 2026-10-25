pipeline {
    agent any

    environment {
        APP_NAME       = 'my-microservice-api'
        CONTAINER_NAME = 'my-microservice-container'
        IMAGE_TAG      = 'latest'
        HOST_PORT      = '7001'
        CONTAINER_PORT = '8080' // Port default appsettings.json/Dockerfile
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Docker Image') {
            steps {
                // appsettings.json akan otomatis masuk ke dalam image saat build
                sh "docker build -t ${APP_NAME}:${IMAGE_TAG} ."
            }
        }

        stage('Deploy Container') {
            steps {
                sh '''
                    # Stop dan hapus container lama jika ada
                    docker stop ${CONTAINER_NAME} || true
                    docker rm ${CONTAINER_NAME} || true

                    # Jalankan container baru
                    docker run -d \
                      --name ${CONTAINER_NAME} \
                      -p ${HOST_PORT}:${CONTAINER_PORT} \
                      --restart unless-stopped \
                      ${APP_NAME}:${IMAGE_TAG}
                '''
            }
        }
    }

    post {
        always {
            // Pembersihan image gantung
            sh 'docker image prune -f'
        }
    }
}