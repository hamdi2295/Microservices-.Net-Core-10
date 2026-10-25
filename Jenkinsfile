```groovy
pipeline {
    agent any

    environment {
        APP_NAME       = 'my-microservice-api'
        CONTAINER_NAME = 'my-microservice-container'
        IMAGE_TAG      = 'latest'
        HOST_PORT      = '7001'
        CONTAINER_PORT = '8080'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Check Docker') {
            steps {
                sh '''
                    set -e
                    docker version
                    docker info
                '''
            }
        }

        stage('Build Docker Image') {
            steps {
                sh '''
                    set -e
                    docker build \
                      --pull \
                      -t ${APP_NAME}:${IMAGE_TAG} .
                '''
            }
        }

        stage('Verify Docker Image') {
            steps {
                sh '''
                    set -e
                    docker image inspect \
                      ${APP_NAME}:${IMAGE_TAG}
                '''
            }
        }

        stage('Deploy Container') {
            steps {
                sh '''
                    set -e

                    # Simpan image yang akan dijalankan
                    docker image inspect \
                      ${APP_NAME}:${IMAGE_TAG}

                    # Hapus container lama jika tersedia
                    docker stop ${CONTAINER_NAME} || true
                    docker rm ${CONTAINER_NAME} || true

                    # Jalankan container baru
                    docker run -d \
                      --name ${CONTAINER_NAME} \
                      -p ${HOST_PORT}:${CONTAINER_PORT} \
                      --restart unless-stopped \
                      ${APP_NAME}:${IMAGE_TAG}

                    # Tunggu sebentar untuk startup
                    sleep 5

                    # Verifikasi status container
                    STATUS=$(docker inspect \
                      -f '{{.State.Status}}' \
                      ${CONTAINER_NAME})

                    echo "Container status: ${STATUS}"

                    if [ "$STATUS" != "running" ]; then
                        docker logs ${CONTAINER_NAME}
                        exit 1
                    fi

                    docker ps \
                      --filter "name=${CONTAINER_NAME}"

                    docker logs --tail 50 ${CONTAINER_NAME}
                '''
            }
        }
    }

    post {
        success {
            echo 'Pipeline selesai. Container berhasil berjalan.'
            echo 'Periksa API di http://localhost:7001'
        }

        failure {
            echo 'Pipeline gagal. Periksa Console Output untuk detail.'
            sh '''
                docker logs ${CONTAINER_NAME} || true
            '''
        }
    }
}
```