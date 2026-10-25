
pipeline {
    agent any

    options {
        timestamps()
        disableConcurrentBuilds()
    }

    environment {
        APP_NAME       = 'my-microservice-api'
        IMAGE_TAG      = 'latest'
        CONTAINER_NAME = 'myschool-api'
        SERVICE_NAME   = 'myschool'

        HOST_PORT      = '7001'
        CONTAINER_PORT = '8080'

        COMPOSE_FILE   = 'docker-compose.yml'
    }

    stages {

        // 1. Checkout source code dari SCM
        stage('Checkout') {
            steps {
                checkout scm

                sh '''
                    echo "=================================="
                    echo "CHECKOUT SOURCE CODE"
                    echo "=================================="

                    echo "Current directory:"
                    pwd

                    echo "Project files:"
                    ls -la

                    echo "Checking Docker Compose file..."
                    test -f "${COMPOSE_FILE}"
                '''
            }
        }

        // 2. Periksa Docker CLI dan Docker Engine
        stage('Check Docker Environment') {
            steps {
                sh '''
                    set -e

                    echo "=================================="
                    echo "CHECK DOCKER ENVIRONMENT"
                    echo "=================================="

                    docker --version
                    docker compose version
                    docker info

                    echo "Docker Engine is accessible."
                '''
            }
        }

        // 3. Validasi konfigurasi Docker Compose
        stage('Validate Docker Compose') {
            steps {
                sh '''
                    set -e

                    echo "=================================="
                    echo "VALIDATE DOCKER COMPOSE"
                    echo "=================================="

                    docker compose \
                        -f "${COMPOSE_FILE}" \
                        config --quiet

                    echo "Docker Compose configuration is valid."
                '''
            }
        }

        // 4. Build Docker image aplikasi
        stage('Build Docker Image') {
            steps {
                sh '''
                    set -e

                    echo "=================================="
                    echo "BUILD DOCKER IMAGE"
                    echo "=================================="

                    docker compose \
                        -f "${COMPOSE_FILE}" \
                        build "${SERVICE_NAME}"

                    echo "Docker image build completed."
                '''
            }
        }

        // 5. Verifikasi image yang dihasilkan
        stage('Verify Docker Image') {
            steps {
                sh '''
                    set -e

                    echo "=================================="
                    echo "VERIFY DOCKER IMAGE"
                    echo "=================================="

                    docker image inspect \
                        "${APP_NAME}:${IMAGE_TAG}"

                    echo "Image verification completed."
                '''
            }
        }

        // 6. Deploy menggunakan Docker Compose
        stage('Deploy Container') {
            steps {
                sh '''
                    set -e

                    echo "=================================="
                    echo "DEPLOY MYSCHOOL API"
                    echo "=================================="

                    # Buat atau perbarui service MySchool.
                    # Service Jenkins tidak dihentikan.
                    docker compose \
                        -f "${COMPOSE_FILE}" \
                        up -d \
                        --no-deps \
                        "${SERVICE_NAME}"

                    echo "Waiting for container startup..."
                    sleep 5

                    echo "Checking container status..."

                    STATUS=$(docker inspect \
                        -f '{{.State.Status}}' \
                        "${CONTAINER_NAME}")

                    echo "Container status: ${STATUS}"

                    if [ "${STATUS}" != "running" ]; then
                        echo "Deployment failed."
                        docker logs "${CONTAINER_NAME}" || true
                        exit 1
                    fi

                    docker compose \
                        -f "${COMPOSE_FILE}" \
                        ps "${SERVICE_NAME}"

                    echo "Recent application logs:"
                    docker logs --tail 50 "${CONTAINER_NAME}"
                '''
            }
        }

        // 7. Uji HTTP endpoint API
        stage('Smoke Test API') {
            steps {
                sh '''
                    set -e

                    echo "=================================="
                    echo "SMOKE TEST API"
                    echo "=================================="

                    URL="http://host.docker.internal:${HOST_PORT}/api/students"

                    echo "Testing endpoint: ${URL}"

                    ATTEMPT=1
                    MAX_ATTEMPTS=12

                    while [ "${ATTEMPT}" -le "${MAX_ATTEMPTS}" ]; do
                        if curl -fsS \
                            --max-time 5 \
                            "${URL}" \
                            -o /dev/null; then

                            echo "API endpoint responded successfully."
                            exit 0
                        fi

                        echo "Attempt ${ATTEMPT}/${MAX_ATTEMPTS} failed. Retrying..."
                        sleep 5
                        ATTEMPT=$((ATTEMPT + 1))
                    done

                    echo "API smoke test failed."
                    docker logs "${CONTAINER_NAME}" || true
                    exit 1
                '''
            }
        }
    }

    post {
        success {
            echo '''
            ==========================================
                    PIPELINE SUCCESS
            ==========================================
            Checkout             : SUCCESS
            Docker validation    : SUCCESS
            Docker image build   : SUCCESS
            Image verification   : SUCCESS
            Deployment           : SUCCESS
            API smoke test       : SUCCESS

            Application:
            http://localhost:7001

            Container:
            myschool-api

            API endpoint:
            http://localhost:7001/api/students
            ==========================================
            '''
        }

        failure {
            echo '''
            ==========================================
                    PIPELINE FAILED
            ==========================================
            Please check the stage that failed
            in Jenkins Console Output.
            ==========================================
            '''

            sh '''
                echo "Docker Compose service status:"
                docker compose \
                    -f "${COMPOSE_FILE}" \
                    ps "${SERVICE_NAME}" || true

                echo "Container logs:"
                docker logs "${CONTAINER_NAME}" || true
            '''
        }

        always {
            echo 'Jenkins pipeline execution completed.'
        }
    }
}
