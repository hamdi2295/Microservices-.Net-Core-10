
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

        // 1. Ambil source code dari GitHub
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        // 2. Periksa akses Docker dari Jenkins
        stage('Check Docker') {
            steps {
                sh '''
                    set -e
                    echo "Checking Docker CLI..."
                    docker --version

                    echo "Checking Docker Engine..."
                    docker info
                '''
            }
        }

        // 3. Build Docker image aplikasi .NET 10
        stage('Build Docker Image') {
            steps {
                sh '''
                    set -e

                    echo "Building Docker image..."

                    docker build \
                        -t ${APP_NAME}:${IMAGE_TAG} .

                    echo "Docker image build successful."
                '''
            }
        }

        // 4. Verifikasi Docker image
        stage('Verify Docker Image') {
            steps {
                sh '''
                    set -e

                    docker image inspect \
                        ${APP_NAME}:${IMAGE_TAG}

                    echo "Docker image verified."
                '''
            }
        }

        // 5. Deploy aplikasi ke Docker
        stage('Deploy Container') {
            steps {
                sh '''
                    set -e

                    echo "Stopping old container if it exists..."

                    if docker container inspect ${CONTAINER_NAME} \
                        >/dev/null 2>&1; then
                        docker stop ${CONTAINER_NAME} || true
                        docker rm ${CONTAINER_NAME} || true
                    fi

                    echo "Starting new container..."

                    docker run -d \
                        --name ${CONTAINER_NAME} \
                        -p ${HOST_PORT}:${CONTAINER_PORT} \
                        --restart unless-stopped \
                        ${APP_NAME}:${IMAGE_TAG}

                    echo "Waiting for application startup..."
                    sleep 5

                    STATUS=$(docker inspect \
                        -f '{{.State.Status}}' \
                        ${CONTAINER_NAME})

                    echo "Container status: ${STATUS}"

                    if [ "$STATUS" != "running" ]; then
                        echo "Container failed to start."
                        docker logs ${CONTAINER_NAME} || true
                        exit 1
                    fi

                    echo "Container is running."
                    docker ps \
                        --filter "name=${CONTAINER_NAME}"

                    echo "Recent application logs:"
                    docker logs --tail 50 ${CONTAINER_NAME}
                '''
            }
        }
    }

    post {
        success {
            echo '''
            ========================================
            PIPELINE SUCCESS
            ========================================
            Docker image built successfully.
            Container deployed successfully.

            Application URL:
            http://localhost:7001

            Container:
            my-microservice-container
            ========================================
            '''
        }

        failure {
            echo 'PIPELINE FAILED. Check Console Output.'

            sh '''
                docker logs my-microservice-container || true
            '''
        }

        always {
            echo 'Jenkins pipeline execution completed.'
        }
    }
}
