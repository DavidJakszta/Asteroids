pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Checkout the code from the repository
                checkout scm
            }
        }

        stage('Build') {
            steps {
                // Run Unity build commands here
                sh 'unity -batchmode -projectPath . -executeMethod BuildScript.BuildAll'
            }
        }

        stage('Deploy') {
            steps {
                // Deploy the built artifacts to your target location
                sh 'cp -r Build/ YourDeploymentDirectory/'
            }
        }
    }

    post {
        always {
            // Clean up or perform any post-build tasks here
        }
    }
}
